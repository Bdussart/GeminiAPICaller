using GeminiAPICaller.Core.Interface;
using GeminiAPICaller.Model.Message.Prompt;
using GeminiAPICaller.Model.Response.Prompt;
using Newtonsoft.Json;
using System.Text;
using ExceptionDispatchInfo =
    System.Runtime.ExceptionServices.ExceptionDispatchInfo;

namespace GeminiAPICaller.Core
{
    public class GeminiAPICaller : IAPICaller
    {
        private string _apiKey = string.Empty;
        private string _geminiModel = string.Empty;
        private string _url = "https://generativelanguage.googleapis.com/v1beta/models/";

        private string _completeUrl = string.Empty;

        public GeminiAPICaller(string apiKey = "", string geminiModel = "")
        {
            if (String.IsNullOrWhiteSpace(apiKey))
                _apiKey = Environment.GetEnvironmentVariable("GOOGLE_API_KEY");
            else
                _apiKey = apiKey;


            if (String.IsNullOrWhiteSpace(geminiModel))
                _geminiModel = "gemini-1.5-flash-latest";
            else
                _geminiModel = geminiModel;

            _completeUrl = $"{_url}{_geminiModel}";
        }

        async public Task<GeminiPromptResponse?> SendPromptAsync(GeminiPromptMessage message)
        {
            GeminiPromptResponse result = null;
            try
            {
                HttpClient client = new HttpClient();
                string content = Newtonsoft.Json.JsonConvert.SerializeObject(message);

                HttpResponseMessage response = await client.PostAsync($"{_completeUrl}:generateContent?key={_apiKey}", new StringContent(content, Encoding.UTF8, "application/json"));
                result = await HandleResponse<GeminiPromptResponse>(response);
            }
            catch (Exception ex)
            {
                Logger.LogHelper.LogException(ex, objectInfo: $"Url : {_completeUrl}, Message : {message}");
                ExceptionDispatchInfo.Capture(ex).Throw();

            }
            return result;
        }

        async private Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException(result);
            return JsonConvert.DeserializeObject<T>(result) ?? throw new Exception("Cannot deserialize");
        }
    }
}