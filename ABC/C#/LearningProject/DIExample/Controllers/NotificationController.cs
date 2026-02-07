
using DIExample.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace DIExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;

        public NotificationController(INotificationService service)
        {
            _service = service;
        }

        [HttpPost("email")]
        public async Task<IActionResult> SendEmail([FromBody] string message)
        {
            return Ok(await _service.SendEmail(message));
        }

        [HttpPost("sms")]
        public async Task<IActionResult> SendSms([FromBody] string message)
        {
            return Ok(await _service.SendSms(message));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());


        }
    }

}


