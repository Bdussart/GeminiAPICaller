using Microsoft.AspNetCore.Mvc;
using GeminiAPICaller.Model;
using GeminiAPICaller.Model.Message.Prompt;
using GeminiAPICaller.Model.Response.Prompt;


namespace GeminiAPICaller.WebService.Controllers
{
    [ApiController]
    [Route("WebService/[controller]")]
    public class GeminiAPIController : ControllerBase
    {
        private GeminiAPICaller.Core.GeminiAPICaller _caller = new GeminiAPICaller.Core.GeminiAPICaller();

      

        [HttpGet(Name = "GetGeminiAnswer")]
        public async Task<GeminiPromptResponse> Get([FromQuery]List<Part> informations, [FromQuery] string question)
        {
            GeminiPromptMessage geminiPromptBase = new GeminiPromptMessage();
            GeminiPromptResponse reponse = null;

            Content content = new Content()
            {
                Parts = new List<Part>()
            };

            content.Parts = new List<Part>(informations);

            geminiPromptBase.Contents = new List<Content> { content };
            geminiPromptBase.SystemInstruction = new SystemInstruction();

            geminiPromptBase.SystemInstruction.Parts = new List<Part> { new Part
            {
                Text = question
            } };

            reponse = await _caller.SendPromptAsync(geminiPromptBase);

            if(reponse!=null)
                Logger.LogHelper.LogInfo("answer received");
            else
                Logger.LogHelper.LogInfo("no answer");

            return reponse;

        }
    }
}
