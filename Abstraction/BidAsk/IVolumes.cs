namespace MyNoSqlRepositories.Abstraction.BidAsk;

public interface IVolumes
{
    string Id { get; }
    long Volume { get; }
    DateTime DateTime { get; }
}