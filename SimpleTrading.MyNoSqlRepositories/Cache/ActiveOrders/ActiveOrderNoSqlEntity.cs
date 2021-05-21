using System;
using System.Collections.Generic;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.BidAsk;
using SimpleTrading.Abstraction.Trading.Positions;

namespace SimpleTrading.MyNoSqlRepositories.Cache.ActiveOrders
{
    public class ActiveOrderMyNoSqlEntity : MyNoSqlDbEntity, ITradeOrder
    {
        public static string GeneratePartitionKey(string traderId)
        {
            return traderId;
        }

        public static string GenerateRowKey(long positionId)
        {
            return positionId.ToString();
        }
        
        public long Id { get; set;}
        public string AccountId { get; set;}
        public string TraderId { get; set;}
        public string Instrument { get; set;}
        public double InvestmentAmount { get; set;}
        public int Leverage { get; set;}
        public DateTime Created { get; set;}
        public double DesiredPrice { get; set;}
        public double OpenPrice { get; set;}
        public IBidAsk OpenBidAsk { get; set;}
        public PositionOperation Operation { get; set;}
        public PositionOrderType PositionOrderType { get; set;}
        public double? TakeProfitInCurrency { get; set;}
        public double? StopLossInCurrency { get; set;}
        public double? TakeProfitRate { get; set;}
        public double? StopLossRate { get; set;}
        DateTime ITradeOrder.TimeStamp => DateTime;
        public string ProcessId { get; set;}
        public DateTime OpenDate { get; set;}
        public double Volume { get; set;}
        public IEnumerable<IPositionCommission> Commissions { get; set;}
        public IEnumerable<IPositionSwap> Swaps { get; set;}
        public double ToppingUpPercent { get; set;}
        public double ReservedFundsForToppingUp { get; set;}
        public double Profit { get; set;}
        public DateTime CloseDate { get; set;}
        public ClosePositionReason CloseReason { get; set;}
        public double ClosePrice { get; set;}
        public IBidAsk CloseBidAsk { get; set;}
        public double BurnBonus { get; set;}
        public DateTime DateTime { get; set;}

        public static ActiveOrderMyNoSqlEntity Create(ITradeOrder src)
        {
            return new ()
            {
                PartitionKey = GeneratePartitionKey(src.AccountId),
                RowKey = GenerateRowKey(src.Id),
                Id = src.Id,
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
                ToppingUpPercent = src.ToppingUpPercent,
                ReservedFundsForToppingUp = src.ReservedFundsForToppingUp,
                Profit = src.Profit,
                CloseDate = src.CloseDate,
                CloseReason = src.CloseReason,
                ClosePrice = src.ClosePrice,
                CloseBidAsk = src.CloseBidAsk,
                BurnBonus = src.BurnBonus,
                DateTime = src.TimeStamp
            };
        }
    }
}