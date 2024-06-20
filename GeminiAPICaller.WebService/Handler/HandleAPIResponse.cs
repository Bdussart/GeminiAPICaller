using System.Net;

namespace GeminiAPICaller.WebService.Handler
{
    public class HandleAPIResponse<T>
    {
        public Boolean IsSuccessAPIResponse { get; set; }
        public HttpStatusCode CodeHTTPResponse { get; set; }
        public T ValueResponse { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
