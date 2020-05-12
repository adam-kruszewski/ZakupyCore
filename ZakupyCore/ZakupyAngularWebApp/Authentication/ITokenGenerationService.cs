using Kruchy.Uzytkownicy.Views;

namespace ZakupyAngularWebApp.Authentication
{
    public interface ITokenGenerationService
    {
        string GetToken(UzytkownikView uzytkownik);

        bool VerifyToken(string token);
    }
}