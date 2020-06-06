using System;
using System.Collections.Generic;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.BidAsk;
using SimpleTrading.Abstraction.Trading.Positions;

namespace SimpleTrading.MyNoSqlRepositories.Reports.ActivePositions
{
    public class ReportActivePositionMyNoSqlEntity : MyNoSqlEntity, ITradeOrder
    {
        public static string GeneratePartitionKey()
        {
            return "activepos";
        }
        
        public static string GenerateRowKey(long id)
        {
            return id.ToString();
        }

        public long Id => Convert.ToInt64(RowKey);
        
        public string AccountId { get; set; }
        public string TraderId { get; set; }
        public string Instrument { get; set; }
        public double InvestmentAmount { get; set; }
        public int Leverage { get; set; }
        public DateTime Created { get; set; }
        public double DesiredPrice { get; set; }
        public double OpenPrice { get; set; }
        public IBidAsk OpenBidAsk { get; set; }
        public PositionOperation Operation { get; set; }
        public PositionOrderType PositionOrderType { get; set; }
        public double? TakeProfitInCurrency { get; set; }
        public double? StopLossInCurrency { get; set; }
        public double? TakeProfitRate { get; set; }
        public double? StopLossRate { get; set; }
        public string ProcessId { get; set; }
        public DateTime OpenDate { get; set; }
        public double Volume { get; set; }
        public IEnumerable<IPositionCommission> Commissions { get; set; }
        public IEnumerable<IPositionSwap> Swaps { get; set; }
        public double Profit { get; set; }
        public DateTime CloseDate { get; set; }
        public ClosePositionReason CloseReason { get; set; }
        public double ClosePrice { get; set; }
        public IBidAsk CloseBidAsk { get; set; }

        public static ReportActivePositionMyNoSqlEntity Create(ITradeOrder src)
        {
            return new ReportActivePositionMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(src.Id),
                AccountId = src.AccountId,
                TraderId = src.TraderId,
                Instrument = src.Instrument,
                InvestmentAmount = src.InvestmentAmount,
                Leverage = src.Leverage,
                Created = src.Created,
                DesiredPrice = src.DesiredPrice,
                OpenPrice = src.OpenPrice,
                OpenBidAsk = src.OpenBidAsk,
                Operation = src.Operation,
                PositionOrderType = src.PositionOrderType,
                TakeProfitInCurrency = src.TakeProfitInCurrency,
                StopLossInCurrency = src.StopLossInCurrency,
                TakeProfitRate = src.TakeProfitRate,
                StopLossRate = src.StopLossRate,
                ProcessId = src.ProcessId,
                OpenDate = src.OpenDate,
                Volume = src.Volume,
                Commissions = src.Commissions,
                Swaps = src.Swaps,
                Profit = src.Profit,
                CloseDate = src.CloseDate,
                CloseReason = src.CloseReason,
                ClosePrice = src.ClosePrice,
                CloseBidAsk = src.CloseBidAsk
            };
        }
    }
}