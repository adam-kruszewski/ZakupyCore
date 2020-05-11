namespace ZakupyAngularWebApp.RestApiModels
{
    public class AuthenticationResult
    {
        public bool Success { get; set; }

        public UserIdentity Identity { get; set; }

        public string Token { get; set; }
    }
}