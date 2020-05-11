namespace ZakupyAngularWebApp.RestApiModels
{
    public class AuthenticationRequest
    {
        public string UsernameOrEmail { get; set; }

        public string Password { get; set; }
    }
}