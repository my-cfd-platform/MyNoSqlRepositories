using System;
using System.Threading.Tasks;
using MyNoSqlServer.DataReader;
using Newtonsoft.Json;
using SimpleTrading.MyNoSqlRepositories;

namespace SimpleTrading.MyNoSql.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tcpConnection = new MyNoSqlTcpClient(() => 
                "127.0.0.1:5125", "local");
            
            var pendingOrdersCache = tcpConnection.CreatePendingOrdersCacheReader(true);
            pendingOrdersCache.BindEventSubscribers(itm =>
            {
                System.Console.WriteLine("update");
                System.Console.WriteLine(JsonConvert.SerializeObject(itm));
            }, itms =>
            {
                System.Console.WriteLine("Delete");
                System.Console.WriteLine(JsonConvert.SerializeObject(itms));
            });
            
            tcpConnection.Start();
            await Task.Delay(int.MaxValue);
        }
    }
}