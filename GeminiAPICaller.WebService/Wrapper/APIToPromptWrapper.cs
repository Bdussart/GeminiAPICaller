using GeminiAPICaller.Model;
using GeminiAPICaller.Model.Response.Prompt;
using GeminiAPICaller.WebService.Handler;
namespace GeminiAPICaller.WebService.Wrapper
{
    public class APIToPromptWrapper
    {
        public string APIPromptWrapper(HandleAPIResponse<GeminiPromptResponse> response)
        {
            string returns = String.Empty;
            if (response.IsSuccessAPIResponse)
            {
                foreach (Candidate candidate in response.ValueResponse.Candidates)
                {
                    foreach(Part part in candidate.Content.Parts)
                    {
                        returns += '\n' + part.Text;                        
                    }
                }
            }
            else
            {
                returns = response.CodeHTTPResponse.ToString();
            }
            return returns;
        }
            
    }
}
