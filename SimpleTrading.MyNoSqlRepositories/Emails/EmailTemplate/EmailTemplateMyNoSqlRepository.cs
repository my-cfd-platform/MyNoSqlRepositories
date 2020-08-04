using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction;
using SimpleTrading.Abstraction.Emails;
using SimpleTrading.Abstraction.Emails.EmailTemplate;

namespace SimpleTrading.MyNoSqlRepositories.Emails.EmailTemplate
{
    public class EmailTemplatesMyNoSqlRepository : IEmailTemplatesRepository
    {
        private readonly IMyNoSqlServerDataWriter<EmailTemplatesMyNoSqlEntity> _table;

        public EmailTemplatesMyNoSqlRepository(IMyNoSqlServerDataWriter<EmailTemplatesMyNoSqlEntity> table)
        {
            _table = table;
        }
        
        public async Task SaveAsync(string brandId, EmailTypes emailType, Languages language, string templateId, string subject, string expires)
        {
            var entity = EmailTemplatesMyNoSqlEntity.Create(brandId, emailType, language, templateId, subject, expires);

            await _table.InsertOrReplaceAsync(entity);
        }

        public async Task<IEnumerable<IEmailTemplate>> GetAsync()
        {
            return await _table.GetAsync();
        }

        public async Task<IEmailTemplate> GetAsync(string brandId, EmailTypes emailType, Languages language)
        {
            var pk = EmailTemplatesMyNoSqlEntity.GeneratePartitionKey(emailType, language);
            var rk = EmailTemplatesMyNoSqlEntity.GenerateRowKey(brandId);

            return await _table.GetAsync(pk, rk);
        }
    }
}