using GraphQL.Federation.Movies;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .AddGraphQLFunction(x => x.AddQueryType<Query>()
                              .PublishSchemaDefinition(c => c
                                .SetName("movies")
                                .IgnoreRootTypes()
                                .AddTypeExtensionsFromFile("./Stitching.graphql")))
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();     
    })
    .Build();

host.Run();
