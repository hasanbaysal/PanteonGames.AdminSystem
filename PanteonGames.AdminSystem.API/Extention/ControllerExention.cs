using Microsoft.AspNetCore.Mvc;
using PanteonGames.AdminSystem.Helper.ResponseStucture;

namespace PanteonGames.AdminSystem.API.Extention
{



    public static class ApiControllerExtensions
    {
        public static IActionResult Response<T>(this ControllerBase controller, IResponse<T> response)
        {
            switch (response.ResponseType)
            {
                case ResponseType.Success:
                    return controller.Ok(response.Data);

                case ResponseType.ValidationError:
                    return controller.BadRequest(new
                    {
                        Message = response.Message ?? "message",
                        Errors = response.Errors
                    });

                case ResponseType.Conflict:
                    return controller.StatusCode(409, new
                    {
                        Message = response.Message ?? "message",
                        Errors = response.Errors
                    });
                /*
                 new
                    {
                        Message = response.Message??"message",
                        Errors = response.Errors

                    }
                 */
                case ResponseType.NotFound:
                    return controller.NotFound(new { Message = response.Message ?? "not found" });

                case ResponseType.Error:
                    return controller.StatusCode(500, new { Message = response.Message ?? "internall error" });
          case ResponseType.UserNotFound:
                            return controller.StatusCode(400, new { Message = response.Message ?? "internall error" });

                default:
                    return controller.StatusCode(500, new { Message = "an unknown error occurred" });
            }
        }


        public static IActionResult ResponseValidationError<T>(this ControllerBase controller, List<CustomValidationError> errors)
        {
            return controller.BadRequest(new
            {
                Message = "Validation errors occurred.",
                Errors = errors
            });
        }


        public static IActionResult ResponseError(this ControllerBase controller, string message)
        {
            return controller.StatusCode(500, new { Message = message });
        }


        public static IActionResult ResponseSuccess<T>(this ControllerBase controller, T data)
        {
            return controller.Ok(data);
        }
    }



}
