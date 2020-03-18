using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.TcpClient;
using SimpleTrading.Abstraction.Trading.Swaps;

namespace SimpleTrading.MyNoSqlRepositories.Swaps
{
    public class SwapProfileMyNoSqlWriter : ISwapProfileWriter
    {
        private readonly IMyNoSqlServerClient<SwapProfileMyNoSqlEntity> _myNoSqlTable;

        public SwapProfileMyNoSqlWriter(IMyNoSqlServerClient<SwapProfileMyNoSqlEntity> myNoSqlTable)
        {
            _myNoSqlTable = myNoSqlTable;
        }


        public async ValueTask<IEnumerable<ISwapProfile>> GetAllAsync()
        {
            return await _myNoSqlTable.GetAsync();
        }

        public async ValueTask<IEnumerable<ISwapProfile>> GetAsync(string id)
        {
            var partitionKey = SwapProfileMyNoSqlEntity.GeneratePartitionKey(id);
            return await _myNoSqlTable.GetAsync(partitionKey);
        }

        public ValueTask AddOrUpdate(ISwapProfile swapProfile)
        {
            var entity = SwapProfileMyNoSqlEntity.Create(swapProfile);
            return new ValueTask(_myNoSqlTable.InsertOrReplaceAsync(entity));
        }

        public ValueTask DeleteAsync(string id, string instrumentId)
        {
            var partitionKey = SwapProfileMyNoSqlEntity.GeneratePartitionKey(id);
            var rowKey = SwapProfileMyNoSqlEntity.GenerateRowKey(instrumentId);
            return new ValueTask(_myNoSqlTable.DeleteAsync(partitionKey, rowKey));
        }
    }
}