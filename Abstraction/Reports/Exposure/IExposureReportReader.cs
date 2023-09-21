namespace MyNoSqlRepositories.Abstraction.Reports.Exposure;

public interface IExposureReportReader
{
    IReadOnlyList<IExposure> Get(bool isInternal);
}