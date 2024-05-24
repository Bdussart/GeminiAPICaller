using GeminiAPICaller.Model.Message.Prompt;
using GeminiAPICaller.Model.Response.Prompt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiAPICaller.Core.Interface
{
    public interface IAPICaller
    {
        public Task<GeminiPromptResponse> SendPromptAsync(GeminiPromptMessage message);
    }
}
