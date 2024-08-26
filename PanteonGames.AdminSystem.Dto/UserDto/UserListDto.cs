namespace PanteonGames.AdminSystem.Dto.UserDto
{
    public class UserListDto : IListDto
    {
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
    }
}
