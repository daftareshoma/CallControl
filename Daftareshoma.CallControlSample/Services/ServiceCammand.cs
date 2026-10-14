using Daftareshoma.CallControlSample.Models;
using Newtonsoft.Json;
using System.Text;

namespace Daftareshoma.CallControlSample.Services
{
    public interface IServiceCammand
    {
        Task SendCommandPlayVoice(string callId);
        Task SendCommandPlayText(string callId);
        Task SendCommandAutomaticTransfer(string callId);
        Task SendCommandGather(string callId);
        Task SendCommandQueue(string callId);
        Task SendCommandFax(string callId);
        Task SendCommandRecord(string callId);
        Task SendCommandVoiceMail(string callId);
        Task SendCommandHangup(string callId);
    }
    public class ServiceCammand : IServiceCammand
    {
        private readonly CallControlSettings _callControlSettings;
        public ServiceCammand(CallControlSettings callControlSettings)
        {
            _callControlSettings = callControlSettings;
        }
        public async Task SendCommandPlayVoice(string callId)
        {
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    PlayVoiceCommandRequest playVoiceCommand = new PlayVoiceCommandRequest();
                    playVoiceCommand.CommandId = Guid.NewGuid().ToString();
                    playVoiceCommand.CommandName = "Play_Audio";
                    playVoiceCommand.Url = "https://cdn.daftareshoma.com/AZM:moh/2023/5/MusicOnHold/64624796c34ec745b4baacbe.wav";
                    playVoiceCommand.CallId = callId;
                    var requestModel = JsonConvert.SerializeObject(playVoiceCommand);
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{_callControlSettings.BaseUrl}/api/CallControl/CommandManager/v1/{playVoiceCommand.CommandId}/{CommandTypeEnum.Play_Audio}");
                    request.Headers.Add("Authorization", _callControlSettings.Token);
                    request.Content = new StringContent(requestModel, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                   
                }
                catch (HttpRequestException e)
                {
                    throw new Exception($"Request error: {e.Message}");
                }
            }
        }
        public async Task SendCommandPlayText(string callId)
        {
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    PlayTextCommandRequest playTextCommand = new PlayTextCommandRequest();
                    playTextCommand.CommandId = Guid.NewGuid().ToString();
                    playTextCommand.CommandName = "Play_Text";
                    playTextCommand.CallId = callId;
                    playTextCommand.Text = "سلام";
                    playTextCommand.Voice = "Armin";
                    var requestModel = JsonConvert.SerializeObject(playTextCommand);
               
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{_callControlSettings.BaseUrl}/api/CallControl/CommandManager/v1/{playTextCommand.CommandId}/{CommandTypeEnum.Play_Text}");
                    request.Headers.Add("Authorization", _callControlSettings.Token);
                    request.Content = new StringContent(requestModel, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                }
                catch (HttpRequestException e)
                {
                    throw new Exception($"Request error: {e.Message}");
                }
            }
            
        }
        public async Task SendCommandAutomaticTransfer(string callId)
        {
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    AutomaticTransferCammandRequest automaticTransferCommand = new AutomaticTransferCammandRequest();
                    automaticTransferCommand.CommandId = Guid.NewGuid().ToString();
                    automaticTransferCommand.CommandName = "AutomaticTransfer";
                    automaticTransferCommand.CallId = callId;
                    automaticTransferCommand.Numbers = new List<Number>();
                    Number number = new Number();
                    number.RingTimeout = 40;
                    number.To = "09191111111";
                    automaticTransferCommand.Numbers.Add(number);
                    Number number1 = new Number();
                    number1.RingTimeout = 40;
                    number1.To = "09362222222";
                    automaticTransferCommand.Numbers.Add(number1);
                    automaticTransferCommand.MusicOnHold = "https://cdn.daftareshoma.com/AZM:moh/2023/5/MusicOnHold/64624796c34ec745b4baacbe.wav";

                    var requestModel = JsonConvert.SerializeObject(automaticTransferCommand);
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{_callControlSettings.BaseUrl}/api/CallControl/CommandManager/v1/{automaticTransferCommand.CommandId}/{CommandTypeEnum.AutomaticTransfer}");
                    request.Headers.Add("Authorization", _callControlSettings.Token);
                    request.Content = new StringContent(requestModel, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                }
                catch (HttpRequestException e)
                {
                    throw new Exception($"Request error: {e.Message}");
                }
            }
        }
        public async Task SendCommandGather(string callId)
        {
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    GatherCammandRequest requestBody = new GatherCammandRequest();
                    requestBody.CommandId = Guid.NewGuid().ToString();
                    requestBody.CommandName = "Gather";
                    requestBody.CallId = callId;
                    requestBody.Text = "\"Press 1 for sales.";
                    requestBody.FinishOnkey = "#";
                    requestBody.Timeout = 15000;
                    requestBody.NumDigits = 5;
                    requestBody.Input = "dtmf";
                    var requestModel = JsonConvert.SerializeObject(requestBody);
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{_callControlSettings.BaseUrl}/api/CallControl/CommandManager/v1/{requestBody.CommandId}/{CommandTypeEnum.Gather}");
                    request.Headers.Add("Authorization", _callControlSettings.Token);
                    request.Content = new StringContent(requestModel, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                }
                catch (HttpRequestException e)
                {
                    throw new Exception($"Request error: {e.Message}");
                }
            }
        }
        public async Task SendCommandQueue(string callId)
        {
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    QueueCommandRequest requestBody = new QueueCommandRequest();
                    requestBody.CommandId = Guid.NewGuid().ToString();
                    requestBody.CommandName = "Queue";
                    requestBody.CallId = callId;
                    requestBody.QueueId = Guid.NewGuid();
                    var requestModel = JsonConvert.SerializeObject(requestBody);
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{_callControlSettings.BaseUrl}/api/CallControl/CommandManager/v1/{requestBody.CommandId}/{CommandTypeEnum.Queue}");
                    request.Headers.Add("Authorization", _callControlSettings.Token);
                    request.Content = new StringContent(requestModel, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                }
                catch (HttpRequestException e)
                {
                    throw new Exception($"Request error: {e.Message}");
                }
            }
        }
        public async Task SendCommandRecord(string callId)
        {
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    HangupCommandRequest requestBody = new HangupCommandRequest();
                    requestBody.CommandId = Guid.NewGuid().ToString();
                    requestBody.CommandName = "Record";
                    requestBody.CallId = callId;
                    var requestModel = JsonConvert.SerializeObject(requestBody);
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{_callControlSettings.BaseUrl}/api/CallControl/CommandManager/v1/{requestBody.CommandId}/{CommandTypeEnum.Record}");
                    request.Headers.Add("Authorization", _callControlSettings.Token);
                    request.Content = new StringContent(requestModel, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                }
                catch (HttpRequestException e)
                {
                    throw new Exception($"Request error: {e.Message}");
                }
            }
        }
        public async Task SendCommandFax(string callId)
        {
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    FaxCommandRequest requestBody = new FaxCommandRequest();
                    requestBody.CommandId = Guid.NewGuid().ToString();
                    requestBody.CommandName = "Fax";
                    requestBody.CallId = callId;
                    var requestModel = JsonConvert.SerializeObject(requestBody);
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{_callControlSettings.BaseUrl}/api/CallControl/CommandManager/v1/{requestBody.CommandId}/{CommandTypeEnum.Fax}");
                    request.Headers.Add("Authorization", _callControlSettings.Token);
                    request.Content = new StringContent(requestModel, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                }
                catch (HttpRequestException e)
                {
                    throw new Exception($"Request error: {e.Message}");
                }
            }
        }
        public async Task SendCommandVoiceMail(string callId)
        {
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    VoiceMailCommandRequest requestBody = new VoiceMailCommandRequest();
                    requestBody.CommandId = Guid.NewGuid().ToString();
                    requestBody.CommandName = "VoiceMail";
                    requestBody.CallId = callId;
                    var requestModel = JsonConvert.SerializeObject(requestBody);
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{_callControlSettings.BaseUrl}/api/CallControl/CommandManager/v1/{requestBody.CommandId}/{CommandTypeEnum.VoiceMail}");
                    request.Headers.Add("Authorization", _callControlSettings.Token);
                    request.Content = new StringContent(requestModel, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                }
                catch (HttpRequestException e)
                {
                    throw new Exception($"Request error: {e.Message}");
                }
            }
        }
        public async Task SendCommandHangup(string callId)
        {
            using (HttpClient client = new HttpClient())
            {

                try
                {
                    HangupCommandRequest requestBody = new HangupCommandRequest();
                    requestBody.CommandId = Guid.NewGuid().ToString();
                    requestBody.CommandName = "Hangup";
                    requestBody.CallId = callId;
                    var requestModel = JsonConvert.SerializeObject(requestBody);
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{_callControlSettings.BaseUrl}/api/CallControl/CommandManager/v1/{requestBody.CommandId}/{CommandTypeEnum.Hangup}");
                    request.Headers.Add("Authorization", _callControlSettings.Token);
                    request.Content = new StringContent(requestModel, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                }
                catch (HttpRequestException e)
                {
                    throw new Exception($"Request error: {e.Message}");
                }
            }
        }
    }
}
