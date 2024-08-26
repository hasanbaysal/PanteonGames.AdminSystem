namespace PanteonGames.AdminSystem.Dto.GameConfigDto
{
    public class GameConfigCreateDto
    {

        public int UserId { get; set; }
        public int ConstructionTime { get; set; }
        public int BuildingCost { get; set; }
        public string BuildingType { get; set; } = null!;
    }
}
