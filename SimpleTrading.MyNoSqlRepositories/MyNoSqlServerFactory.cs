using System;
using MyNoSqlServer.TcpClient;
using MyNoSqlServer.TcpClient.ReadRepository;
using SimpleTrading.MyNoSqlRepositories.BidAsk;
using SimpleTrading.MyNoSqlRepositories.Countries;
using SimpleTrading.MyNoSqlRepositories.DefaultValues;
using SimpleTrading.MyNoSqlRepositories.InstrumentSourcesMaps;
using SimpleTrading.MyNoSqlRepositories.KeyValue;
using SimpleTrading.MyNoSqlRepositories.KeyValue.FavoriteInstruments;
using SimpleTrading.MyNoSqlRepositories.Markups;
using SimpleTrading.MyNoSqlRepositories.Swaps;
using SimpleTrading.MyNoSqlRepositories.Trading.Instruments;
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
                new MyNoSqlServerClient<CountryMyNoSqlTableEntity>(getUrl, CountriesTable));
        }

        private const string InvestAmountTable = "investamount";

        public static InvestAmountMyNoSqlRepository CreateInvestAmountMyNoSqlRepository(Func<string> getUrl)
        {
            return new InvestAmountMyNoSqlRepository(
                new MyNoSqlServerClient<InvestAmountMyNoSqlTableEntity>(getUrl, InvestAmountTable));
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
                new MyNoSqlServerClient<TradingGroupMyNoSqlEntity>(getUrl,
                    IsLivePrefix(isLive) + TradingGroupsTableName));
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
                new MyNoSqlServerClient<TradingProfileMyNoSqlEntity>(getUrl,
                    IsLivePrefix(isLive) + TradingProfilesTableName));
        }

        private const string DefaultsValuesTable = "defaultvalues";

        public static DefaultValuesMyNoSqlRepository CreateDefaultValueMyNoSqlRepository(Func<string> getUrl)
        {
            return new DefaultValuesMyNoSqlRepository(
                new MyNoSqlServerClient<DefaultValueMyNoSqlTableEntity>(getUrl, DefaultsValuesTable));
        }

        public static DefaultValuesNoMySqlReader CreateDefaultValuesNoMySqlReader(this MyNoSqlTcpClient connection)
        {
            return new DefaultValuesNoMySqlReader(
                new MyNoSqlReadRepository<DefaultValueMyNoSqlTableEntity>(connection, DefaultsValuesTable));
        }

        private const string FavoriteInstrumentsTable = "favoriteinstruments";

        private const string InstrumentsTable = "instruments";

        public static InstrumentsMyNoSqlReadCache CreateInstrumentsMyNoSqlReadCache(this MyNoSqlTcpClient connection)
        {
            return new InstrumentsMyNoSqlReadCache(
                new MyNoSqlReadRepository<TradingInstrumentMyNoSqlEntity>(connection, InstrumentsTable));
        }

        public static TradingInstrumentsMyNoSqlRepository CreateTradingInstrumentsMyNoSqlRepository(Func<string> getUrl)
        {
            return new TradingInstrumentsMyNoSqlRepository(
                new MyNoSqlServerClient<TradingInstrumentMyNoSqlEntity>(getUrl, InstrumentsTable));
        }

        private const string InstrumentGroupsTable = "instrumentsgroups";

        public static InstrumentGroupsMyNoSqlRepository CreateInstrumentGroupsMyNoSqlRepository(Func<string> getUrl)
        {
            return new InstrumentGroupsMyNoSqlRepository(
                new MyNoSqlServerClient<InstrumentGroupMyNoSqlEntity>(getUrl, InstrumentGroupsTable));
        }

        public static InstrumentGroupsMyNoSqlReadCache CreateInstrumentGroupsMyNoSqlReadCache(
            this MyNoSqlTcpClient connection)
        {
            return new InstrumentGroupsMyNoSqlReadCache(
                new MyNoSqlReadRepository<InstrumentGroupMyNoSqlEntity>(connection, InstrumentGroupsTable));
        }

        private const string PriceChangesTable = "pricechanges";

        public static PriceChangeWriteRepository CreatePriceChangeWriteRepository(
            Func<string> getUrl)
        {
            return new PriceChangeWriteRepository(
                new MyNoSqlServerClient<PriceChangeMyNoSqlEntity>(getUrl, PriceChangesTable));
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
                new MyNoSqlServerClient<SwapScheduleMyNoSqlEntity>(getUrl, SwapSchedule));
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
                new MyNoSqlServerClient<SwapProfileMyNoSqlEntity>(getUrl, SwapProfile));
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
                new MyNoSqlServerClient<InstrumentSourcesMapsMyNoSqlTableEntity>(getUrl, InstrumentSourceMap));
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
                new MyNoSqlServerClient<MarkupProfileMyNoSqlTableEntity>(getUrl, MarkupProfiles));
        }

        private const string KeyValue = "key-value";

        public static KeyValueMyNoSqlReader CreateKeyValueMyNoSqlReader(
            this MyNoSqlTcpClient client)
        {
            return new KeyValueMyNoSqlReader(
                new MyNoSqlReadRepository<KeyValueMyNoSqlTableEntity>(client, KeyValue));
        }

        public static KeyValueMyNoSqlRepository CreateKeyValueNoSqlRepository(Func<string> getUrl)
        {
            return new KeyValueMyNoSqlRepository(
                new MyNoSqlServerClient<KeyValueMyNoSqlTableEntity>(getUrl, MarkupProfiles));
        }

        private const string KeyValueFavoriteInstruments = "key-value-favorite-instruments";

        public static KeyValueFavoriteInstrumentsMyNoSqlReader CreateKeyValueFavoriteInstrumentsMyNoSqlReader(
            this MyNoSqlTcpClient client)
        {
            return new KeyValueFavoriteInstrumentsMyNoSqlReader(
                new MyNoSqlReadRepository<KeyValueFavoriteInstrumentsMyNoSqlTableEntity>(client,
                    KeyValueFavoriteInstruments));
        }

        public static KeyValueFavoriteInstrumentsMyNoSqlRepository CreateKeyValueFavoriteInstrumentsNoSqlRepository(
            Func<string> getUrl)
        {
            return new KeyValueFavoriteInstrumentsMyNoSqlRepository(
                new MyNoSqlServerClient<KeyValueFavoriteInstrumentsMyNoSqlTableEntity>(getUrl,
                    KeyValueFavoriteInstruments));
        }
    }

    public static class MyNoSqlServerUtils
    {
        public static IMyNoSqlReadRepository<T> ToMyNoSqlReadRepository<T>(this IMyNoSqlSubscriber connection,
            string tableName)
            where T : IMyNoSqlTableEntity
        {
            return new MyNoSqlReadRepository<T>(connection, tableName);
        }
    }
}