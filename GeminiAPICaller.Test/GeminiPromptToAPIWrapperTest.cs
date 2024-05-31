using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeminiAPICaller.Model.Response.Prompt;
using GeminiAPICaller.WebService.Handler;
using GeminiAPICaller.WebService.Wrapper;
using System.Net;

namespace GeminiAPICaller.Test
{
    [TestClass]
    public class GeminiPromptToAPIWrapperTest
    {
        private PromptToAPIWrapper _promptToAPIWrapper = new PromptToAPIWrapper();

        [TestMethod]
        public async Task Test_Prompt_To_API_Wrapper_success()
        {
            HandleAPIResponse<GeminiPromptResponse> handleAPIResponse = null;
            string informations = "aaaaaaa";
            string context = "bbbbbb";
            handleAPIResponse = await _promptToAPIWrapper.PromptAPIWrapper(informations, context);

            Assert.IsTrue(handleAPIResponse.IsSuccessAPIResponse);
            Assert.AreEqual(HttpStatusCode.OK, handleAPIResponse.CodeHTTPResponse);
            Assert.IsNotNull(handleAPIResponse.ValueResponse);
        }

        [TestMethod]
        public async Task Test_Prompt_To_API_Wrapper_error()
        {
            HandleAPIResponse<GeminiPromptResponse> handleAPIResponse = null;
            string informations = String.Empty;
            string context = String.Empty;
            handleAPIResponse = await _promptToAPIWrapper.PromptAPIWrapper(informations, context);

            Assert.IsFalse(handleAPIResponse.IsSuccessAPIResponse);
            Assert.AreEqual(HttpStatusCode.BadRequest, handleAPIResponse.CodeHTTPResponse);
            Assert.IsNull(handleAPIResponse.ValueResponse);
        }

    }
}
