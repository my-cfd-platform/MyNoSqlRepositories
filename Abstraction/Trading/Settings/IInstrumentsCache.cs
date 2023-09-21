using MyNoSqlRepositories.Abstraction.Trading.Instruments;

namespace MyNoSqlRepositories.Abstraction.Trading.Settings;

public interface IInstrumentsCache
{
    IEnumerable<ITradingInstrument> GetAll();
        
    ITradingInstrument Get(string id);

    ITradingInstrument Get(string onePart, string otherPart);
}