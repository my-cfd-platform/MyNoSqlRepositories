namespace MyNoSqlRepositories.Abstraction.Trading.InstrumentsGroup;

public interface IInstrumentGroup
{
    string Id { get; }
    string Name { get; }
    int Weight { get; }
}