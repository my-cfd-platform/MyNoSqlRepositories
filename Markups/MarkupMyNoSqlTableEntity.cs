using MyNoSqlRepositories.Abstraction.Markups;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Markups;

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

public class MarkupProfileMyNoSqlTableEntity : MyNoSqlDbEntity, IMarkupProfile
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

        
    private static readonly IReadOnlyDictionary<string, IMarkupItem> Empty  = new Dictionary<string, IMarkupItem>();

    private IReadOnlyDictionary<string, IMarkupItem> _item;
    private IReadOnlyDictionary<string, IMarkupItem> GetMarkupInstrument()
    {
        if (MarkupInstruments == null)
            return Empty;
            
        var result = new Dictionary<string, IMarkupItem>();

        foreach (var markupItem in MarkupInstruments)
            result.Add(markupItem.InstrumentId, markupItem);

        _item = result;

        return result;
    }
        
    IReadOnlyDictionary<string, IMarkupItem> IIMarkupProfileBase.MarkupInstruments => _item ?? GetMarkupInstrument();

    public static MarkupProfileMyNoSqlTableEntity Create(IMarkupProfile src)
    {
        return new MarkupProfileMyNoSqlTableEntity
        {
            PartitionKey = GeneratePartitionKey(),
            RowKey = GenerateRowKey(src.ProfileId),
            MarkupInstruments = src.MarkupInstruments.Values.Select(MarkupItem.Create).ToList()
        };
    }
}