using GeminiAPICaller.Model;
using GeminiAPICaller.Model.Response.Prompt;
using GeminiAPICaller.WebService.Handler;
using System.Net;
namespace GeminiAPICaller.WebService.Wrapper
{
    public class APIToPromptWrapper
    {
        public string APIPromptWrapper(HandleAPIResponse<GeminiPromptResponse> response)
        {
            string returns = string.Empty;
            if (response.IsSuccessAPIResponse)
            {
                returns = string.Join("\n", response.ValueResponse.Candidates.SelectMany(canditate => canditate.Content.Parts).Select(part => part.Text));
            }
            else
            {
                returns = response.ErrorMessage;
            }
            return returns;
        }


    }
}
