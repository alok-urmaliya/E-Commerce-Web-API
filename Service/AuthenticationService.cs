using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web_API.DTO.CustomerDTO;
using Web_API.Models;

namespace Web_API.Service
{
    public class AuthenticationService
    {
        private readonly UserManager<Customer> _usermanager;
        private readonly SignInManager<Customer> _signinmanager;
        private readonly IConfiguration _configuration;
        
        public AuthenticationService(UserManager<Customer> usermanager, SignInManager<Customer> signinmanager, IConfiguration configuration)
        {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
            _configuration = configuration;
        }

        public async Task<ActionResult<Object>> Register(CustomerDTO customer)
        {
            string password = customer.Password;
            var Customer = new Customer()
            {
                UserName = customer.Email,
                Email = customer.Email,
                customer_name = customer.customer_name,
                customer_avatar = customer.customer_avatar,
                city = customer.city,
                pin_code = customer.pin_code,
                IsActive = true
            };
            var result  = await _usermanager.CreateAsync(Customer, password);
            if (result.Succeeded)
            {
                var claimDepartment = new Claim("Department", customer.Department);
                var claimPosition = new Claim("Position", customer.Position);
                await this._usermanager.AddClaimAsync(Customer, claimDepartment);
                await this._usermanager.AddClaimAsync(Customer, claimPosition);
                return Customer;
            }
            var error = result.ToString();
            return error;
        }

        public async Task<ActionResult<Object>> Login(LoginDTO customer)
        {
            var result = await _signinmanager.PasswordSignInAsync(customer.Email, customer.Password, false, false);
            if (result.Succeeded)
            {
                var currentUser = _usermanager.Users.FirstOrDefault(u => u.Email == customer.Email);


                var claims = await _usermanager.GetClaimsAsync(currentUser);
                var expiresAt = DateTime.UtcNow.AddMinutes(10);

                var token = CreateToken(claims, expiresAt);
                //Console.ReadLine();
                return new JwtToken
                {
                    access_token = CreateToken(claims, expiresAt),
                    expires_at = expiresAt
                };
            }
            else
                return "User Not Found";
        }

        private string CreateToken(IEnumerable<Claim> claims, DateTime expiresAt)
        {
            var secretKey = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey"));

            var jwt = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiresAt,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
