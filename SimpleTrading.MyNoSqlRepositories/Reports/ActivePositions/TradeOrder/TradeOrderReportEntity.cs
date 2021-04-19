using System;
using System.Collections.Generic;
using System.Linq;
using SimpleTrading.Abstraction.BidAsk;
using SimpleTrading.Abstraction.Trading.Positions;

namespace SimpleTrading.MyNoSqlRepositories.Reports.ActivePositions.TradeOrder
{
    public class TradeOrderReportEntity : ITradeOrder
    {
        public long Id { get; set; }
        public string AccountId { get; set; }
        public string TraderId { get; set; }
        public string Instrument { get; set; }
        public double InvestmentAmount { get; set; }
        public int Leverage { get; set; }
        public DateTime Created { get; set; }
        public double DesiredPrice { get; set; }
        public double OpenPrice { get; set; }

        public double? TakeProfitInCurrency { get; set; }
        public double? StopLossInCurrency { get; set; }
        public double? TakeProfitRate { get; set; }
        public double? StopLossRate { get; set; }
        public DateTime TimeStamp { get; set; }
        public string ProcessId { get; set; }
        public DateTime OpenDate { get; set; }
        public double Volume { get; set; }
        
        public double Profit { get; set; }
        public DateTime CloseDate { get; set; }
        public double ClosePrice { get; set; }
        
        public ClosePositionReason CloseReason { get; set; }
        public BidAskEntity CloseBidAsk { get; set; }
        public BidAskEntity OpenBidAsk { get; set; }

        IBidAsk ITradeOrder.CloseBidAsk => CloseBidAsk;
        IBidAsk ITradeOrder.OpenBidAsk => OpenBidAsk;
        
        public PositionOperation Operation { get; set; }
        public PositionOrderType PositionOrderType { get; set; }
        
        IEnumerable<IPositionCommission> ITradeOrder.Commissions => Commissions;
        IEnumerable<IPositionSwap> ITradeOrder.Swaps => Swaps;
        public double ToppingUpPercent { get; set; }
        public double ReservedFundsForToppingUp { get; set;}
        public List<CommissionsEntity> Commissions { get; set; }
        public List<PositionSwapEntity> Swaps { get; set; }

        public double BurnBonus { get; set; }

        public static TradeOrderReportEntity Create(ITradeOrder src)
        {
            return new TradeOrderReportEntity
            {
                Id = src.Id,
                AccountId = src.AccountId,
                Instrument = src.Instrument,
                InvestmentAmount = src.InvestmentAmount,
                Leverage = src.Leverage,
                Created = src.Created,
                DesiredPrice = src.DesiredPrice,
                OpenPrice = src.OpenPrice,
                TakeProfitInCurrency = src.TakeProfitInCurrency,
                StopLossInCurrency = src.StopLossInCurrency,
                TakeProfitRate = src.TakeProfitRate,
                StopLossRate = src.StopLossRate,
                TimeStamp = src.TimeStamp,
                ProcessId = src.ProcessId,
                OpenDate = src.OpenDate,
                Volume = src.Volume,
                Profit = src.Profit,
                CloseDate = src.CloseDate,
                ClosePrice = src.ClosePrice,
                Operation = src.Operation,
                PositionOrderType = src.PositionOrderType,
                CloseBidAsk = BidAskEntity.Create(src.CloseBidAsk),
                OpenBidAsk = BidAskEntity.Create(src.OpenBidAsk),
                Commissions = src.Commissions.Select(CommissionsEntity.Create).ToList(),
                Swaps = src.Swaps.Select(PositionSwapEntity.Create).ToList(),
                ToppingUpPercent = src.ToppingUpPercent,
                ReservedFundsForToppingUp = src.ReservedFundsForToppingUp
            };
        }
    }
}