using Kemar.MBS.Model.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Kemar.MBS.API.Core.Helper
{
    public static class CommonHelper
    {
        public static IActionResult ReturnActionResultByStatus(ResultModel result, ControllerBase controller)
        {
            if (result == null)
                return controller.NotFound("Result is null");

            return result.StatusCode switch
            {
                ResultCode.SuccessfullyCreated => controller.Created("", result),
                ResultCode.SuccessfullyUpdated => controller.Ok(result),
                ResultCode.Success => controller.Ok(result),
                ResultCode.Unauthorized => controller.Unauthorized(result),
                ResultCode.DuplicateRecord => controller.Conflict(result),
                ResultCode.RecordNotFound => controller.NotFound(result),
                ResultCode.NotAllowed => controller.NotFound(result),
                ResultCode.Invalid => controller.BadRequest(result),
                ResultCode.ExceptionThrown => controller.StatusCode(500, result),
                _ => controller.BadRequest(result),
            };
        }

        // Sets CreatedBy / UpdatedBy from JWT token
        public static void SetUserInformation<T>(ref T request, int entityId, HttpContext httpContext)
            where T : BaseRequestDto
        {
            var userIdClaim = httpContext.User?.Claims?
                .FirstOrDefault(c => c.Type == "UserId");

            if (userIdClaim == null)
                return; // user not logged in → skip

            int userId = int.Parse(userIdClaim.Value);

            if (entityId == 0)
            {
                request.CreatedBy = userId;
                request.UpdatedBy = userId;
            }
            else
            {
                request.UpdatedBy = userId;
            }
        }
    }
}
