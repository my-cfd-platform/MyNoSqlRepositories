using MyNoSqlClient;
using MyNoSqlClient.ReadRepository;
using SimpleTrading.MyNoSqlRepositories.Instruments;

namespace SimpleTrading.MyNoSqlRepositories
{

    public static class MyNoSqlServerFactory
    {
        public static BidAskMyNoSqlCache CreateBidAskMyNoSqlCache(this IMyNoSqlConnection connection)
        {
            return new BidAskMyNoSqlCache(connection.ToMyNoSqlReadRepository<BidAskMyNoSqlTableEntity>("quoteprofile"));
        }
        
        public static InstrumentsMyNoSqlReadCache CreateInstrumentsMyNoSqlReadCache(this IMyNoSqlConnection connection)
        {
            return new InstrumentsMyNoSqlReadCache(connection.ToMyNoSqlReadRepository<TradingInstrumentMyNoSqlEntity>("instruments"));
        }
        
        public static TradingInstrumentsMyNoSqlRepository CreateTradingInstrumentsMyNoSqlRepository(this IMyNoSqlConnection connection)
        {
            return new TradingInstrumentsMyNoSqlRepository(new MyNoSqlServerClient<TradingInstrumentMyNoSqlEntity>(connection, "instruments"));
        }
        
    }
    
    public static class MyNoSqlServerUtils
    {
        public static IMyNoSqlReadRepository<T> ToMyNoSqlReadRepository<T>(this IMyNoSqlConnection connection, string tableName) where T : IMyNoSqlTableEntity
        {
            return new MyNoSqlReadRepository<T>(connection, tableName);
        }  
 
    }
    
}