using GeminiAPICaller.Model.Message.Prompt;
using GeminiAPICaller.Model.Response.Prompt;
using GeminiAPICaller.Model;
using GeminiAPICaller.WebService.Handler;
using Microsoft.VisualBasic;
using System.Net;

namespace GeminiAPICaller.WebService.Wrapper
{
    public class PromptToAPIWrapper
    {
        private GeminiAPICaller.Core.GeminiAPICaller _caller = new GeminiAPICaller.Core.GeminiAPICaller();
        
        public async Task<HandleAPIResponse<GeminiPromptResponse>> PromptAPIWrapper(string informations, string context)
        {
            HandleAPIResponse<GeminiPromptResponse> handleAPIResponse = null;
            GeminiPromptMessage geminiPromptBase = new GeminiPromptMessage();
            GeminiPromptResponse responses = null;
            string returns = "";
            string[] information = null;

            Content content = new Content()
            {
                Parts = new List<Part>()
            };
            Part part = new Part();

            part.Text = informations;
            content.Parts.Add(part);
     
            geminiPromptBase.Contents = new List<Content> { content };
            geminiPromptBase.SystemInstruction = new SystemInstruction();

            geminiPromptBase.SystemInstruction.Parts = new List<Part> { new Part
            {
                Text = context
            } };

            try
            {
                responses = await _caller.SendPromptAsync(geminiPromptBase);
                handleAPIResponse.IsSuccessAPIResponse=true;
                handleAPIResponse.CodeHTTPResponse = HttpStatusCode.OK;
                handleAPIResponse.ValueResponse = responses;
            }
            catch (Exception ex)
            {
                handleAPIResponse.IsSuccessAPIResponse = false;
                handleAPIResponse.CodeHTTPResponse = HttpStatusCode.BadRequest;
                handleAPIResponse.ValueResponse = null;
            }

            return handleAPIResponse;

        }

    }
}
