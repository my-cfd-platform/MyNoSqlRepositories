using System;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.DefaultValues;

namespace SimpleTrading.MyNoSqlRepositories.DefaultValues
{
    public class DefaultValuesMyNoSqlReader : IDefaultValuesReader, ILiquidityProviderReader, IMarkupProfileReader
    {
        private readonly IMyNoSqlServerDataReader<DefaultValueMyNoSqlTableEntity> _readRepository;

        public DefaultValuesMyNoSqlReader(IMyNoSqlServerDataReader<DefaultValueMyNoSqlTableEntity> readRepository)
        {
            _readRepository = readRepository ?? throw new ArgumentNullException(nameof(readRepository));
        }


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

        string ILiquidityProviderReader.Get()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsLiquidityProviderId();
            return _readRepository.Get(pk, rk)?.Value;
        }

        string IMarkupProfileReader.Get()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsMarkupProfile();
            return _readRepository.Get(pk, rk)?.Value;
        }
    }
}