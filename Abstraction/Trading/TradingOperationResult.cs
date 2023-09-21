namespace MyNoSqlRepositories.Abstraction.Trading;

public enum TradingOperationResult
{
    /// <summary>
    /// Ok
    /// </summary>
    Ok,
    /// <summary>
    /// Instrument is not working at the moment
    /// </summary>
    DayOff,
    /// <summary>
    /// Operation is to low
    /// </summary>
    MinOperationLotViolated,
    /// <summary>
    /// Operation is to high
    /// </summary>
    MaxOperationLotViolated,
    /// <summary>
    /// Opened position will make Max amount violation
    /// </summary>
    MaxPositionByInstrumentViolated,
    /// <summary>
    /// Not enough balance to perform operation
    /// </summary>
    InsufficientMargin,
    /// <summary>
    /// Bid or Ask is not found
    /// </summary>
    NoLiquidity,
    /// <summary>
    /// Position not found to perform operation
    /// </summary>
    PositionNotFound,
    /// <summary>
    /// Take profit is to close to the market
    /// </summary>
    TpIsTooClose,
    /// <summary>
    /// Sto loss is to close to the market
    /// </summary>
    SlIsTooClose,
    /// <summary>
    /// Pending order is not found to perform operation
    /// </summary>
    PendingOrderNotFound,
    /// <summary>
    /// Account not found
    /// </summary>
    AccountNotFound,
    /// <summary>
    /// Instrument not found
    /// </summary>
    InstrumentNotFound,
    /// <summary>
    /// Instrument can not be used at the moment
    /// </summary>
    InstrumentCanNotBeUsed, 
    OperationIsNotPossibleDuringSwap, 
    MaxAmountPendingOrders,
    /// <summary>
    /// Wrong group is assigned for account
    /// </summary>
    WrongGroupAssigned,
    /// <summary>
    /// Multiplier/Leverage not found
    /// </summary>
    MultiplierNotFound,
    /// <summary>
    /// Invalid Quote
    /// </summary>
    OffQuote,
    /// <summary>
    /// Trading disabled for client
    /// </summary>
    TradingDisabled,
    MaxOpenPositionsAmount
}