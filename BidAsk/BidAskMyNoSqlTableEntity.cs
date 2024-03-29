﻿using MyNoSqlRepositories.Abstraction.BidAsk;
using MyNoSqlServer.Abstractions;

namespace MyNoSqlRepositories.BidAsk;

public class BidAskMyNoSqlTableEntity : MyNoSqlDbEntity, IBidAsk
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
        
    public string Id
    {
        get => RowKey;
        set => RowKey = value;
    }

    public double Bid { get; set; }
        
    public double Ask { get; set; }
}