using System;
using SimpleTrading.Abstraction.Trading.Positions;

namespace SimpleTrading.MyNoSqlRepositories.Reports.ActivePositions.TradeOrder
{
    public class CommissionsEntity : IPositionCommission
    {
        public DateTime DateTime { get; set; }
        
        public PositionCommissionType CommissionType { get; set; }
        
        public double Amount { get; set; }

        public static CommissionsEntity Create(IPositionCommission src)
        {
            return new CommissionsEntity
            {
                DateTime = src.DateTime,
                CommissionType = src.CommissionType,
                Amount = src.Amount
            };
        }
    }
}