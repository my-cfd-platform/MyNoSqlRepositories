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
        
        public async Task<IAuthRestriction> AddAsync(string email, string ip, DateTime dateTime)
        {
            var entity = AuthRestrictionMyNoSqlTableEntity.Create(email, ip, 0, dateTime);

            await _table.InsertOrReplaceAsync(entity);

            return entity;
        }

        public async Task<IAuthRestriction> GetAsync(string email, string ip, DateTime dateTime)
        {
            var pk = AuthRestrictionMyNoSqlTableEntity.GeneratePartitionKey(email);
            var rk = AuthRestrictionMyNoSqlTableEntity.GenerateRowKey(ip);

            var entity = await _table.GetAsync(pk, rk);
            
            if (entity != null)
                return entity;

            var createdEntity = await AddAsync(email, ip, dateTime);
            
            return createdEntity;
        }

        public async Task UpdateAsync(IAuthRestriction restriction)
        {
            var entity = AuthRestrictionMyNoSqlTableEntity.Create(restriction);
            
            await _table.InsertOrReplaceAsync(entity);
        }
    }
}