using System;
using System.Collections.Generic;
using MyNoSqlServer.TcpClient;
using SimpleTrading.Abstraction.Markups;

namespace SimpleTrading.MyNoSqlRepositories.Markups
{
    public class MarkupItem : IMarkupItem
    {
        public string InstrumentId { get; set; }
        public int MarkupBid { get; set; }
        public int MarkupAsk { get; set; }
    }

    public class MarkupProfileMyNoSqlTableEntity : MyNoSqlTableEntity, IMarkupProfile
    {
        public static string GeneratePartitionKey()
        {
            return "mk";
        }

        public static string GenerateRowKey(string asset)
        {
            return asset;
        }

        public string ProfileId => RowKey;

        public List<IMarkupItem> MarkupInstruments { get; set; }

        public static MarkupProfileMyNoSqlTableEntity Create(IMarkupProfile src)
        {
            return new MarkupProfileMyNoSqlTableEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(src.ProfileId),
                MarkupInstruments = src.MarkupInstruments
            };
        }
    }
}