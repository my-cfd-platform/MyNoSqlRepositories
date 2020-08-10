using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction;
using SimpleTrading.Abstraction.Emails;
using SimpleTrading.Abstraction.Emails.EmailTemplate;
using SimpleTrading.Abstraction.Platforms;

namespace SimpleTrading.MyNoSqlRepositories.Emails.EmailTemplate
{
    public class EmailTemplatesMyNoSqlEntity : MyNoSqlDbEntity, IEmailTemplate
    {
        public static string GeneratePartitionKey(EmailTypes emailType, Languages lang, PlatformTypes platform)
        {
            return $"{emailType.ToString()}-{lang.ToString()}-{platform.ToString()}";
        }
        
        public static string GenerateRowKey(string brandId)
        {
            return brandId;
        }
        
        public string BrandId => RowKey;
        
        public string EmailUrl { get; set; }

        public EmailTypes EmailType { get; set; }
        
        public Languages Language { get; set; }
        
        public string TemplateId { get; set; }
        
        public string Subject { get; set; }
        
        public string TokenExpires { get; set; }
        
        public PlatformTypes Platform { get; set; }

        public static EmailTemplatesMyNoSqlEntity Create(string brandId, EmailTypes emailType, Languages language, string templateId, string subject, string tokenExpires, string emailUrl, PlatformTypes platform)
        {
            return new EmailTemplatesMyNoSqlEntity
            {
                RowKey = GenerateRowKey(brandId),
                PartitionKey = GeneratePartitionKey(emailType, language, platform),
                EmailType = emailType,
                Language = language,
                TemplateId = templateId,
                Subject = subject,
                TokenExpires = tokenExpires,
                EmailUrl = emailUrl
            };
        }
    }
}