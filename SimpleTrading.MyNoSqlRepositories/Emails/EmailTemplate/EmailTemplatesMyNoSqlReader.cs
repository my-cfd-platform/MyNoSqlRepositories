using System.Collections.Generic;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Emails;
using SimpleTrading.Abstraction.Emails.EmailTemplate;
using SimpleTrading.Abstraction.Platforms;

namespace SimpleTrading.MyNoSqlRepositories.Emails.EmailTemplate
{
    public class EmailTemplatesMyNoSqlReader : IEmailTemplatesReader
    {
        private readonly IMyNoSqlServerDataReader<EmailTemplatesMyNoSqlEntity> _reader;
        
        public EmailTemplatesMyNoSqlReader(IMyNoSqlServerDataReader<EmailTemplatesMyNoSqlEntity> reader)
        {
            _reader = reader;
        }
        
        public IEnumerable<IEmailTemplate> Get()
        {
            return _reader.Get();
        }

        public IEnumerable<IEmailTemplate> GetByBrand(string brandId)
        {
            var pk = EmailTemplatesMyNoSqlEntity.GeneratePartitionKey(brandId);

            return _reader.Get(pk);
        }
        
        public IEmailTemplate Get(string brandId, EmailTypes emailType, string language, PlatformTypes platform)
        {
            var pk = EmailTemplatesMyNoSqlEntity.GeneratePartitionKey(brandId);
            var rk = EmailTemplatesMyNoSqlEntity.GenerateRowKey(emailType, language, platform);
            
            return _reader.Get(pk, rk);
        }
    }
}