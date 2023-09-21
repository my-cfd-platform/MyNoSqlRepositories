namespace MyNoSqlRepositories.Abstraction.Trading.Positions;

public enum ClosePositionReason
{
    None, ClientCommand, StopOut, TakeProfit, StopLoss, Canceled, AdminAction
}