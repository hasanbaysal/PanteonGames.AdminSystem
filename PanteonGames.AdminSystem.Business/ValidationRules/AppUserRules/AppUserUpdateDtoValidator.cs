using FluentValidation;
using PanteonGames.AdminSystem.Dto;

namespace PanteonGames.AdminSystem.Business.ValidationRules.AppUserRules
{
    public class AppUserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public AppUserUpdateDtoValidator()
        {
            RuleFor(x => x.Email)
                    .NotEmpty()
                    .WithMessage("Email is required")
                    .EmailAddress()
                    .WithMessage("incorrect email frmat");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required")
                .MinimumLength(8)
                .WithMessage("password must be greater than eight characters");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("User Name is required")
                .MinimumLength(5)
                .WithMessage("user name must be greater than five characters");


        }

    }
}
