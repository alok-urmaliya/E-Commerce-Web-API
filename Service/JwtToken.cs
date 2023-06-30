namespace Web_API.Service
{
    public class JwtToken
    {
        public string access_token { get; set; }
        public DateTime expires_at { get; set; }


        public JwtToken() { }

        public JwtToken(string access_token, DateTime expires_at)
        {
            this.access_token = access_token;
            this.expires_at = expires_at;
        }

        public override bool Equals(object? obj)
        {
            return obj is JwtToken other &&
                   access_token == other.access_token &&
                   expires_at == other.expires_at;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(access_token, expires_at);
        }
    }
}
