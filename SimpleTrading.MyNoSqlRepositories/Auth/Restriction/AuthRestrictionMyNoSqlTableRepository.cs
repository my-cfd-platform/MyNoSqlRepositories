using System;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Auth.Restriction;

namespace SimpleTrading.MyNoSqlRepositories.Auth.Restriction
{
    public class AuthRestrictionMyNoSqlTableRepository : IAuthRestrictionRepository
    {
        private readonly IMyNoSqlServerDataWriter<AuthRestrictionMyNoSqlTableEntity> _table;

        public AuthRestrictionMyNoSqlTableRepository(IMyNoSqlServerDataWriter<AuthRestrictionMyNoSqlTableEntity> table)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
        }
        
        public async Task AddAsync(string email, string ip)
        {
            var entity = AuthRestrictionMyNoSqlTableEntity.Create(email, ip, 0, DateTime.Now);

            await _table.InsertOrReplaceAsync(entity);
        }

        public async Task<IAuthRestriction> GetAsync(string email, string ip)
        {
            var pk = AuthRestrictionMyNoSqlTableEntity.GeneratePartitionKey(email);
            var rk = AuthRestrictionMyNoSqlTableEntity.GenerateRowKey(ip);

            return await _table.GetAsync(pk, rk);
        }

        public async Task UpdateAsync(string email, string ip, int count, DateTime dt)
        {
            var pk = AuthRestrictionMyNoSqlTableEntity.GeneratePartitionKey(email);
            var rk = AuthRestrictionMyNoSqlTableEntity.GenerateRowKey(ip);

            var entity = await _table.GetAsync(pk, rk);

            entity.Counter = count;
            entity.DateTime = dt;
            
            await _table.InsertOrReplaceAsync(entity);
        }
    }
}