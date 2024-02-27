using GreenDonut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Federation.Gateway;

//internal class DynamicDataLoaderProvider
//{
//    public DataLoaderBase
//}

public abstract class DynamicBatchDataLoader<TKey, TValue> : BatchDataLoader<TKey, TValue>
{
    private readonly string _path;

    protected DynamicBatchDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
    }

    protected override async Task<IReadOnlyDictionary<TKey, TValue>> LoadBatchAsync(
        IReadOnlyList<TKey> keys, CancellationToken cancellationToken)
    {
        // Implement your data fetching logic here.
        // This is just a placeholder implementation.
        return new Dictionary<TKey, TValue>();
    }

    private void Load()
    { 
    }
}
