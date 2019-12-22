using System;
using System.Collections.Generic;
using MyNoSqlClient;
using MyNoSqlClient.ReadRepository;
using SimpleTrading.Abstraction.BidAsk;

namespace SimpleTrading.MyNoSqlRepositories.BidAsk
{
    public class BidAskMyNoSqlTableEntity : MyNoSqlTableEntity, IBidAsk
    {
        
        public static string GeneratePartitionKey()
        {
            return "qp";
        }
        
        public static string GenerateRowKey(string asset)
        {
            return asset;
        }
        
        public DateTime DateTime { get; set; }
        
        public string Id => RowKey;
        
        public double Bid { get; set; }
        
        public double Ask { get; set; }

    }

    

}