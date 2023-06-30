namespace Web_API.DTO.CustomerDTO
{
    public class CustomerDTO
    {
        public required string customer_name { get; set; }
        public byte[]? customer_avatar { get; set; }
        public required string city { get; set; }
        public required string? pin_code { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }

    }
}
