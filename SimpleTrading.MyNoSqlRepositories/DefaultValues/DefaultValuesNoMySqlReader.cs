using System;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Common.Default;

namespace SimpleTrading.MyNoSqlRepositories.DefaultValues
{
    public class DefaultValuesNoMySqlReader : IDefaultValuesReader
    {
        private readonly IMyNoSqlServerDataReader<DefaultValueMyNoSqlTableEntity> _readRepository;

        public DefaultValuesNoMySqlReader(IMyNoSqlServerDataReader<DefaultValueMyNoSqlTableEntity> readRepository)
        {
            _readRepository = readRepository ?? throw new ArgumentNullException(nameof(readRepository));
        }

        /*
        public IDefaultValue Get(DefaultValueTypes type)
        {
            var partitionKey = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rowKey = DefaultValueMyNoSqlTableEntity.GenerateRowKey(type);

            return _readRepository.Get(partitionKey, rowKey);
        }
        */
        public string GetTradingInstrumentAvatarSvg()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsTradingInstrumentAvatarSvg();
            return _readRepository.Get(pk, rk)?.Value;
        }

        public string GetTradingInstrumentAvatarPng()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsTradingInstrumentAvatarPng();
            return _readRepository.Get(pk, rk)?.Value;
        }

        public string GetPaymentMethodSvg()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsPaymentMethodSvg();
            return _readRepository.Get(pk, rk)?.Value;
        }

        public string GetPaymentMethodPng()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsPaymentMethodPng();
            return _readRepository.Get(pk, rk)?.Value;
        }

        public string GetLiquidityProviderId()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsLiquidityProviderId();
            return _readRepository.Get(pk, rk)?.Value;
        }

        public string GetDefaultLanguage()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsDefaultLanguage();
            return _readRepository.Get(pk, rk)?.Value;
        }

        public string GetCountryOfRegistration()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsCountryOfRegistration();
            return _readRepository.Get(pk, rk)?.Value;
        }

        public string GetMarkupProfile()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsMarkupProfile();
            return _readRepository.Get(pk, rk)?.Value;
        }
    }
}