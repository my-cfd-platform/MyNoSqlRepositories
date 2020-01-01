using MyNoSqlClient;
using MyNoSqlClient.ReadRepository;
using MyNoSqlClient.SignalR;
using MyNoSqlClient.Tcp;
using SimpleTrading.MyNoSqlRepositories.BidAsk;
using SimpleTrading.MyNoSqlRepositories.Countries;
using SimpleTrading.MyNoSqlRepositories.Trading.Instruments;
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

        public static CountryMyNoSqlRepository CreateCountryMyNoSqlRepository(this MyNoSqlSignalRConnection connection)
        {
            return new CountryMyNoSqlRepository(new MyNoSqlServerClient<CountryMyNoSqlTableEntity>(connection, CountriesTable));
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
        
        public static TradingGroupsMyNoSqlRepository CreateTradingGroupsMyNoSqlRepository(this MyNoSqlSignalRConnection connection, bool isLive)
        {
            return new TradingGroupsMyNoSqlRepository(new MyNoSqlServerClient<TradingGroupMyNoSqlEntity>(connection, IsLivePrefix(isLive)+TradingGroupsTableName));
        }
        
        private const string TradingProfilesTableName = "tradingprofiles";
        public static TradingProfileMyNoSqlReader CreateTradingProfileMyNoSqlReader(this MyNoSqlTcpClient connection, bool isLive)
        {
            return new TradingProfileMyNoSqlReader(new MyNoSqlReadRepository<TradingProfileMyNoSqlEntity>(connection, IsLivePrefix(isLive)+TradingProfilesTableName));
        }
        
        public static TradingProfilesMyNoSqlRepository CreateTradingProfilesMyNoSqlRepository(this MyNoSqlSignalRConnection connection, bool isLive)
        {
            return new TradingProfilesMyNoSqlRepository(new MyNoSqlServerClient<TradingProfileMyNoSqlEntity>(connection, IsLivePrefix(isLive)+TradingProfilesTableName));
        }
        
        private const string InstrumentsTable = "instruments";
        
        public static InstrumentsMyNoSqlReadCache CreateInstrumentsMyNoSqlReadCache(this MyNoSqlTcpClient connection)
        {
            return new InstrumentsMyNoSqlReadCache(new MyNoSqlReadRepository<TradingInstrumentMyNoSqlEntity>(connection, InstrumentsTable));
        }
        
        public static TradingInstrumentsMyNoSqlRepository CreateTradingInstrumentsMyNoSqlRepository(this MyNoSqlSignalRConnection connection)
        {
            return new TradingInstrumentsMyNoSqlRepository(new MyNoSqlServerClient<TradingInstrumentMyNoSqlEntity>(connection, InstrumentsTable));
        }


        private const string PriceChangesTable = "pricechanges";

        public static PriceChangeWriteRepository CreatePriceChangeWriteRepository(
            this MyNoSqlSignalRConnection connection)
        {
            return new PriceChangeWriteRepository(new MyNoSqlServerClient<PriceChangeMyNoSqlEntity>(connection, PriceChangesTable));
        }

        public static PriceChangeReader CreatePriceChangeReader(this MyNoSqlTcpClient client)
        {
            return new PriceChangeReader(
                new MyNoSqlReadRepository<PriceChangeMyNoSqlEntity>(client, PriceChangesTable));
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