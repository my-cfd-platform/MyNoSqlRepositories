using System;
using MyNoSqlServer.Abstractions;
using MyNoSqlServer.DataReader;
using MyNoSqlServer.DataWriter;
using SimpleTrading.MyNoSqlRepositories.Auth.Restriction;
using SimpleTrading.MyNoSqlRepositories.BidAsk;
using SimpleTrading.MyNoSqlRepositories.Brand;
using SimpleTrading.MyNoSqlRepositories.Cache.AccountsCache;
using SimpleTrading.MyNoSqlRepositories.Countries;
using SimpleTrading.MyNoSqlRepositories.DefaultValues;
using SimpleTrading.MyNoSqlRepositories.Emails.EmailTemplate;
using SimpleTrading.MyNoSqlRepositories.Engine;
using SimpleTrading.MyNoSqlRepositories.InstrumentSourcesMaps;
using SimpleTrading.MyNoSqlRepositories.Languages;
using SimpleTrading.MyNoSqlRepositories.Markups;
using SimpleTrading.MyNoSqlRepositories.Misc.Onboarding;
using SimpleTrading.MyNoSqlRepositories.Platform;
using SimpleTrading.MyNoSqlRepositories.Reports.ActivePositions;
using SimpleTrading.MyNoSqlRepositories.Reports.Exposure;
using SimpleTrading.MyNoSqlRepositories.Swaps;
using SimpleTrading.MyNoSqlRepositories.Trading.Instruments;
using SimpleTrading.MyNoSqlRepositories.Trading.InstrumentsAvatar;
using SimpleTrading.MyNoSqlRepositories.Trading.InstrumentsGroup;
using SimpleTrading.MyNoSqlRepositories.Trading.InvestAmount;
using SimpleTrading.MyNoSqlRepositories.Trading.Profiles;

namespace SimpleTrading.MyNoSqlRepositories
{
    public static class MyNoSqlServerFactory
    {
        public static BidAskMyNoSqlCache CreateBidAskMyNoSqlCache(this MyNoSqlTcpClient connection)
        {
            return new BidAskMyNoSqlCache(connection.ToMyNoSqlReadRepository<BidAskMyNoSqlTableEntity>("quoteprofile"));
        }

        private const string CountriesTable = "countries";

        public static CountryMyNoSqlReader CreateCountryMyNoSqlReader(this MyNoSqlTcpClient connection)
        {
            return new CountryMyNoSqlReader(
                connection.ToMyNoSqlReadRepository<CountryMyNoSqlTableEntity>(CountriesTable));
        }

        public static CountryMyNoSqlRepository CreateCountryMyNoSqlRepository(Func<string> getUrl)
        {
            return new CountryMyNoSqlRepository(
                new MyNoSqlServerDataWriter<CountryMyNoSqlTableEntity>(getUrl, CountriesTable, true));
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
        
        public static EnginePersistenceQueueItemMyNoSqlRepository CreateEngineToppingUpQueueRepository(Func<string> getUrl,
            bool isLive)
        {
            return new EnginePersistenceQueueItemMyNoSqlRepository(
                new MyNoSqlServerDataWriter<EnginePersistenceQueueItemMyNoSqlModel>(getUrl,
                    IsLivePrefix(isLive) + EngineToppingUpQueueTable, true));
        }
        
        public static EnginePersistenceQueueItemMyNoSqlRepository CreateEnginePersistenceQueueRepository(Func<string> getUrl,
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

        private const string AuthRestrictionTableName = "auth-restriction";

        public static AuthRestrictionMyNoSqlRepository CreateAuthRestrictionMyNoSqlTableRepository(Func<string> getUrl)
        {
            return new AuthRestrictionMyNoSqlRepository(
                new MyNoSqlServerDataWriter<AuthRestrictionMyNoSqlEntity>(getUrl, AuthRestrictionTableName, true)
            );
        }

        public static AuthRestrictionMyNoSqlReader CreateAuthRestrictionMyNoSqlReader(this MyNoSqlTcpClient connection)
        {
            return new AuthRestrictionMyNoSqlReader(
                new MyNoSqlReadRepository<AuthRestrictionMyNoSqlEntity>(connection, AuthRestrictionTableName));
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

        private const string DefaultsValuesTable = "defaultvalues";
        private const string QuotesFeedRouterBackupTimeoutTable = "quotesfeedrouterbackuptimeouttable";

        public static DefaultValuesMyNoSqlWriter CreateDefaultValueMyNoSqlRepository(Func<string> getUrl)
        {
            return new DefaultValuesMyNoSqlWriter(
                new MyNoSqlServerDataWriter<DefaultValueMyNoSqlTableEntity>(getUrl, DefaultsValuesTable, true),
                new MyNoSqlServerDataWriter<QuotesFeedRouterBackupTimeoutEntity>(getUrl,
                    QuotesFeedRouterBackupTimeoutTable, true));
        }

        public static DefaultValuesMyNoSqlReader CreateDefaultValuesMyNoSqlReader(this MyNoSqlTcpClient connection)
        {
            return new DefaultValuesMyNoSqlReader(
                new MyNoSqlReadRepository<DefaultValueMyNoSqlTableEntity>(connection, DefaultsValuesTable),
                new MyNoSqlReadRepository<QuotesFeedRouterBackupTimeoutEntity>(connection,
                    QuotesFeedRouterBackupTimeoutTable));
        }

        private const string InstrumentsAvatarTable = "instrumentsavatar";

        public static TradingInstrumentMyNoSqlRepository CreateTradingInstrumentMyNoSqlRepository(Func<string> getUrl)
        {
            return new TradingInstrumentMyNoSqlRepository(
                new MyNoSqlServerDataWriter<TradingInstrumentAvatarMyNoSqlEntity>(getUrl, InstrumentsAvatarTable,
                    true));
        }

        public static TradingInstrumentMyNoSqlReadCache CreateTradingInstrumentMyNoSqlReader(
            this MyNoSqlTcpClient connection)
        {
            return new TradingInstrumentMyNoSqlReadCache(
                new MyNoSqlReadRepository<TradingInstrumentAvatarMyNoSqlEntity>(connection, InstrumentsAvatarTable));
        }

        private const string LanguagesTable = "languages";

        public static LanguageMyNoSqlReader CreateLanguagesMyNoSqlReader(this MyNoSqlTcpClient connection)
        {
            return new LanguageMyNoSqlReader(
                new MyNoSqlReadRepository<LanguageMyNoSqlEntity>(connection, LanguagesTable));
        }

        public static LanguageMyNoSqlRepository CreateLanguageMyNoSqlRepository(Func<string> getUrl)
        {
            return new LanguageMyNoSqlRepository(
                new MyNoSqlServerDataWriter<LanguageMyNoSqlEntity>(getUrl, LanguagesTable, true));
        }

        private const string BrandsTable = "brand";

        public static BrandMyNoSqlReader CreateBrandMyNoSqlReader(this MyNoSqlTcpClient connection)
        {
            return new BrandMyNoSqlReader(new MyNoSqlReadRepository<BrandMyNoSqlEntity>(connection, BrandsTable));
        }

        public static BrandMyNoSqlRepository CreateBrandMyNoSqlRepository(Func<string> getUrl)
        {
            return new BrandMyNoSqlRepository(
                new MyNoSqlServerDataWriter<BrandMyNoSqlEntity>(getUrl, BrandsTable, true));
        }

        private const string PlatformsTable = "platforms";

        public static PlatformMyNoSqlReader CreatePlatformsMyNoSqlReader(this MyNoSqlTcpClient connection)
        {
            return new PlatformMyNoSqlReader(
                new MyNoSqlReadRepository<PlatformMyNoSqlEntity>(connection, PlatformsTable));
        }

        public static PlatformMyNoSqlRepository CreatePlatformsMyNoSqlRepository(Func<string> getUrl)
        {
            return new PlatformMyNoSqlRepository(
                new MyNoSqlServerDataWriter<PlatformMyNoSqlEntity>(getUrl, PlatformsTable, true));
        }

        private const string EmailTemplatesTable = "emailtemplates";

        public static EmailTemplatesMyNoSqlReader CreateEmailTemplatesMyNoSqlReader(this MyNoSqlTcpClient connection)
        {
            return new EmailTemplatesMyNoSqlReader(
                new MyNoSqlReadRepository<EmailTemplatesMyNoSqlEntity>(connection, EmailTemplatesTable));
        }

        public static EmailTemplatesMyNoSqlRepository CreateEmailTemplatesMyNoSqlRepository(Func<string> getUrl)
        {
            return new EmailTemplatesMyNoSqlRepository(
                new MyNoSqlServerDataWriter<EmailTemplatesMyNoSqlEntity>(getUrl, EmailTemplatesTable, true));
        }

        private const string InstrumentsTable = "instruments";

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

        public static InstrumentSubGroupsMyNoSqlRepository CreateInstrumentSubGroupsMyNoSqlRepository(Func<string> getUrl)
        {
            return new InstrumentSubGroupsMyNoSqlRepository(
                new MyNoSqlServerDataWriter<InstrumentSubGroupMyNoSqlEntity>(getUrl, InstrumentGroupsTable, true));
        }

        public static InstrumentSubGroupsMyNoSqlReadCache CreateInstrumentSubGroupsMyNoSqlReadCache(
            this MyNoSqlTcpClient connection)
        {
            return new InstrumentSubGroupsMyNoSqlReadCache(
                new MyNoSqlReadRepository<InstrumentSubGroupMyNoSqlEntity>(connection, InstrumentSubGroupsTable));
        }

        private const string PriceChangesTable = "pricechanges";

        public static PriceChangeWriteRepository CreatePriceChangeWriteRepository(
            Func<string> getUrl)
        {
            return new PriceChangeWriteRepository(
                new MyNoSqlServerDataWriter<PriceChangeMyNoSqlEntity>(getUrl, PriceChangesTable, true));
        }

        public static PriceChangeReader CreatePriceChangeReader(this MyNoSqlTcpClient client)
        {
            return new PriceChangeReader(
                new MyNoSqlReadRepository<PriceChangeMyNoSqlEntity>(client, PriceChangesTable));
        }

        private const string SwapSchedule = "swap-schedule";


        public static SwapScheduleMyNoSqlRepository CreateSwapScheduleMyNoSqlRepository(
            Func<string> getUrl)
        {
            return new SwapScheduleMyNoSqlRepository(
                new MyNoSqlServerDataWriter<SwapScheduleMyNoSqlEntity>(getUrl, SwapSchedule, true));
        }

        public static SwapScheduleMyNoSqlReader CreateSwapScheduleMyNoSqlReader(this MyNoSqlTcpClient client)
        {
            return new SwapScheduleMyNoSqlReader(
                new MyNoSqlReadRepository<SwapScheduleMyNoSqlEntity>(client, SwapSchedule));
        }

        private const string SwapProfile = "swap-profile";


        public static SwapProfileMyNoSqlWriter CreateSwapProfileMyNoSqlWriter(
            Func<string> getUrl)
        {
            return new SwapProfileMyNoSqlWriter(
                new MyNoSqlServerDataWriter<SwapProfileMyNoSqlEntity>(getUrl, SwapProfile, true));
        }

        public static SwapProfileMyNoSqlReader CreateSwapProfileMyNoSqlReader(this MyNoSqlTcpClient client)
        {
            return new SwapProfileMyNoSqlReader(
                new MyNoSqlReadRepository<SwapProfileMyNoSqlEntity>(client, SwapProfile));
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

        private const string AccountCache = "engine-accounts-cache";

        public static AccountsCacheNoSqlWriter CreateAccountsCacheNoSqlWriter(Func<string> getUrl, string prefix)
        {
            return new AccountsCacheNoSqlWriter(
                new MyNoSqlServerDataWriter<AccountsCacheNoSqlEntity>(getUrl,
                    $"{AccountCache}-{prefix}", true));
        }

        private const string ExposureReportTableName = "exposure-report";

        public static ExposureReportMyNoSqlRepository CreateExposureReporMyNoSqlRepository(Func<string> getUrl)
        {
            return new ExposureReportMyNoSqlRepository(
                new MyNoSqlServerDataWriter<InstrumentExposureMyNoSqlEntity>(
                    getUrl,
                    ExposureReportTableName, true));
        }

        private const string OnboardingsTableName = "onboardings";

        public static OnboardingMyNoSqlRepository CreateOnboardingMyNoSqlRepository(Func<string> getUrl) => 
            new OnboardingMyNoSqlRepository(
                new MyNoSqlServerDataWriter<OnboardingMyNoSqlTableEntity>(
                    getUrl,
                    OnboardingsTableName, true));


        public static OnboardingMyNoSqlReader CreateOnboardingMyNoSqlReader(
           this MyNoSqlTcpClient client)
        {
            return new OnboardingMyNoSqlReader(
                new MyNoSqlReadRepository<OnboardingMyNoSqlTableEntity>(client, OnboardingsTableName));
        }

        private const string TraderOnboardingTableName = "trader-onboarding";

        public static TraderOnboardingMyNoSqlRepository CreateTraderOnboardingMyNoSqlRepository(Func<string> getUrl) =>
            new TraderOnboardingMyNoSqlRepository(
                new MyNoSqlServerDataWriter<TraderOnboardingMyNoSqlTableEntity>(
                    getUrl,
                    TraderOnboardingTableName, true));

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
}