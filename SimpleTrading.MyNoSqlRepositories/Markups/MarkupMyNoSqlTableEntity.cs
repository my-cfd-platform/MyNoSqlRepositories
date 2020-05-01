using System;
using System.Collections.Generic;
using System.Linq;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Markups;

namespace SimpleTrading.MyNoSqlRepositories.Markups
{
    public class MarkupItem : IMarkupItem
    {
        public string InstrumentId { get; set; }
        public int MarkupBid { get; set; }
        public int MarkupAsk { get; set; }

        public static MarkupItem Create(IMarkupItem src)
        {
            return new MarkupItem
            {
                InstrumentId = src.InstrumentId,
                MarkupAsk = src.MarkupAsk,
                MarkupBid = src.MarkupBid
            };
        }
    }

    public class MarkupProfileMyNoSqlTableEntity : MyNoSqlEntity, IMarkupProfile
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

        public List<MarkupItem> MarkupInstruments { get; set; }
        IReadOnlyList<IMarkupItem> IMarkupProfile.MarkupInstruments => (IReadOnlyList<IMarkupItem>)MarkupInstruments ?? Array.Empty<IMarkupItem>();

        public static MarkupProfileMyNoSqlTableEntity Create(IMarkupProfile src)
        {
            return new MarkupProfileMyNoSqlTableEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(src.ProfileId),
                MarkupInstruments = src.MarkupInstruments.Select(MarkupItem.Create).ToList()
            };
        }
    }
}