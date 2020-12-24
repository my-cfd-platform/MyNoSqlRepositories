using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Auth.Restriction;

namespace SimpleTrading.MyNoSqlRepositories.Auth.Restriction
{
    public class AuthRestrictionMyNoSqlReader : IAuthRestrictionReader
    {
        private readonly IMyNoSqlServerDataReader<AuthRestrictionMyNoSqlEntity> _reader;

        public AuthRestrictionMyNoSqlReader(IMyNoSqlServerDataReader<AuthRestrictionMyNoSqlEntity> reader)
        {
            _reader = reader;
        }
        
        public IAuthRestriction Get(string emailHash, string ip, string brand)
        {
            var pk = AuthRestrictionMyNoSqlEntity.GeneratePartitionKey(ip);
            var rk = AuthRestrictionMyNoSqlEntity.GenerateRowKey(emailHash, brand);

            return _reader.Get(pk, rk);
        }
    }
}