# graphql-federation-poc

### Repository contains next examples of implementations:
- GraphQL.Federation.POC.Stitching - "stitching" approach is when centrilized gateway is responsible for aggregating all schemas of subgraphs and for the instructions of how subgraphs extend gateway's schema. 
- GraphQL.Federation.POC.Federation - "classic fedaration" approach is when gateway still knows about existance of subgraphs but all the instructions of how gateway's schema will be extended located in the subgraphs themselves.
![Stitching vs federation](https://github.com/denis-actum/graphql-federation-poc/assets/108467575/e2bc4e6b-e6b6-4077-a1eb-c7d7f0fe3436)

### Result of investigation proves that goal is achievable using combination of technologies:
- Platform: .NET 8
- Language: C# latest
- Application framework: Azure Functions v4
- GraphQL framework: HotChocolate 13.8.1

### Problems Found:
- To prevent N+1 problem for loading nested data from subgraphs it requires custom implementation of data loader. Todo: it will be good to have generic one.
- There are no easy access to HttpContext during Azure Function execution. Custom package or implementation is required.
- If some of the logic of your federated GraphQL APIs based on HTTP Headers it is required to implement custom HttpMessageHandler and pass original http headers to the request to subgraphs.

### Federation with schema polling and hot-reload.
- Polling is the default mechanism. When one of the subgraphs got changes and was redeployed your gateway will pull new schema from the subgraph. Subgraph will contain specific API in its schema.
- Hot reaload works a little bit differently. Subgraph doesn't provide API for fetching the schema definition. Instead subgraphs publishes the schema changes into Redis to which Gatewat is also connected.

More information about federation can be found:
- In the official documentation: https://chillicream.com/docs/hotchocolate/v13/distributed-schema/schema-federations </br>
- In the examples repository: https://github.com/ChilliCream/hotchocolate-examples/tree/master/misc/Stitching
