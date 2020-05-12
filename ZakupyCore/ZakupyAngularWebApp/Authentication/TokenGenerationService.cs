using System;
using System.IO;
using Kruchy.Core.Cryptography;
using Kruchy.Uzytkownicy.Views;
using Newtonsoft.Json;

namespace ZakupyAngularWebApp.Authentication
{
    public class TokenGenerationService : ITokenGenerationService
    {
        private readonly IAesEncrypter aesEncoder;

        public TokenGenerationService(
            IAesEncrypter aesEncoder)
        {
            this.aesEncoder = aesEncoder;
        }

        public string GetToken(UzytkownikView uzytkownik)
        {
            var tokenData = new TokenData
            {
                Username = uzytkownik.Nazwa,
                Email = uzytkownik.Email,
                ExpirationDate = DateTime.Now.AddDays(1)
            };

            var writer = new StringWriter();
            new JsonSerializer().Serialize(writer, tokenData);
            var tokenDataString = writer.ToString();

            byte[] encrypted = aesEncoder.Encode(tokenDataString);

            return Convert.ToBase64String(encrypted);
        }

        public bool VerifyToken(string token)
        {
            var encryptedBytes = Convert.FromBase64String(token);

            var decrypted = aesEncoder.Decode(encryptedBytes);
            using (var reader = new StringReader(decrypted))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var tokenData = new JsonSerializer().Deserialize<TokenData>(jsonReader);

                if (tokenData.ExpirationDate < DateTime.Now)
                    return false;
            }

            return true;
        }

        private class TokenData
        {
            public string Username { get; set; }

            public string Email { get; set; }

            public DateTime ExpirationDate { get; set; }
        }
    }
}