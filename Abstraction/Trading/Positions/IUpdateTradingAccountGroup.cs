using MyNoSqlRepositories.Abstraction.Markups.TradingGroupMarkupProfiles;

namespace MyNoSqlRepositories.Abstraction.Trading.Positions;

public interface IUpdateTradingAccountGroup
{
    string TraderId { get; }
    string AccountId { get; }
    string GroupToAssign { get; }
    ITradingGroupMarkupProfile MarkupProfileBeforeUpdate { get; }
    ITradingGroupMarkupProfile MarkupProfileAfterUpdate { get; }
}