using System.Collections.Generic;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction;
using SimpleTrading.Abstraction.Emails;
using SimpleTrading.Abstraction.Emails.EmailTemplate;
using SimpleTrading.Abstraction.Platforms;

namespace SimpleTrading.MyNoSqlRepositories.Emails.EmailTemplate
{
    public class EmailTemplatesMyNoSqlRepository : IEmailTemplatesRepository
    {
        private readonly IMyNoSqlServerDataWriter<EmailTemplatesMyNoSqlEntity> _table;

        public EmailTemplatesMyNoSqlRepository(IMyNoSqlServerDataWriter<EmailTemplatesMyNoSqlEntity> table)
        {
            _table = table;
        }
        
        public async Task SaveAsync(string brandId, EmailTypes emailType, Languages language, PlatformTypes platform, string templateId, string subject, string expires, string redirectUrl)
        {
            var entity = EmailTemplatesMyNoSqlEntity.Create(brandId, emailType, language, templateId, subject, expires, redirectUrl, platform);

            await _table.InsertOrReplaceAsync(entity);
        }

        public async Task<IEnumerable<IEmailTemplate>> GetAsync()
        {
            return await _table.GetAsync();
        }

        public async Task<IEmailTemplate> GetAsync(string brandId, EmailTypes emailType, Languages language, PlatformTypes platform)
        {
            var pk = EmailTemplatesMyNoSqlEntity.GeneratePartitionKey(emailType, language, platform);
            var rk = EmailTemplatesMyNoSqlEntity.GenerateRowKey(brandId);

            return await _table.GetAsync(pk, rk);
        }
    }
}