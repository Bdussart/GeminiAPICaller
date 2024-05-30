using Microsoft.AspNetCore.Mvc;
using GeminiAPICaller.Model;
using GeminiAPICaller.Model.Message.Prompt;
using GeminiAPICaller.Model.Response.Prompt;
using Microsoft.AspNetCore.Mvc.ApplicationModels;


namespace GeminiAPICaller.WebService.Controllers
{
    [ApiController]
    [Route("WebService/[controller]")]
    public class GeminiAPIController : ControllerBase
    {
        private GeminiAPICaller.Core.GeminiAPICaller _caller = new GeminiAPICaller.Core.GeminiAPICaller();

      

        [HttpGet(Name = "GetGeminiAnswer")]
        public async Task<List<string>> Get([FromQuery]List<string> context, [FromQuery] string question)
        {
            GeminiPromptMessage geminiPromptBase = new GeminiPromptMessage();
            GeminiPromptResponse responses = null;
            List<string> returns = new List<string>(); 

            Content content = new Content()
            {
                Parts = new List<Part>()
            };

            Part part = new Part();

            foreach (string information in context)
            {
                part.Text = information;
                content.Parts.Add(part);
            }

            geminiPromptBase.Contents = new List<Content> { content };
            geminiPromptBase.SystemInstruction = new SystemInstruction();

            geminiPromptBase.SystemInstruction.Parts = new List<Part> { new Part
            {
                Text = question
            } };

            responses = await _caller.SendPromptAsync(geminiPromptBase);

            if(responses!=null)
                Logger.LogHelper.LogInfo("answer received");
            else
                Logger.LogHelper.LogInfo("no answer");

            foreach (Candidate candidate in responses.Candidates)
            {
                foreach (Part tempPart in candidate.Content.Parts)
                {
                    returns.Add(tempPart.Text);
                }
            }

            return returns;

        }
    }
}
