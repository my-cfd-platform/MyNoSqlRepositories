using MyNoSqlClient;
using MyNoSqlClient.ReadRepository;
using SimpleTrading.MyNoSqlRepositories.Countries;
using SimpleTrading.MyNoSqlRepositories.Instruments;
using SimpleTrading.MyNoSqlRepositories.TradingGroups;

namespace SimpleTrading.MyNoSqlRepositories
{
    public static class MyNoSqlServerFactory
    {
        public static BidAskMyNoSqlCache CreateBidAskMyNoSqlCache(this IMyNoSqlConnection connection)
        {
            return new BidAskMyNoSqlCache(connection.ToMyNoSqlReadRepository<BidAskMyNoSqlTableEntity>("quoteprofile"));
        }

        private const string InstrumentsTable = "instruments";
        
        public static InstrumentsMyNoSqlReadCache CreateInstrumentsMyNoSqlReadCache(this IMyNoSqlConnection connection)
        {
            return new InstrumentsMyNoSqlReadCache(connection.ToMyNoSqlReadRepository<TradingInstrumentMyNoSqlEntity>(InstrumentsTable));
        }
        
        public static TradingInstrumentsMyNoSqlRepository CreateTradingInstrumentsMyNoSqlRepository(this IMyNoSqlConnection connection)
        {
            return new TradingInstrumentsMyNoSqlRepository(
                new MyNoSqlServerClient<TradingInstrumentMyNoSqlEntity>(connection, InstrumentsTable));
        }


        private const string TradingGroupsTable = "trading-groups";
        public static TradingGroupsMyNoSqlReader CreateTradingGroupsMyNoSqlReader(this IMyNoSqlConnection connection)
        {
            return new TradingGroupsMyNoSqlReader(connection.ToMyNoSqlReadRepository<TradingGroupMyNoSqlEntity>(TradingGroupsTable));
        }

        public static TradingGroupsMyNoSqlRepository CreateTradingGroupsMyNoSqlRepository(
            this IMyNoSqlConnection connection)
        {
            return new TradingGroupsMyNoSqlRepository(
                new MyNoSqlServerClient<TradingGroupMyNoSqlEntity>(connection, TradingGroupsTable));
        }

        private const string CountriesTable = "countries";

        public static CountryMyNoSqlReader CreateCountryMyNoSqlReader(this IMyNoSqlConnection connection)
        {
            return new CountryMyNoSqlReader(connection.ToMyNoSqlReadRepository<CountryMyNoSqlTableEntity>(CountriesTable));
        }

        public static CountryMyNoSqlRepository CreateCountryMyNoSqlRepository(this IMyNoSqlConnection connection)
        {
            return new CountryMyNoSqlRepository(new MyNoSqlServerClient<CountryMyNoSqlTableEntity>(connection, CountriesTable));
        }
    }
    
    public static class MyNoSqlServerUtils
    {
        public static IMyNoSqlReadRepository<T> ToMyNoSqlReadRepository<T>(this IMyNoSqlConnection connection, string tableName) 
            where T : IMyNoSqlTableEntity
        {
            return new MyNoSqlReadRepository<T>(connection, tableName);
        }  
        
 
    }
    
}