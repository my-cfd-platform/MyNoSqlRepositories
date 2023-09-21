namespace MyNoSqlRepositories.Abstraction.Trading.InstrumentsGroup;

public interface IInstrumentGroupsRepository
{
    Task<IEnumerable<IInstrumentGroup>> GetAllAsync();
        
    Task UpdateAsync(IInstrumentGroup item);
}