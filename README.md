# graphql-federation-poc

Repository contains next examples of implementations:
- GraphQL.Federation.POC.Stitching - "stitching" approach is when centrilized gateway is responsible for aggregating all schemas of subgraphs and for the instructions of how subgraphs extend gateway's schema. 
- GraphQL.Federation.POC.Federation - "classic fedaration" approach is when gateway still knows about existance of subgraphs but all the instractions of how gateway's schema will be extended located in the subgraphs themselves.
![Stitching vs federation](https://github.com/denis-actum/graphql-federation-poc/assets/108467575/e2bc4e6b-e6b6-4077-a1eb-c7d7f0fe3436)

Result of investigation proves that goal is achievable using combination of technologies:
- Platform: .NET 8
- Language: C# latest
- Application framework: Azure Functions v4
- GraphQL framework: HotChocolate 13.8.1
