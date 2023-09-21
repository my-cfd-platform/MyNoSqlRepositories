namespace MyNoSqlRepositories.Abstraction.Markups.TradingGroupMarkupProfiles;

public interface ITradingGroupsMarkupProfilesReader
{
    ITradingGroupMarkupProfile Get(string profileId);
}