using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction;
using SimpleTrading.Abstraction.Emails;
using SimpleTrading.Abstraction.Emails.EmailTemplate;

namespace SimpleTrading.MyNoSqlRepositories.Emails.EmailTemplate
{
    public class EmailTemplatesMyNoSqlEntity : MyNoSqlDbEntity, IEmailTemplate
    {
        public static string GeneratePartitionKey(EmailTypes emailType, Languages lang)
        {
            return $"{emailType.ToString()}-{lang.ToString()}";
        }
        
        public static string GenerateRowKey(string brandId)
        {
            return brandId;
        }
        
        public string BrandId => RowKey;
        
        public EmailTypes EmailType { get; set; }
        
        public Languages Language { get; set; }
        
        public string TemplateId { get; set; }

        public static EmailTemplatesMyNoSqlEntity Create(string brandId, EmailTypes emailType, Languages language, string templateId)
        {
            return new EmailTemplatesMyNoSqlEntity
            {
                RowKey = GenerateRowKey(brandId),
                PartitionKey = GeneratePartitionKey(emailType, language),
                EmailType = emailType,
                Language = language,
                TemplateId = templateId
            };
        }
    }
}