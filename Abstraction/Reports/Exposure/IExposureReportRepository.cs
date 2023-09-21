namespace MyNoSqlRepositories.Abstraction.Reports.Exposure;

public interface IExposureReportRepository
{
    Task<IEnumerable<IExposure>> GetAsync(bool isInternal);

    Task SaveAsync(IExposure instrumentExposure);
}