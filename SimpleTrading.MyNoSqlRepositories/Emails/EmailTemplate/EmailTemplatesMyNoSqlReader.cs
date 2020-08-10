using System.Collections.Generic;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction;
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
        
        public IEmailTemplate Get(string brandId, EmailTypes emailType, Languages language, PlatformTypes platform)
        {
            var pk = EmailTemplatesMyNoSqlEntity.GeneratePartitionKey(emailType, language, platform);
            var rk = EmailTemplatesMyNoSqlEntity.GenerateRowKey(brandId);
            
            return _reader.Get(pk, rk);
        }
    }
}