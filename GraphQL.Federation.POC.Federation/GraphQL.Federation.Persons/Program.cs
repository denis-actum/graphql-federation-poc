using GraphQL.Federation.Persons;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .AddGraphQLFunction(x => x.AddQueryType<Query>()
                              .PublishSchemaDefinition(c => c
                                .SetName("persons")
                                .IgnoreRootTypes()
                                .AddTypeExtensionsFromFile("./Stitching.graphql")))
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();
