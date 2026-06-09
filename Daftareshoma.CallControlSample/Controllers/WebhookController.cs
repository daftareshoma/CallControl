using Microsoft.AspNetCore.Mvc;

namespace Daftareshoma.CallControlSample.Controllers
{
    public class WebhookController : Controller
    {
        [HttpPost("[action]")]
        public IActionResult GetCallWebhook([FromBody] object request)
        {
            //_webhookCallControlService.GetWebHookAndSendCommand(initialCallWebhook);
            return Ok();
        }
    }
}
