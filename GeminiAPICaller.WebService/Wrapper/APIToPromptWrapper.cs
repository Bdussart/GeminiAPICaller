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
                switch (response.CodeHTTPResponse)
                {
                    case HttpStatusCode.BadRequest: returns += "Error 400 : "; break;
                    case HttpStatusCode.Forbidden: returns += "Error 403 : "; break;
                    case HttpStatusCode.Unauthorized: returns += "Error 401 : "; break;
                    case HttpStatusCode.PaymentRequired: returns += "Error 402 : "; break;
                    case HttpStatusCode.NotFound: returns += "Error 404 : "; break;
                }
                returns += response.CodeHTTPResponse.ToString();            }
            return returns;
        }
            
    }
}
