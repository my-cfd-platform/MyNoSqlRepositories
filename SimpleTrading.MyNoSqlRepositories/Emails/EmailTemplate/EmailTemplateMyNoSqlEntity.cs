using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Emails;
using SimpleTrading.Abstraction.Emails.EmailTemplate;
using SimpleTrading.Abstraction.Platforms;

namespace SimpleTrading.MyNoSqlRepositories.Emails.EmailTemplate
{
    public class EmailTemplatesMyNoSqlEntity : MyNoSqlDbEntity, IEmailTemplate
    {
        public static string GeneratePartitionKey(string brandId)
        {
            return brandId;
        }
        
        public static string GenerateRowKey(EmailTypes emailType, string lang, PlatformTypes platform)
        {
            return $"{emailType.ToString()}-{lang}-{platform.ToString()}";;
        }
        
        public string BrandId => PartitionKey;
        
        public string EmailUrl { get; set; }

        public EmailTypes EmailType { get; set; }
        
        public string Language { get; set; }
        
        public string TemplateId { get; set; }
        
        public string Subject { get; set; }
        
        public string TokenExpires { get; set; }
        
        public PlatformTypes Platform { get; set; }

        public static EmailTemplatesMyNoSqlEntity Create(string brandId, EmailTypes emailType, string language, string templateId, string subject, string tokenExpires, string emailUrl, PlatformTypes platform)
        {
            return new EmailTemplatesMyNoSqlEntity
            {
                RowKey = GenerateRowKey(emailType, language, platform),
                PartitionKey = GeneratePartitionKey(brandId),
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