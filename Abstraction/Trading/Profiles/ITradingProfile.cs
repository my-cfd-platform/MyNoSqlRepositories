namespace MyNoSqlRepositories.Abstraction.Trading.Profiles;

public interface ITradingProfile
{
    string Id { get; }
        
    double MarginCallPercent { get; }
        
    double StopOutPercent { get; }
        
    double PositionToppingUpPercent { get; }
        
    IEnumerable<ITradingProfileInstrument> Instruments { get; }
}



public interface ITradingProfileRepository
{
    Task<IEnumerable<ITradingProfile>> GetAllAsync();

    Task UpdateAsync(ITradingProfile tradingGroup);
        
}
    
public interface ITradingProfilesReader
{
    IEnumerable<ITradingProfile> GetAll();

    ITradingProfile Get(string id);
}