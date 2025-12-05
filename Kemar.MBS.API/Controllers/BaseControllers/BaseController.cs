using Kemar.MBS.API.Core.Helper;
using Kemar.MBS.Model.Common;
using Microsoft.AspNetCore.Mvc;

namespace Kemar.MBS.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected T PrepareRequest<T>(T request, int entityId = 0) where T : BaseRequestDto
        {
            CommonHelper.SetUserInformation(ref request, entityId, HttpContext);
            return request;
        }

        protected IActionResult Respond(ResultModel result)
        {
            return CommonHelper.ReturnActionResultByStatus(result, this);
        }
    }
}
