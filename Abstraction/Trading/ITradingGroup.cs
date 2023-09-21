namespace MyNoSqlRepositories.Abstraction.Trading;

public interface ITradingGroup
{
    string Id { get; }
        
    string Name { get; }
       
    string TradingProfileId { get; }
       
    string MarkupProfileId { get; }
        
    string SwapProfileId { get; }
        
    bool TradingDisabled { get; set; }
}
    
public interface ITradingGroupsRepository
{
    Task<IEnumerable<ITradingGroup>> GetAllAsync();
      
    Task UpdateAsync(ITradingGroup item);
}
    
public interface ITradingGroupsReader
{
    IEnumerable<ITradingGroup> GetAll();
       
    ITradingGroup Get(string id);
}