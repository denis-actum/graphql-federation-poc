using HotChocolate.AzureFunctions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace GraphQL.Federation.Gateway
{
    public class GatewayFunction
    {
        private readonly ILogger _logger;

        private readonly IGraphQLRequestExecutor _executor;

        public GatewayFunction(ILoggerFactory loggerFactory, IGraphQLRequestExecutor executor)
        {
            _logger = loggerFactory.CreateLogger<GatewayFunction>();
            _executor = executor;
        }

        [Function("GatewayFunction")]
        public Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "graphql/{**slug}")] HttpRequestData request)
            => _executor.ExecuteAsync(request);
    }
}
