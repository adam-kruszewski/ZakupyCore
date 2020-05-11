using Kruchy.Uzytkownicy.Services;
using Kruchy.Uzytkownicy.Views;
using Microsoft.AspNetCore.Mvc;
using ZakupyAngularWebApp.Authentication;
using ZakupyAngularWebApp.RestApiModels;

namespace ZakupyAngularWebApp.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IUzytkownicyService uzytkownicyService;
        private readonly ITokenGenerationService tokenGenerationService;

        public AuthenticationController(
            IUzytkownicyService uzytkownicyService,
            ITokenGenerationService tokenGenerationService)
        {
            this.uzytkownicyService = uzytkownicyService;
            this.tokenGenerationService = tokenGenerationService;
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
                Token = tokenGenerationService.GetToken(uzytkownikView)
            };

        }
    }
}