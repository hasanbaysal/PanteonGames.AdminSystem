namespace PanteonGames.AdminSystem.Business.Services
{
    public interface ITokenService
    {

        string GetToken(int id, string userName, string email);
    }
}
