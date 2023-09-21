namespace MyNoSqlRepositories.Abstraction.Trading.Instruments;

public interface ITradingInstrumentsRepository
{
    Task<IEnumerable<ITradingInstrument>> GetAllAsync();
        
    Task UpdateAsync(ITradingInstrument item);
}

public static class MtInstrumentHelpers
{
    public static bool IsConnectedToAccount(this ITradingInstrument instrument, string accountCurrency)
    {
        return instrument.Base == accountCurrency || instrument.Quote == accountCurrency;
    }
}