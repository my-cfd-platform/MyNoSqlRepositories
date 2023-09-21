namespace MyNoSqlRepositories.Abstraction.Reports.ActivePositions;

public interface IReportActivePositionsRepository
{
    Task<IEnumerable<IActivePositionsSnapshot>> GetAsync();
        
    Task<IEnumerable<IActivePositionsSnapshot>> GetAsync(string accountId);

    Task SaveAsync(IActivePositionsSnapshot snapshot);
}