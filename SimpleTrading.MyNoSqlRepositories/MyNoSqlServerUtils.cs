using MyNoSqlClient;
using MyNoSqlClient.ReadRepository;

namespace SimpleTrading.MyNoSqlRepositories
{
    public static class MyNoSqlServerUtils
    {
        public static IMyNoSqlReadRepository<T> ToMyNoSqlReadRepository<T>(this IMyNoSqlConnection connection, string tableName) where T : IMyNoSqlTableEntity
        {
            return new MyNoSqlReadRepository<T>(connection, tableName);
        }    
    }
}