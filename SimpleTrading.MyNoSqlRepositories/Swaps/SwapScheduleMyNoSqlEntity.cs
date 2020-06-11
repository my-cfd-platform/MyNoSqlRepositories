using System;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading.Swaps;

namespace SimpleTrading.MyNoSqlRepositories.Swaps
{
    public class SwapScheduleMyNoSqlEntity : MyNoSqlEntity, ISwapSchedule
    {

        public static string GeneratePartitionKey(string id)
        {
            return id;
        }

        public static string GenerateRowKey(DayOfWeek dayOfWeek, TimeSpan time)
        {
            return SwapScheduleMappers.SwapMomentToString(dayOfWeek, time);
        }
        
        
        public string Id => PartitionKey;
        public DayOfWeek DayOfWeek => RowKey.GetDayOfWeekFromRowKey();
        public TimeSpan Time { get; set; }
        public int Amount { get; set; }

        public static SwapScheduleMyNoSqlEntity Create(ISwapSchedule src)
        {
            return new SwapScheduleMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(src.Id),
                RowKey = GenerateRowKey(src.DayOfWeek, src.Time),
                Amount = src.Amount,
                Time = src.Time
            };
        }
        
    }
}