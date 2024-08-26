namespace PanteonGames.AdminSystem.Entity.Entities
{

    public class AppUser : BaseEntity
    {

        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;

    }
}
