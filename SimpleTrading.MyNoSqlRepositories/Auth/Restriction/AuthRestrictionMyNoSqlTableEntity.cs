using System;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Auth.Restriction;

namespace SimpleTrading.MyNoSqlRepositories.Auth.Restriction
{
    public class AuthRestrictionMyNoSqlTableEntity : MyNoSqlDbEntity, IAuthRestriction
    {
        public static string GeneratePartitionKey(string ip)
        {
            return ip;
        }

        public static string GenerateRowKey(string email)
        {
            return email;
        }
        
        public string Ip => PartitionKey;
        
        public int Counter { get; set; }
        
        public DateTime DateTime { get; set; }

        public string Email => RowKey;
        
        public static AuthRestrictionMyNoSqlTableEntity Create(string email, string ip, int counter, DateTime dt)
        {
            return new AuthRestrictionMyNoSqlTableEntity
            {
                PartitionKey = GeneratePartitionKey(ip),
                RowKey = GenerateRowKey(email),
                DateTime = dt,
                Counter = counter
            };
        }

        public static AuthRestrictionMyNoSqlTableEntity Create(IAuthRestriction src)
        {
            return new AuthRestrictionMyNoSqlTableEntity
            {
                PartitionKey = GeneratePartitionKey(src.Ip),
                RowKey = GenerateRowKey(src.Email),
                DateTime = src.DateTime,
                Counter = src.Counter
            };
        }
    }
}