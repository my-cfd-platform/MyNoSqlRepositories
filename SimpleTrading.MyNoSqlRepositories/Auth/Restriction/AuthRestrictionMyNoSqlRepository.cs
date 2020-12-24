using System;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Auth.Restriction;

namespace SimpleTrading.MyNoSqlRepositories.Auth.Restriction
{
    public class AuthRestrictionMyNoSqlRepository : IAuthRestrictionRepository
    {
        private readonly IMyNoSqlServerDataWriter<AuthRestrictionMyNoSqlEntity> _table;

        public AuthRestrictionMyNoSqlRepository(IMyNoSqlServerDataWriter<AuthRestrictionMyNoSqlEntity> table)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
        }
        
        public async Task<IAuthRestriction> AddAsync(string emailHash, string ip, string brand, DateTime dt)
        {
            var entity = AuthRestrictionMyNoSqlEntity.Create(emailHash, ip, brand, 0, dt);

            await _table.InsertOrReplaceAsync(entity);

            return entity;
        }

        public async Task<IAuthRestriction> GetAsync(string emailHash, string ip, string brand)
        {
            var pk = AuthRestrictionMyNoSqlEntity.GeneratePartitionKey(ip);
            var rk = AuthRestrictionMyNoSqlEntity.GenerateRowKey(emailHash, brand);

            return await _table.GetAsync(pk, rk);
        }
        
        public async Task UpdateAsync(string emailHash, string ip, string brand, DateTime dt, int count)
        {
            await _table.InsertOrReplaceAsync(AuthRestrictionMyNoSqlEntity.Create(emailHash, ip, brand, count, dt));
        }
    }
}