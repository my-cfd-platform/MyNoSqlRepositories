namespace MyNoSqlRepositories.Abstraction.Markups;

public interface IMarkupItem
{
    string InstrumentId { get; }
    int MarkupBid { get; }
    int MarkupAsk { get; }
}