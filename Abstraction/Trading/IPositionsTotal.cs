namespace MyNoSqlRepositories.Abstraction.Trading;

public interface IPositionsTotal
{
    double TotalInvestment { get; set; }
        
    double TotalEquity { get; set; }
}