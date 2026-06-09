using Daftareshoma.CallControlSample.Models;
using Newtonsoft.Json;
using System.Data;
using System.Text;
namespace Daftareshoma.CallControlSample.Services
{
    public class CallCommandWebhook : ICallCommandWebhook
    {
        public void GetWebHookAndSendCommand(object input)
        {
            var inputString = JsonConvert.SerializeObject(input);
            var inputDes = JsonConvert.DeserializeObject<InitialCallWebhook>(inputString);
            if (inputDes != null)
            {
                PlayVoiceCommandRequest request = new PlayVoiceCommandRequest();
                request.Url = "https://cdn.daftareshoma.com/AZM:moh/2023/5/MusicOnHold/64624796c34ec745b4baacbe.wav";
                request.CommandName = "Play_Audio";
                request.CallId = inputDes.CallId;
                request.CommandId = Guid.NewGuid().ToString();
                SendCommand(JsonConvert.SerializeObject(request), request.CommandId, CommandTypeEnum.Play_Audio);
            }
            var inputResplay = JsonConvert.DeserializeObject<PlayVoiceCommandResponse>(inputString);
            if (inputResplay != null)
            {
                AutomaticTransferCammandRequest request = new AutomaticTransferCammandRequest();
                request.CommandName = "AutomaticTransfer";
                request.Numbers = new List<Number>();
                Number number = new Number();
                number.RingTimeout = 30;
                number.To = "09121111111";
                request.Numbers.Add(number);
                Number number1 = new Number();
                number1.RingTimeout = 30;
                number1.To = "09120000000";
                request.Numbers.Add(number1);
                request.MusicOnHold = "https://cdn.daftareshoma.com/AZM:moh/2023/5/MusicOnHold/64624796c34ec745b4baacbe.wav";
                request.CallId = inputResplay.CallId;
                request.CommandId = Guid.NewGuid().ToString();
                request.CommandName = "AutomaticTransfer";
                SendCommand(JsonConvert.SerializeObject(request), request.CommandId, CommandTypeEnum.AutomaticTransfer);
            }
            var inputResTransfer = JsonConvert.DeserializeObject<AutomaticTransferCammandResponse>(inputString);
            if (inputResTransfer != null)
            {
                HangupCommandRequest request = new HangupCommandRequest();
                request.CallId= inputResTransfer.CallId;
                request.CommandId= Guid.NewGuid().ToString();
                request.CommandName = "Hangup";
                SendCommand(JsonConvert.SerializeObject(request), request.CommandId, CommandTypeEnum.Hangup);
            }
        }

        private static void SendCommand(string request,string commandId, CommandTypeEnum commandType)
        {
            var pskToken = "YOUR_ACTUAL_TOKEN_HERE";

            using (var httpClient = new HttpClient())
            {
                var url = $"https://192.168.1.133:7200/api/CallControl/CommandManager/v1/{commandId}/{commandType}";

                var httpRequest = new HttpRequestMessage(HttpMethod.Post, url);
                httpRequest.Headers.Add("Authorization", pskToken);

                httpRequest.Content = new StringContent(request, Encoding.UTF8, "application/json");

                var response = httpClient.Send(httpRequest);

                var responseContent = response.Content.ReadAsStringAsync();
            }
        }
    }
}
