//using GraphQL.Client.Http;
//using GraphQL.Client.Serializer.SystemTextJson;
//using GreenDonut;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GraphQL.Federation.Gateway.DataLoaders
//{
//    internal class GenericDataLoader : BatchDataLoader<int, object>
//    {
//        private string? _query = null;

//        public GenericDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions? options = null) : base(batchScheduler, options)
//        {
//        }

//        public void Initialize(string query)
//        {
//            _query = query;
//        }

//        protected override Task<IReadOnlyDictionary<int, object>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
//        {
//            var client = new GraphQLHttpClient("https://api.example.com/graphql", new SystemTextJsonSerializer());

//            var reqest = new GraphQLRequest
//            {
//                Query = _query,
//                Variables = new { ids = keys }
//            };

//            var response = client.SendQueryAsync<object>(reqest);


//        }
//    }
//}
