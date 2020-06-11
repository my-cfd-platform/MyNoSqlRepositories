using System;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Accounts;

namespace SimpleTrading.MyNoSqlRepositories.Cache.AccountsCache
{
    public class AccountsCacheNoSqlEntity : MyNoSqlDbEntity, ITradingAccount
    {
        public static string GeneratePartitionKey(string traderId)
        {
            return traderId;
        }

        public static string GenerateRowKey(string accountId)
        {
            return accountId;
        }

        public string Id { get; set; }
        public string TraderId { get; set; }
        public string Currency { get; set; }
        public double Balance { get; set; }
        public double Bonus { get; set; }
        public string TradingGroup { get; set; }
        public string SwapGroup { get; set; }
        public string MarkupGroup { get; set; }
        public string CommissionGroup { get; set; }
        public string ExecutionGroup { get; set; }
        public string LeverageGroup { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        public DateTime TimeStamp { get; set; }
        public bool TradingDisabled { get; set; }

        public static AccountsCacheNoSqlEntity Create(ITradingAccount src)
        {
            return new AccountsCacheNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(src.TraderId),
                RowKey = GenerateRowKey(src.Id),
                Id = src.Id,
                Balance = src.Balance,
                Bonus = src.Bonus,
                Currency = src.Currency,
                TradingGroup = src.TradingGroup,
                SwapGroup = src.SwapGroup,
                MarkupGroup = src.MarkupGroup,
                CommissionGroup = src.CommissionGroup,
                ExecutionGroup = src.ExecutionGroup,
                LeverageGroup = src.LeverageGroup,
                TraderId = src.TraderId,
                TradingDisabled = src.TradingDisabled
            };
        }
    }
}