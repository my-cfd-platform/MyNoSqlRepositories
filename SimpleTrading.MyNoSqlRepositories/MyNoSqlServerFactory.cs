using MyNoSqlServer.TcpClient;
using MyNoSqlServer.TcpClient.ReadRepository;
using SimpleTrading.MyNoSqlRepositories.BidAsk;
using SimpleTrading.MyNoSqlRepositories.Countries;
using SimpleTrading.MyNoSqlRepositories.DefaultValues;
using SimpleTrading.MyNoSqlRepositories.InstrumentSourcesMaps;
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
            return new CountryMyNoSqlReader(connection.ToMyNoSqlReadRepository<CountryMyNoSqlTableEntity>(CountriesTable));
        }

        public static CountryMyNoSqlRepository CreateCountryMyNoSqlRepository(string url)
        {
            return new CountryMyNoSqlRepository(new MyNoSqlServerClient<CountryMyNoSqlTableEntity>(url, CountriesTable));
        }

        private const string InvestAmountTable = "investamount";

        public static InvestAmountMyNoSqlRepository CreateInvestAmountMyNoSqlRepository(string url)
        {
            return new InvestAmountMyNoSqlRepository(new MyNoSqlServerClient<InvestAmountMyNoSqlTableEntity>(url, InvestAmountTable));
        }

        public static IInvestAmountMyNoSqlReader CreateInvestAmountMyNoSqlReader(this MyNoSqlTcpClient connection)
        {
            return new InvestAmountMyNoSqlReader(connection.ToMyNoSqlReadRepository<InvestAmountMyNoSqlTableEntity>(InvestAmountTable));
        }
        
        private const string TradingGroupsTableName = "tradinggroups";

        private static string IsLivePrefix(bool isLive)
        {
            return isLive ? "live-" : "demo-";
        }

        public static TradingGroupsMyNoSqlReader CreateTradingGroupsMyNoSqlReader(this MyNoSqlTcpClient connection, bool isLive)
        {
            return new TradingGroupsMyNoSqlReader(new MyNoSqlReadRepository<TradingGroupMyNoSqlEntity>(connection, IsLivePrefix(isLive)+TradingGroupsTableName));
        }
        
        public static TradingGroupsMyNoSqlRepository CreateTradingGroupsMyNoSqlRepository(string url, bool isLive)
        {
            return new TradingGroupsMyNoSqlRepository(new MyNoSqlServerClient<TradingGroupMyNoSqlEntity>(url, IsLivePrefix(isLive)+TradingGroupsTableName));
        }
        
        private const string TradingProfilesTableName = "tradingprofiles";
        public static TradingProfileMyNoSqlReader CreateTradingProfileMyNoSqlReader(this MyNoSqlTcpClient connection, bool isLive)
        {
            return new TradingProfileMyNoSqlReader(new MyNoSqlReadRepository<TradingProfileMyNoSqlEntity>(connection, IsLivePrefix(isLive)+TradingProfilesTableName));
        }
        
        public static TradingProfilesMyNoSqlRepository CreateTradingProfilesMyNoSqlRepository(string url, bool isLive)
        {
            return new TradingProfilesMyNoSqlRepository(new MyNoSqlServerClient<TradingProfileMyNoSqlEntity>(url, IsLivePrefix(isLive)+TradingProfilesTableName));
        }

        private const string DefaultsValuesTable = "defaultvalues";

        public static DefaultValuesMyNoSqlRepository CreateDefaultValueMyNoSqlRepository(string url)
        {
            return new DefaultValuesMyNoSqlRepository(new MyNoSqlServerClient<DefaultValueMyNoSqlTableEntity>(url, DefaultsValuesTable));
        }

        public static DefaultValuesNoMySqlReader CreateDefaultValuesNoMySqlReader(this MyNoSqlTcpClient connection)
        {
            return new DefaultValuesNoMySqlReader(new MyNoSqlReadRepository<DefaultValueMyNoSqlTableEntity>(connection, DefaultsValuesTable));
        }

        private const string FavoriteInstrumentsTable = "favoriteinstruments";

        private const string InstrumentsTable = "instruments";
        
        public static InstrumentsMyNoSqlReadCache CreateInstrumentsMyNoSqlReadCache(this MyNoSqlTcpClient connection)
        {
            return new InstrumentsMyNoSqlReadCache(new MyNoSqlReadRepository<TradingInstrumentMyNoSqlEntity>(connection, InstrumentsTable));
        }
        
        public static TradingInstrumentsMyNoSqlRepository CreateTradingInstrumentsMyNoSqlRepository(string url)
        {
            return new TradingInstrumentsMyNoSqlRepository(new MyNoSqlServerClient<TradingInstrumentMyNoSqlEntity>(url, InstrumentsTable));
        }

        private const string InstrumentGroupsTable = "instrumentsgroups";

        public static InstrumentGroupsMyNoSqlRepository CreateInstrumentGroupsMyNoSqlRepository(string url)
        {
            return new InstrumentGroupsMyNoSqlRepository(new MyNoSqlServerClient<InstrumentGroupMyNoSqlEntity>(url, InstrumentGroupsTable));
        }

        public static InstrumentGroupsMyNoSqlReadCache CreateInstrumentGroupsMyNoSqlReadCache(this MyNoSqlTcpClient connection)
        {
            return new InstrumentGroupsMyNoSqlReadCache(new MyNoSqlReadRepository<InstrumentGroupMyNoSqlEntity>(connection, InstrumentGroupsTable));
        }

        private const string PriceChangesTable = "pricechanges";

        public static PriceChangeWriteRepository CreatePriceChangeWriteRepository(
            string url)
        {
            return new PriceChangeWriteRepository(new MyNoSqlServerClient<PriceChangeMyNoSqlEntity>(url, PriceChangesTable));
        }

        public static PriceChangeReader CreatePriceChangeReader(this MyNoSqlTcpClient client)
        {
            return new PriceChangeReader(
                new MyNoSqlReadRepository<PriceChangeMyNoSqlEntity>(client, PriceChangesTable));
        }
        
        private const string SwapSchedule = "swap-schedule";
        
        
        public static SwapScheduleMyNoSqlRepository CreateSwapScheduleMyNoSqlRepository(
            string url)
        {
            return new SwapScheduleMyNoSqlRepository(
                new MyNoSqlServerClient<SwapScheduleMyNoSqlEntity>(url, SwapSchedule));
        }

        public static SwapScheduleMyNoSqlReader CreateSwapScheduleMyNoSqlReader(this MyNoSqlTcpClient client)
        {
            return new SwapScheduleMyNoSqlReader(
                new MyNoSqlReadRepository<SwapScheduleMyNoSqlEntity>(client, SwapSchedule));
        }

        private const string SwapProfile = "swap-profile";
        
        
        public static SwapProfileMyNoSqlWriter CreateSwapProfileMyNoSqlWriter(
            string url)
        {
            return new SwapProfileMyNoSqlWriter(
                new MyNoSqlServerClient<SwapProfileMyNoSqlEntity>(url, SwapProfile));
        }

        public static SwapProfileMyNoSqlReader CreateSwapProfileMyNoSqlReader(this MyNoSqlTcpClient client)
        {
            return new SwapProfileMyNoSqlReader(
                new MyNoSqlReadRepository<SwapProfileMyNoSqlEntity>(client, SwapProfile));
        }
        
        private const string InstrumetSourceMap = "instrument-sources";

        public static InstrumentSourcesMapsMyNoSqlReader CreateInstrumetSourceMapMyNoSqlReader(this MyNoSqlTcpClient client)
        {
            return new InstrumentSourcesMapsMyNoSqlReader(
                new MyNoSqlReadRepository<InstrumentSourcesMapsMyNoSqlTableEntity>(client, InstrumetSourceMap));
        }
    }
    
    public static class MyNoSqlServerUtils
    {
        public static IMyNoSqlReadRepository<T> ToMyNoSqlReadRepository<T>(this IMyNoSqlSubscriber connection, string tableName) 
            where T : IMyNoSqlTableEntity
        {
            return new MyNoSqlReadRepository<T>(connection, tableName);
        }

    }
}