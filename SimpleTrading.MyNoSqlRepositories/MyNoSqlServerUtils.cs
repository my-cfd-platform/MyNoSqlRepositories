using MyNoSqlClient;
using MyNoSqlClient.ReadRepository;
using SimpleTrading.MyNoSqlRepositories.Countries;

namespace SimpleTrading.MyNoSqlRepositories
{
    public static class MyNoSqlServerFactory
    {
        public static BidAskMyNoSqlCache CreateBidAskMyNoSqlCache(this IMyNoSqlConnection connection)
        {
            return new BidAskMyNoSqlCache(connection.ToMyNoSqlReadRepository<BidAskMyNoSqlTableEntity>("quoteprofile"));
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