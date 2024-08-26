using PanteonGames.AdminSystem.Helper.ResponseStucture;

namespace PanteonGames.AdminSystem.Business.Extentions
{

    public static class ValidationResultExtentions
    {

        public static List<CustomValidationError> CustomErrorList(this FluentValidation.Results.ValidationResult validationResult)
        {

            var data = validationResult.Errors.ToList().Select(x =>
            new CustomValidationError
            {
                ErorrMessage = x.ErrorMessage,
                ProppertyName = x.PropertyName

            }).ToList();


            return new List<CustomValidationError>(data);
        }

    }
}
