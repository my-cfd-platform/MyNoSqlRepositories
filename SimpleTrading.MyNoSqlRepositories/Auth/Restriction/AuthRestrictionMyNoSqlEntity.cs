using System;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Auth.Restriction;

namespace SimpleTrading.MyNoSqlRepositories.Auth.Restriction
{
    public class AuthRestrictionMyNoSqlEntity : MyNoSqlDbEntity, IAuthRestriction
    {
        public static string GeneratePartitionKey(string ip)
        {
            return ip;
        }

        public static string GenerateRowKey(string emailHash, string brand)
        {
            return $"{emailHash}-{brand}";
        }

        public string EmailHash { get; set; }
        public string Ip => PartitionKey;
        
        public string Brand { get; set; }
        
        public int Count { get; set; }
        
        public DateTime DateTime { get; set; }
        
        public static AuthRestrictionMyNoSqlEntity Create(string emailHash, string ip, string brand, int count, DateTime dt)
        {
            return new AuthRestrictionMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(ip),
                RowKey = GenerateRowKey(emailHash, brand),
                EmailHash = emailHash,
                Brand = brand,
                DateTime = dt,
                Count = count
            };
        }
    }
}