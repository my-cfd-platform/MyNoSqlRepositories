using System;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Payments.Abstractions.DepositRestrictions;

namespace SimpleTrading.MyNoSqlRepositories.Deposits
{
    public class DepositRestrictionNoSqlEntity : MyNoSqlDbEntity, IDepositRestriction
    {
        public DepositRestrictionNoSqlEntity()
        {
        }

        public DepositRestrictionNoSqlEntity(IDepositRestriction src)
        {
            RowKey = GenerateRowKey(src.TraderId);
            PartitionKey = GeneratePartitionKey();
            TraderId = src.TraderId;
            Restrictions = src.Restrictions;
        }

        public static string GeneratePartitionKey()
        {
            return "deposit-restrictions";
        }

        public static string GenerateRowKey(string traderId)
        {
            return traderId;
        }

        public string TraderId { get; set; }
        public DepositRestrictions Restrictions { get; set; }
    }
}