namespace PanteonGames.AdminSystem.Helper.ResponseStucture
{
    public interface IResponse<T> : IResponse
    {
        T Data { get; set; }
        List<CustomValidationError> Errors { get; set; }
    }
}
