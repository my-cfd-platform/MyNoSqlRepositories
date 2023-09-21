
namespace MyNoSqlRepositories.Abstraction.Markups.TradingGroupMarkupProfiles;

public interface ITradingGroupMarkupProfileProperties
{
    string ProfileId { get; }

    string Description { get; }

    bool IsHidden { get; }
}