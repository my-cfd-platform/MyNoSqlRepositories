namespace MyNoSqlRepositories.Abstraction.Reports.Exposure;

public interface IExposure
{
    string Id { get; }
        
    double Buy { get; }
        
    double Sell { get; }
        
    bool IsInternal { get; }
}