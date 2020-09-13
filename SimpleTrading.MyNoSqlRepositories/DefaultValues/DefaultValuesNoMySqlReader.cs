using System;
using System.Collections.Generic;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.DefaultValues;
using SimpleTrading.QuotesFeedRouter.Abstractions;

namespace SimpleTrading.MyNoSqlRepositories.DefaultValues
{
    public class DefaultValuesMyNoSqlReader : IDefaultValuesReader, IDefaultLiquidityProviderReader, 
        IDefaultMarkupProfileReader, IDefaultBackupLiquidityProvidersReader, IQuotesFeedRouterBackupTimeoutReader
    {
        private readonly IMyNoSqlServerDataReader<DefaultValueMyNoSqlTableEntity> _readRepository;
        private readonly IMyNoSqlServerDataReader<QuotesFeedRouterBackupTimeoutEntity> _quoteFeedRouterBackupTimeout;

        public DefaultValuesMyNoSqlReader(IMyNoSqlServerDataReader<DefaultValueMyNoSqlTableEntity> readRepository,
            IMyNoSqlServerDataReader<QuotesFeedRouterBackupTimeoutEntity> quoteFeedRouterBackupTimeout)
        {
            _readRepository = readRepository ?? throw new ArgumentNullException(nameof(readRepository));
            _quoteFeedRouterBackupTimeout = quoteFeedRouterBackupTimeout;
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

        string IDefaultLiquidityProviderReader.Get()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsLiquidityProviderId();
            return _readRepository.Get(pk, rk)?.Value;
        }

        string IDefaultMarkupProfileReader.Get()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsMarkupProfile();
            return _readRepository.Get(pk, rk)?.Value;
        }

        IReadOnlyList<string> IDefaultBackupLiquidityProvidersReader.Get()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GetRowKeyAsBackupLiquidityProviders();
            return _readRepository.Get(pk, rk)?.Values ?? Array.Empty<string>();
        }
        
        TimeSpan IQuotesFeedRouterBackupTimeoutReader.GetBackupTimeout(TimeSpan defaultTimeSpan)
        {
            var pk = QuotesFeedRouterBackupTimeoutEntity.GeneratePartitionKey();
            var rk = QuotesFeedRouterBackupTimeoutEntity.GenerateRowKey();

            var entity = _quoteFeedRouterBackupTimeout.Get(pk, rk);
            return entity?.Value ?? defaultTimeSpan;
        }
    }
}