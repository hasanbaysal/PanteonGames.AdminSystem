namespace PanteonGames.AdminSystem.Helper.ResponseStucture
{
    public interface IResponse
    {
        string Message { get; set; }
        ResponseType ResponseType { get; set; }
    }
}
