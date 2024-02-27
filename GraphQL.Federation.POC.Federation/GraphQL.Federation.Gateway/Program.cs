using GraphQL.Federation.Gateway;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .AddGraphQLFunction(x => 
    {
        x.AddQueryType(d => d.Name("Query"));
        x.AddRemoteSchema("movies", ignoreRootTypes: true);
        x.AddRemoteSchema("persons", ignoreRootTypes: true);
    })
    .ConfigureServices(services =>
    {
        services.AddScoped<CustomMessageHandler>();
        services.AddHttpClient("movies", c => c.BaseAddress = new Uri("http://localhost:7187/api/graphql"));
        services.AddHttpClient("persons", c => c.BaseAddress = new Uri("http://localhost:7165/api/graphql"))
                .AddHttpMessageHandler<CustomMessageHandler>();
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();
