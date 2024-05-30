using Microsoft.AspNetCore.Mvc;
using GeminiAPICaller.Model;
using GeminiAPICaller.Model.Message.Prompt;
using GeminiAPICaller.Model.Response.Prompt;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.VisualBasic;


namespace GeminiAPICaller.WebService.Controllers
{
    [ApiController]
    [Route("WebService/[controller]")]
    public class GeminiAPIController : ControllerBase
    {
        private GeminiAPICaller.Core.GeminiAPICaller _caller = new GeminiAPICaller.Core.GeminiAPICaller();

        [HttpGet(Name = "GetGeminiAnswer")]
        public async Task<string> Get([FromQuery]string informations, [FromQuery] string context)
        {
            GeminiPromptMessage geminiPromptBase = new GeminiPromptMessage();
            GeminiPromptResponse responses = null;
            string returns = "";
            string[] information = null;

            Content content = new Content()
            {
                Parts = new List<Part>()
            };
            Part part = new Part();

            information = informations.Split('/');

            foreach (string info in information)
            {
                part.Text = info;
                content.Parts.Add(part);
            }

            geminiPromptBase.Contents = new List<Content> { content };
            geminiPromptBase.SystemInstruction = new SystemInstruction();

            geminiPromptBase.SystemInstruction.Parts = new List<Part> { new Part
            {
                Text = context
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
                    returns+="\n"+tempPart.Text;
                }
            }

            return returns;

        }
    }
}
