using MyNoSqlRepositories.BidAsk;
using MyNoSqlRepositories.Cache.AccountsCache;
using MyNoSqlRepositories.Cache.ActiveOrders;
using MyNoSqlRepositories.Cache.PendingOrders;
using MyNoSqlRepositories.Engine;
using MyNoSqlRepositories.InstrumentSourcesMaps;
using MyNoSqlRepositories.Markups;
using MyNoSqlRepositories.Markups.TradingGroupsMarkups;
using MyNoSqlRepositories.Reports.ActivePositions;
using MyNoSqlRepositories.Reports.Exposure;
using MyNoSqlRepositories.Trading.InstrumentsGroup;
using MyNoSqlRepositories.Trading.InstrumentsSubGroup;
using MyNoSqlRepositories.Trading.InvestAmount;
using MyNoSqlRepositories.Trading.Profiles;
using MyNoSqlServer.Abstractions;
using MyNoSqlServer.DataReader;
using MyNoSqlServer.DataWriter;

namespace MyNoSqlRepositories;

public static class MyNoSqlServerFactory
{
    public static BidAskMyNoSqlCache CreateBidAskMyNoSqlCache(this MyNoSqlTcpClient connection)
    {
        return new BidAskMyNoSqlCache(connection.ToMyNoSqlReadRepository<BidAskMyNoSqlTableEntity>("quoteprofile"));
    }

    private const string InvestAmountTable = "investamount";

    public static InvestAmountMyNoSqlRepository CreateInvestAmountMyNoSqlRepository(Func<string> getUrl)
    {
        return new InvestAmountMyNoSqlRepository(
            new MyNoSqlServerDataWriter<InvestAmountMyNoSqlTableEntity>(getUrl, InvestAmountTable, true));
    }

    public static IInvestAmountMyNoSqlReader CreateInvestAmountMyNoSqlReader(this MyNoSqlTcpClient connection)
    {
        return new InvestAmountMyNoSqlReader(
            connection.ToMyNoSqlReadRepository<InvestAmountMyNoSqlTableEntity>(InvestAmountTable));
    }

    private const string TradingGroupsTableName = "tradinggroups";

    private static string IsLivePrefix(bool isLive)
    {
        return isLive ? "live-" : "demo-";
    }

    private const string EnginePersistenceQueueTable = "enginepersistencequeue";

    private const string EngineToppingUpQueueTable = "enginetoppinngupqueue";

    public static TradingGroupsMyNoSqlReader CreateEnginePersistenceQueueReader(this MyNoSqlTcpClient connection,
        bool isLive)
    {
        return new TradingGroupsMyNoSqlReader(
            new MyNoSqlReadRepository<TradingGroupMyNoSqlEntity>(connection,
                IsLivePrefix(isLive) + EnginePersistenceQueueTable));
    }

    public static TradingGroupsMyNoSqlReader CreateEngineToppingUpQueueReader(this MyNoSqlTcpClient connection,
        bool isLive)
    {
        return new TradingGroupsMyNoSqlReader(
            new MyNoSqlReadRepository<TradingGroupMyNoSqlEntity>(connection,
                IsLivePrefix(isLive) + EngineToppingUpQueueTable));
    }

    public static EnginePersistenceQueueItemMyNoSqlRepository CreateEngineToppingUpQueueRepository(
        Func<string> getUrl,
        bool isLive)
    {
        return new EnginePersistenceQueueItemMyNoSqlRepository(
            new MyNoSqlServerDataWriter<EnginePersistenceQueueItemMyNoSqlModel>(getUrl,
                IsLivePrefix(isLive) + EngineToppingUpQueueTable, true));
    }

    public static EnginePersistenceQueueItemMyNoSqlRepository CreateEnginePersistenceQueueRepository(
        Func<string> getUrl,
        bool isLive)
    {
        return new EnginePersistenceQueueItemMyNoSqlRepository(
            new MyNoSqlServerDataWriter<EnginePersistenceQueueItemMyNoSqlModel>(getUrl,
                IsLivePrefix(isLive) + EnginePersistenceQueueTable, true));
    }

    public static TradingGroupsMyNoSqlReader CreateTradingGroupsMyNoSqlReader(this MyNoSqlTcpClient connection,
        bool isLive)
    {
        return new TradingGroupsMyNoSqlReader(
            new MyNoSqlReadRepository<TradingGroupMyNoSqlEntity>(connection,
                IsLivePrefix(isLive) + TradingGroupsTableName));
    }

    public static TradingGroupsMyNoSqlRepository CreateTradingGroupsMyNoSqlRepository(Func<string> getUrl,
        bool isLive)
    {
        return new TradingGroupsMyNoSqlRepository(
            new MyNoSqlServerDataWriter<TradingGroupMyNoSqlEntity>(getUrl,
                IsLivePrefix(isLive) + TradingGroupsTableName, true));
    }

    private const string ReportActivePositionsTableName = "reportactivepositions";

    public static ReportActivePositionMyNoSqlRepository CreateReportActivePositionMyNoSqlRepository(
        Func<string> getUrl,
        bool isLive)
    {
        return new ReportActivePositionMyNoSqlRepository(
            new MyNoSqlServerDataWriter<ReportActivePositionMyNoSqlEntity>(
                getUrl,
                IsLivePrefix(isLive) + ReportActivePositionsTableName, true
            )
        );
    }

    public static ReportActivePositionMyNoSqlReader CreateReportActivePositionMyNoSqlReader(
        this MyNoSqlTcpClient connection,
        bool isLive)
    {
        return new ReportActivePositionMyNoSqlReader(
            new MyNoSqlReadRepository<ReportActivePositionMyNoSqlEntity>(connection,
                IsLivePrefix(isLive) + ReportActivePositionsTableName));
    }
        
        
        
    private const string PendingOrdersCache = "pending-orders-cache";

    public static PendingOrdersNoSqlWriter CreatePendingOrdersCacheRepository(
        Func<string> getUrl,
        bool isLive)
    {
        return new PendingOrdersNoSqlWriter(
            new MyNoSqlServerDataWriter<PendingOrderNoSqlEntity>(
                getUrl,
                IsLivePrefix(isLive) + PendingOrdersCache, true
            )
        );
    }

    public static PendingOrdersCacheNoSqlReader CreatePendingOrdersCacheReader(
        this MyNoSqlTcpClient connection,
        bool isLive)
    {
        return new PendingOrdersCacheNoSqlReader(
            new MyNoSqlReadRepository<PendingOrderNoSqlEntity>(connection,
                IsLivePrefix(isLive) + PendingOrdersCache));
    }
        
        
    private const string ActiveOrdersCache = "active-orders-cache";

    public static ActiveOrdersCacheNoSqlWriter CreateActiveOrdersCacheRepository(
        Func<string> getUrl,
        bool isLive)
    {
        return new ActiveOrdersCacheNoSqlWriter(
            new MyNoSqlServerDataWriter<ActiveOrderMyNoSqlEntity>(
                getUrl,
                IsLivePrefix(isLive) + ActiveOrdersCache, true
            )
        );
    }

    public static ActiveOrdersCacheNoSqlReader CreateActiveOrdersCacheReader(
        this MyNoSqlTcpClient connection,
        bool isLive)
    {
        return new ActiveOrdersCacheNoSqlReader(
            new MyNoSqlReadRepository<ActiveOrderMyNoSqlEntity>(connection,
                IsLivePrefix(isLive) + ActiveOrdersCache));
    }

    private const string TradingProfilesTableName = "tradingprofiles";

    public static TradingProfileMyNoSqlReader CreateTradingProfileMyNoSqlReader(this MyNoSqlTcpClient connection,
        bool isLive)
    {
        return new TradingProfileMyNoSqlReader(
            new MyNoSqlReadRepository<TradingProfileMyNoSqlEntity>(connection,
                IsLivePrefix(isLive) + TradingProfilesTableName));
    }

    public static TradingProfilesMyNoSqlRepository CreateTradingProfilesMyNoSqlRepository(Func<string> getUrl,
        bool isLive)
    {
        return new TradingProfilesMyNoSqlRepository(
            new MyNoSqlServerDataWriter<TradingProfileMyNoSqlEntity>(getUrl,
                IsLivePrefix(isLive) + TradingProfilesTableName, true));
    }

    private const string InstrumentsTable = "instruments";
    /*
    public static InstrumentsMyNoSqlReadCache CreateInstrumentsMyNoSqlReadCache(this MyNoSqlTcpClient connection)
    {
        return new InstrumentsMyNoSqlReadCache(
            new MyNoSqlReadRepository<TradingInstrumentMyNoSqlEntity>(connection, InstrumentsTable));
    }

    public static TradingInstrumentsMyNoSqlRepository CreateTradingInstrumentsMyNoSqlRepository(Func<string> getUrl)
    {
        return new TradingInstrumentsMyNoSqlRepository(
            new MyNoSqlServerDataWriter<TradingInstrumentMyNoSqlEntity>(getUrl, InstrumentsTable, true));
    }
    */
    private const string InstrumentGroupsTable = "instrumentsgroups";

    public static InstrumentGroupsMyNoSqlRepository CreateInstrumentGroupsMyNoSqlRepository(Func<string> getUrl)
    {
        return new InstrumentGroupsMyNoSqlRepository(
            new MyNoSqlServerDataWriter<InstrumentGroupMyNoSqlEntity>(getUrl, InstrumentGroupsTable, true));
    }

    public static InstrumentGroupsMyNoSqlReadCache CreateInstrumentGroupsMyNoSqlReadCache(
        this MyNoSqlTcpClient connection)
    {
        return new InstrumentGroupsMyNoSqlReadCache(
            new MyNoSqlReadRepository<InstrumentGroupMyNoSqlEntity>(connection, InstrumentGroupsTable));
    }

    private const string InstrumentSubGroupsTable = "instrumentsubgroups";

    public static InstrumentSubGroupsMyNoSqlRepository CreateInstrumentSubGroupsMyNoSqlRepository(
        Func<string> getUrl)
    {
        return new InstrumentSubGroupsMyNoSqlRepository(
            new MyNoSqlServerDataWriter<InstrumentSubGroupMyNoSqlEntity>(getUrl, InstrumentSubGroupsTable, true));
    }

    public static InstrumentSubGroupsMyNoSqlReadCache CreateInstrumentSubGroupsMyNoSqlReadCache(
        this MyNoSqlTcpClient connection)
    {
        return new InstrumentSubGroupsMyNoSqlReadCache(
            new MyNoSqlReadRepository<InstrumentSubGroupMyNoSqlEntity>(connection, InstrumentSubGroupsTable));
    }

    private const string PriceChangesTable = "pricechanges";

    public static PriceChangeWriteRepository CreatePriceChangeWriteRepository(
        Func<string> getUrl, string platformPrefix)
    {
        return new PriceChangeWriteRepository(
            new MyNoSqlServerDataWriter<PriceChangeMyNoSqlEntity>(getUrl, platformPrefix + PriceChangesTable, true));
    }

    public static PriceChangeReader CreatePriceChangeReader(this MyNoSqlTcpClient client, string platformPrefix)
    {
        return new PriceChangeReader(
            new MyNoSqlReadRepository<PriceChangeMyNoSqlEntity>(client, platformPrefix + PriceChangesTable));
    }

    private const string InstrumentSourceMap = "instrument-sources";

    public static InstrumentSourcesMapsMyNoSqlReader CreateInstrumentSourceMapMyNoSqlReader(
        this MyNoSqlTcpClient client)
    {
        return new InstrumentSourcesMapsMyNoSqlReader(
            new MyNoSqlReadRepository<InstrumentSourcesMapsMyNoSqlTableEntity>(client, InstrumentSourceMap));
    }

    public static InstrumentSourcesMapsMyNoSqlRepository CreateInstrumentSourcesMapsNoSqlRepository(
        Func<string> getUrl)
    {
        return new InstrumentSourcesMapsMyNoSqlRepository(
            new MyNoSqlServerDataWriter<InstrumentSourcesMapsMyNoSqlTableEntity>(getUrl, InstrumentSourceMap,
                true));
    }

    private const string MarkupProfiles = "markup-profiles";
    private const string TradingGroupsMarkupProfiles = "trading-groups-markup-profiles";
    private const string TradingGroupsMarkupProfileProperties = "trading-groups-markup-profiles-properties";

    public static MarkupProfilesMyNoSqlReader CreateMarkupProfilesMyNoSqlReader(
        this MyNoSqlTcpClient client)
    {
        return new MarkupProfilesMyNoSqlReader(
            new MyNoSqlReadRepository<MarkupProfileMyNoSqlTableEntity>(client, MarkupProfiles));
    }

    public static MarkupProfilesMyNoSqlRepository CreateMarkupProfilesNoSqlRepository(Func<string> getUrl)
    {
        return new MarkupProfilesMyNoSqlRepository(
            new MyNoSqlServerDataWriter<MarkupProfileMyNoSqlTableEntity>(getUrl, MarkupProfiles, true));
    }
        
    public static TradingGroupMarkupProfilesMyNoSqlReader CreateTradingGroupsMarkupProfilesMyNoSqlReader(
        this MyNoSqlTcpClient client, bool isLive)
    {
        return new TradingGroupMarkupProfilesMyNoSqlReader(
            new MyNoSqlReadRepository<TradingGroupMarkupProfileMyNoSqlTableEntity>(client, IsLivePrefix(isLive) +TradingGroupsMarkupProfiles));
    }

    public static TradingGroupMarkupProfilesMyNoSqlRepository CreateTradingGroupsMarkupProfilesNoSqlRepository(Func<string> getUrl, bool isLive)
    {
        return new TradingGroupMarkupProfilesMyNoSqlRepository(
            new MyNoSqlServerDataWriter<TradingGroupMarkupProfileMyNoSqlTableEntity>(getUrl, IsLivePrefix(isLive) +TradingGroupsMarkupProfiles, true));
    }

    public static TradingGroupMarkupProfilePropertiesMyNoSqlRepository CreateTradingGroupMarkupProfilePropertiesMyNoSqlRepository(
        Func<string> getUrl,
        bool isLive)
    {
        return new TradingGroupMarkupProfilePropertiesMyNoSqlRepository(
            new MyNoSqlServerDataWriter<TradingGroupMarkupProfilePropertiesMyNoSqlTableEntity>(getUrl, IsLivePrefix(isLive) + TradingGroupsMarkupProfileProperties, true));
    }        

    private const string AccountCache = "engine-accounts-cache";

    public static AccountsCacheNoSqlWriter CreateAccountsCacheNoSqlWriter(Func<string> getUrl, string prefix)
    {
        return new AccountsCacheNoSqlWriter(
            new MyNoSqlServerDataWriter<AccountsCacheNoSqlEntity>(getUrl,
                $"{AccountCache}-{prefix}", true));
    }

    public static AccountCacheNoSqlReader CreateAccountCacheMyNoSqlReader(this MyNoSqlTcpClient connection,
        string prefix)
    {
        return new AccountCacheNoSqlReader(
            new MyNoSqlReadRepository<AccountsCacheNoSqlEntity>(connection,
                $"{AccountCache}-{prefix}"));
    }

    private const string ExposureReportTableName = "exposure-report";

    public static ExposureReportMyNoSqlRepository CreateExposureReporMyNoSqlRepository(Func<string> getUrl)
    {
        return new ExposureReportMyNoSqlRepository(
            new MyNoSqlServerDataWriter<InstrumentExposureMyNoSqlEntity>(
                getUrl,
                ExposureReportTableName, true));
    }

    public static ExposureReportMyNoSqlReader CreateExposureReporMyNoSqlReader(this MyNoSqlTcpClient connection)
    {
        return new ExposureReportMyNoSqlReader(
            new MyNoSqlReadRepository<InstrumentExposureMyNoSqlEntity>(
                connection,
                ExposureReportTableName));
    }
}

public static class MyNoSqlServerUtils
{
    public static IMyNoSqlServerDataReader<T> ToMyNoSqlReadRepository<T>(this IMyNoSqlSubscriber connection,
        string tableName)
        where T : IMyNoSqlDbEntity
    {
        return new MyNoSqlReadRepository<T>(connection, tableName);
    }
}