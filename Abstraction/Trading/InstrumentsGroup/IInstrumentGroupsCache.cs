namespace MyNoSqlRepositories.Abstraction.Trading.InstrumentsGroup;

public interface IInstrumentGroupsCache
{
    IEnumerable<IInstrumentGroup> GetAll();

    IInstrumentGroup Get(string id);
}