using MyNoSqlRepositories.Abstraction.Reports.Exposure;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.Reports.Exposure;

public class InstrumentExposureMyNoSqlEntity : MyNoSqlDbEntity, IExposure
{
    public static string GeneratePartitionKey(bool isInternal)
    {
        return isInternal ? "internal" : "real";
    }

    public static string GenerateRowKey(string instrumentId)
    {
        return instrumentId;
    }

    public string Id => RowKey;

    public double Buy { get; set; }

    public double Sell { get; set; }

    public bool IsInternal { get; set; }

    public static InstrumentExposureMyNoSqlEntity Create(string id, double buy, double sell, bool isInternal)
    {
        return new InstrumentExposureMyNoSqlEntity
        {
            PartitionKey = GeneratePartitionKey(isInternal),
            RowKey = GenerateRowKey(id),
            Buy = buy,
            Sell = sell,
            IsInternal = isInternal
        };
    }

    public static InstrumentExposureMyNoSqlEntity Create(IExposure src)
    {
        return new InstrumentExposureMyNoSqlEntity
        {
            PartitionKey = GeneratePartitionKey(src.IsInternal),
            RowKey = GenerateRowKey(src.Id),
            Buy = src.Buy,
            Sell = src.Sell,
            IsInternal = src.IsInternal
        };
    }
}