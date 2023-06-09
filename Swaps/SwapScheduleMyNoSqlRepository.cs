using DotNetCoreDecorators;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading.Swaps;

namespace MyNoSqlRepositories.Swaps;

public class SwapScheduleMyNoSqlRepository : ISwapScheduleWriter
{
    private readonly IMyNoSqlServerDataWriter<SwapScheduleMyNoSqlEntity> _client;

    public SwapScheduleMyNoSqlRepository(IMyNoSqlServerDataWriter<SwapScheduleMyNoSqlEntity> client)
    {
        _client = client;
    }
        
    public async Task<IReadOnlyList<ISwapSchedule>> GetAllAsync()
    {
        return (await _client.GetAsync()).AsReadOnlyList();
    }

    public async Task<IReadOnlyList<ISwapSchedule>> GetAllAsync(string id)
    {
        var partitionKey = SwapScheduleMyNoSqlEntity.GeneratePartitionKey(id);
        return (await _client.GetAsync(partitionKey)).AsReadOnlyList();
    }

    public async Task AddOrUpdateAsync(ISwapSchedule itm)
    {
        var entity = SwapScheduleMyNoSqlEntity.Create(itm);
        await _client.InsertOrReplaceAsync(entity);
    }

    public async Task DeleteAsync(string scheduleId, DayOfWeek dayOfWeek, TimeSpan time)
    {
        var partitionKey = SwapScheduleMyNoSqlEntity.GeneratePartitionKey(scheduleId);
        var rowKey = SwapScheduleMyNoSqlEntity.GenerateRowKey(dayOfWeek, time);
        await _client.DeleteAsync(partitionKey, rowKey);
    }
}