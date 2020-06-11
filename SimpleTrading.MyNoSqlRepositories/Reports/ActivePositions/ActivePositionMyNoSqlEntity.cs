using System;
using System.Collections.Generic;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Reports.ActivePositions;
using SimpleTrading.Abstraction.Trading.Positions;

namespace SimpleTrading.MyNoSqlRepositories.Reports.ActivePositions
{
    public class ReportActivePositionMyNoSqlEntity : MyNoSqlDbEntity, IActivePositionsSnapshot
    {
        public static string GeneratePartitionKey()
        {
            return "activepos";
        }
        
        public static string GenerateRowKey(string accountId)
        {
            return accountId;
        }
        
        public string AccountId => RowKey;

        public string TraderId { get; set; }
        
        public DateTime DateTime { get; set; }
        
        public IEnumerable<ITradeOrder> ActivePositions { get; set; }

        public static ReportActivePositionMyNoSqlEntity Create(IActivePositionsSnapshot src)
        {
            return new ReportActivePositionMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(src.AccountId),
                TraderId = src.TraderId,
                DateTime = src.DateTime,
                ActivePositions = src.ActivePositions
            };
        }
    }
}