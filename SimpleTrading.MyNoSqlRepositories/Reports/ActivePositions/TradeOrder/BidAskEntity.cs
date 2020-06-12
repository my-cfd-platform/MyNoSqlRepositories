using System;
using SimpleTrading.Abstraction.BidAsk;

namespace SimpleTrading.MyNoSqlRepositories.Reports.ActivePositions.TradeOrder
{
    public class BidAskEntity : IBidAsk
    {
        public string Id { get; set; }
        public DateTime DateTime { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }

        public static BidAskEntity Create(IBidAsk src)
        {
            return new BidAskEntity
            {
                Id = src.Id,
                DateTime = src.DateTime,
                Bid = src.Bid,
                Ask = src.Ask
            };
        }
    }
}