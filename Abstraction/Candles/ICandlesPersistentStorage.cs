namespace MyNoSqlRepositories.Abstraction.Candles;

public interface ICandlesPersistentStorage
{
    Task SaveAsync(string instrument, bool bid,int digits,  CandleType candleType,  ICandleModel candleGrpcModel);

    Task BulkSave(string instrument, bool bid, int digits, CandleType candleType, IEnumerable<ICandleModel> candles);

    IAsyncEnumerable<(CandleType candleType, string instrument)> GetDataTypesAsync(bool isBid);
        
    IAsyncEnumerable<ICandleModel> GetAsync(string instrument, bool bid, CandleType candleType);

    IAsyncEnumerable<ICandleModel> GetAsync(string instrument, bool bid, DateTime expirationDate, CandleType candleType);

    IAsyncEnumerable<ICandleModel> GetByPeriodAsync(
        string instrument,
        bool bid,
        CandleType candleType,
        DateTime dateFrom,
        DateTime dateTo);

    IAsyncEnumerable<ICandleModel> GetByPartitionKeyAsync(string instrument, bool bid, string partitionKey, CandleType candleType);

    string GetPartitionKey(DateTime dateTime, CandleType candleType);

    Task<ICandleModel> GetCandleAsync(string instrument, bool bid, CandleType candleType, DateTime dateTime);
}