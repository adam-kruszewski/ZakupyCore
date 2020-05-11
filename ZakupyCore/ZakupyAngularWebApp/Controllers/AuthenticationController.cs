using System;
using System.Buffers.Text;
using System.Security.Cryptography;
using Kruchy.Uzytkownicy.Services;
using Kruchy.Uzytkownicy.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using ZakupyAngularWebApp.RestApiModels;

namespace ZakupyAngularWebApp.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IUzytkownicyService uzytkownicyService;

        public AuthenticationController(
            IUzytkownicyService uzytkownicyService)
        {
            this.uzytkownicyService = uzytkownicyService;
        }

        public AuthenticationResult Post([FromBody] AuthenticationRequest request)
        {
            var user =
                uzytkownicyService
                    .SzukajWgNazwyLubEmailaHasla(request.UsernameOrEmail, request.Password);

            if (user != null)
                return GetSuccessfullResult(user);
            else
                return GetFailedResult();
        }

        private AuthenticationResult GetFailedResult()
        {
            return new AuthenticationResult { Success = false };
        }

        private AuthenticationResult GetSuccessfullResult(UzytkownikView uzytkownikView)
        {
            return new AuthenticationResult
            {
                Success = true,
                Identity = new UserIdentity
                {
                    Name = uzytkownikView.Nazwa,
                    Email = uzytkownikView.Email
                },
                Token = GetToken(uzytkownikView)
            };

        }

        private string GetToken(UzytkownikView uzytkownikView)
        {
            var md5 = MD5.Create();
            var textToHash = string.Format("{0}::{1}::{2}",
                uzytkownikView.ID,
                uzytkownikView.Nazwa,
                uzytkownikView.Email);

            var inputBytes = System.Text.Encoding.Default.GetBytes(textToHash);
            var outputBytes = md5.ComputeHash(inputBytes);
            var result = Base64UrlTextEncoder.Encode(outputBytes);

            return result;
        }
    }
}
