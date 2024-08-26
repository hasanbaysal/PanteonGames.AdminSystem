namespace PanteonGames.AdminSystem.Dto
{
    public interface IDto
    {

    }

    public interface IUpdateDto : IDto
    {
        public int Id { get; set; }
    }

    public interface IListDto : IDto
    {

    }
    public interface ICreateDto : IDto
    {

    }


}
