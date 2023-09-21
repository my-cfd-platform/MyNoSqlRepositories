namespace MyNoSqlRepositories.Abstraction.Trading.InstrumentsSubGroup;

public interface IInstrumentSubGroupsCache
{
    IEnumerable<IInstrumentSubGroup> GetAll();
        
    IInstrumentSubGroup GetById(string groupId, string subGroupId);
        
    IEnumerable<IInstrumentSubGroup> GetByGroupId(string groupId);
}