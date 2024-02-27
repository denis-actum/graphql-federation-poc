using HotChocolate.AzureFunctions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace GraphQL.Federation.Persons
{
    public class PersonsFunction
    {
        private readonly ILogger _logger;

        private readonly IGraphQLRequestExecutor _executor;

        public PersonsFunction(ILoggerFactory loggerFactory, IGraphQLRequestExecutor executor)
        {
            _logger = loggerFactory.CreateLogger<PersonsFunction>();
            _executor = executor;
        }

        [Function("PersonsFunction")]
        public Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "graphql/{**slug}")] HttpRequestData request)
            => _executor.ExecuteAsync(request);
    }
}
