using Microsoft.AspNetCore.Mvc;
using GeminiAPICaller.Model;
using GeminiAPICaller.Model.Message.Prompt;
using GeminiAPICaller.Model.Response.Prompt;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using GeminiAPICaller.WebService.Wrapper;
using Microsoft.VisualBasic;
using GeminiAPICaller.WebService.Handler;
using Microsoft.AspNetCore.Http;
using GeminiAPICaller.WebService.Model;


namespace GeminiAPICaller.WebService.Controllers
{
    [ApiController]
    [Route("WebService/[controller]")]
    public class GeminiAPIController : ControllerBase
    {
        private GeminiAPICaller.Core.GeminiAPICaller _caller = new GeminiAPICaller.Core.GeminiAPICaller();
        private PromptToAPIWrapper _promptToAPIWrapper = new PromptToAPIWrapper();

        [HttpGet(Name = "GetGeminiAnswer")]
        public async Task<ObjectResult> Get(string informations, string context)
        {
            HandleAPIResponse<GeminiPromptResponse> handleAPIResponse = await _promptToAPIWrapper.PromptAPIWrapper(informations, context);
            APIToPromptWrapper aPIToPromptWrapper = new APIToPromptWrapper();
            return StatusCode((int)handleAPIResponse.CodeHTTPResponse,aPIToPromptWrapper.APIPromptWrapper(handleAPIResponse));
        }


        [HttpPost(Name = "PromptToGemini")]
        public async Task<ObjectResult> PromptToGemini([FromBody] GeminiPromptData data)
        {
            HandleAPIResponse<GeminiPromptResponse> handleAPIResponse = await _promptToAPIWrapper.PromptAPIWrapper(data.Informations, data.Context);
            APIToPromptWrapper aPIToPromptWrapper = new APIToPromptWrapper();
            return StatusCode((int)handleAPIResponse.CodeHTTPResponse, aPIToPromptWrapper.APIPromptWrapper(handleAPIResponse));
        }
    }
}
