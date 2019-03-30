using DocumentManagementLogger;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentManagementAPIs
{
    public class LogRequestAndResponseHandler : DelegatingHandler
    {
        private readonly ILogger logger;
        public LogRequestAndResponseHandler(ILogger logger)
        {
            this.logger = logger;
        }
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // log request body
            //string requestBody = await request.Content.ReadAsStringAsync();
            logger.AddInformationLog($"Request: {request}");

            // let other handlers process the request
            HttpResponseMessage result = await base.SendAsync(request, cancellationToken);

            // once response body is ready, log it
            //var responseBody = await result.Content.ReadAsStringAsync();
            logger.AddInformationLog($"Response: {result}");

            return result;
        }
    }
}