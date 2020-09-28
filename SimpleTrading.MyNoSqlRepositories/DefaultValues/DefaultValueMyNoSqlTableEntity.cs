using MyNoSqlServer.Abstractions;

namespace SimpleTrading.MyNoSqlRepositories.DefaultValues
{
    public class DefaultValueMyNoSqlTableEntity : MyNoSqlDbEntity
    {
        public static string GeneratePartitionKey()
        {
            return "dv";
        }

        public static string GenerateRowKeyAsTradingInstrumentAvatarSvg()
        {
            return "TradingInstrumentAvatarSvg";
        }
        
        public static string GenerateRowKeyAsTradingInstrumentAvatarPng()
        {
            return "TradingInstrumentAvatarPng";
        }
        
        public static string GenerateRowKeyAsPaymentMethodSvg()
        {
            return "PaymentMethodSvg";
        }
        
        public static string GenerateRowKeyAsPaymentMethodPng()
        {
            return "PaymentMethodPng";
        }
        
        public static string GenerateRowKeyAsLiquidityProviderId()
        {
            return "LiquidityProviderId";
        }
        
        public static string GenerateRowKeyAsDefaultLanguage()
        {
            return "DefaultLanguage";
        }
        
        public static string GenerateRowKeyAsCountryOfRegistration()
        {
            return "CountryOfRegistration";
        }
        
        public static string GenerateRowKeyAsMarkupProfile()
        {
            return "MarkupProfile";
        }
        
        public static string GetRowKeyAsBackupLiquidityProviders()
        {
            return "BackupLiquidityProviders";
        }

        public string Value { get; set; }
        
        public string[] Values { get; set; }

    }
}