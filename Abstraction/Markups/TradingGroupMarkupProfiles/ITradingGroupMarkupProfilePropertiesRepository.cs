namespace MyNoSqlRepositories.Abstraction.Markups.TradingGroupMarkupProfiles;

public interface ITradingGroupMarkupProfilePropertiesRepository
{
    Task<IEnumerable<ITradingGroupMarkupProfileProperties>> GetAllAsync();

    Task UpdateAsync(ITradingGroupMarkupProfileProperties markupProfileProperties);

    Task<ITradingGroupMarkupProfileProperties> GetById(string profileId);
}