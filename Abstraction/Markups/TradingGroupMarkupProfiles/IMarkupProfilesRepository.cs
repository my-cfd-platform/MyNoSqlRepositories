namespace MyNoSqlRepositories.Abstraction.Markups.TradingGroupMarkupProfiles;

public interface ITradingGroupsMarkupProfilesRepository
{
    Task<IEnumerable<ITradingGroupMarkupProfile>> GetAllAsync();

    Task UpdateAsync(ITradingGroupMarkupProfile markupProfile);

    Task<ITradingGroupMarkupProfile> GetById(string profileId);
}