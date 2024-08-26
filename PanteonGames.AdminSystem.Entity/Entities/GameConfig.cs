namespace PanteonGames.AdminSystem.Entity.Entities
{
    public class GameConfig : BaseMongoCollection
    {

        public int UserId { get; set; }


        public int ConstructionTime { get; set; }
        public int BuildingCost { get; set; }
        public string BuildingType { get; set; } = null!;
    }
}
