namespace PanteonGames.AdminSystem.Dto
{
    public class UserCreateDto : ICreateDto
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;

    }

}
