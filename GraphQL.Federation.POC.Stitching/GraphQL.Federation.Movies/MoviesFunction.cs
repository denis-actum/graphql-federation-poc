using HotChocolate.AzureFunctions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace GraphQL.Federation.Movies
{
    public class MoviesFunction
    {
        private readonly ILogger _logger;

        private readonly IGraphQLRequestExecutor _executor;

        public MoviesFunction(ILoggerFactory loggerFactory, IGraphQLRequestExecutor executor)
        {
            _logger = loggerFactory.CreateLogger<MoviesFunction>();
            _executor = executor;
        }

        [Function("MoviesFunction")]
        public Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "graphql/{**slug}")] HttpRequestData request)
            => _executor.ExecuteAsync(request);
    }
}
