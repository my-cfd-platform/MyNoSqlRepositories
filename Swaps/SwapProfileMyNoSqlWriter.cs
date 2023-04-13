using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading.Swaps;

namespace MyNoSqlRepositories.Swaps;

public class SwapProfileMyNoSqlWriter : ISwapProfileWriter
{
    private readonly IMyNoSqlServerDataWriter<SwapProfileMyNoSqlEntity> _myNoSqlTable;

    public SwapProfileMyNoSqlWriter(IMyNoSqlServerDataWriter<SwapProfileMyNoSqlEntity> myNoSqlTable)
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

    public async ValueTask AddOrUpdate(ISwapProfile swapProfile)
    {
        var entity = SwapProfileMyNoSqlEntity.Create(swapProfile);
        await _myNoSqlTable.InsertOrReplaceAsync(entity);
    }

    public async ValueTask DeleteAsync(string id, string instrumentId)
    {
        var partitionKey = SwapProfileMyNoSqlEntity.GeneratePartitionKey(id);
        var rowKey = SwapProfileMyNoSqlEntity.GenerateRowKey(instrumentId);
        await _myNoSqlTable.DeleteAsync(partitionKey, rowKey);
    }
}