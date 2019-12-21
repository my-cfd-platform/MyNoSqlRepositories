using MyNoSqlClient;
using MyNoSqlClient.ReadRepository;
using MyNoSqlClient.SignalR;
using MyNoSqlClient.Tcp;
using SimpleTrading.MyNoSqlRepositories.Countries;

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