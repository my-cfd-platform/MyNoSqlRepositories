namespace MyNoSqlRepositories.Abstraction.Trading.Positions;

public interface IPositionCommission
{
    DateTime DateTime { get; }
        
    PositionCommissionType CommissionType { get; }
        
    double Amount { get; }
}