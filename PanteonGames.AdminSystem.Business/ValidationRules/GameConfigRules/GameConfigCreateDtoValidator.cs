using FluentValidation;
using PanteonGames.AdminSystem.Dto.GameConfigDto;

namespace PanteonGames.AdminSystem.Business.ValidationRules.GameConfigRules
{
    public class GameConfigCreateDtoValidator : AbstractValidator<GameConfigCreateDto>
    {
        public GameConfigCreateDtoValidator()
        {
            RuleFor(x => x.BuildingCost).NotEmpty().WithMessage("building cost cannot be empty");
            RuleFor(x => x.BuildingCost)
           .GreaterThan(0).WithMessage("building Cost must be greater than zero");

            RuleFor(x => x.ConstructionTime).NotEmpty().WithMessage("construction time  cannot be empty");
            RuleFor(x => x.ConstructionTime)
           .InclusiveBetween(30, 1800).WithMessage("constructionTime must be between 30 and 1800");

            RuleFor(x => x.BuildingType).NotEmpty().WithMessage("building type  cannot be empty");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("user id t cannot be empty");


        }
    }
}
