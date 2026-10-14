using Daftareshoma.CallControlSample.Models;
using Daftareshoma.CallControlSample.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Daftareshoma.CallControlSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CallControlController : Controller
    {
        
        private readonly IServiceCammand _serviceCammand;
        public CallControlController(IServiceCammand serviceCammand)
        {
           
            _serviceCammand = serviceCammand;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendCommand(InitialCallWebhook initialCallWebhook)
        {
            await  _serviceCammand.SendCommandPlayVoice(initialCallWebhook.CallId);
            return Ok();
        }
    }
}
