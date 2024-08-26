using FluentValidation;
using PanteonGames.AdminSystem.Dto;

namespace PanteonGames.AdminSystem.Business.ValidationRules.AppUserRules
{
    public class AppUserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("password cannot be empty");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("User Name cannot be empty");

        }

    }
}
