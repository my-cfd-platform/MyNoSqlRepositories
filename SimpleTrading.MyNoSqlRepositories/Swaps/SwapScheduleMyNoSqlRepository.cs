using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using MyNoSqlClient;
using SimpleTrading.Abstraction.Trading.Swaps;

namespace SimpleTrading.MyNoSqlRepositories.Swaps
{
    public class SwapScheduleMyNoSqlRepository : ISwapScheduleWriter
    {
        private readonly IMyNoSqlServerClient<SwapScheduleMyNoSqlEntity> _client;

        public SwapScheduleMyNoSqlRepository(IMyNoSqlServerClient<SwapScheduleMyNoSqlEntity> client)
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

        public async Task DeleteAsync(string scheduleId, DayOfWeek dayOfWeek, string time)
        {
            var partitionKey = SwapScheduleMyNoSqlEntity.GeneratePartitionKey(scheduleId);
            var rowKey = SwapScheduleMyNoSqlEntity.GenerateRowKey(dayOfWeek, TimeSpan.Parse(time));
            await _client.DeleteAsync(partitionKey, rowKey);
        }
    }
}