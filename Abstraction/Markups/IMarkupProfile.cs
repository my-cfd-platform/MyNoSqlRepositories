namespace MyNoSqlRepositories.Abstraction.Markups;

public interface IIMarkupProfileBase
{
    string ProfileId { get; }
    IReadOnlyDictionary<string, IMarkupItem> MarkupInstruments{ get; }
}
    
public interface IMarkupProfile : IIMarkupProfileBase
{
}