namespace Bidvest.UI.Services
{
    public interface IAuthorizationService
    {
        Task SetLoginToken(string Token);
        string GetToken();
        Task ProcessTokenAsync();
        bool IsValidToken();
        Task WipePersonalDataAsync();
    }
}
