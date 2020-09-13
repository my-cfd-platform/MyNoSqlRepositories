using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.DefaultValues;
using SimpleTrading.QuotesFeedRouter.Abstractions;

namespace SimpleTrading.MyNoSqlRepositories.DefaultValues
{
    public class DefaultValuesMyNoSqlWriter : IDefaultValuesRepository, IDefaultLiquidityProviderWriter, 
        IDefaultMarkupProfileWriter, IDefaultBackupLiquidityProvidersWriter,
        IQuotesFeedRouterBackupTimeoutWriter
    {
        private readonly IMyNoSqlServerDataWriter<DefaultValueMyNoSqlTableEntity> _table;
        private readonly IMyNoSqlServerDataWriter<QuotesFeedRouterBackupTimeoutEntity> _tableTimeSpan;

        public DefaultValuesMyNoSqlWriter(IMyNoSqlServerDataWriter<DefaultValueMyNoSqlTableEntity> table,
            IMyNoSqlServerDataWriter<QuotesFeedRouterBackupTimeoutEntity> tableTimeSpan)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
            _tableTimeSpan = tableTimeSpan;
        }


        public ValueTask SetTradingInstrumentAvatarSvgAsync(string value)
        {
            var entity = new DefaultValueMyNoSqlTableEntity
            {
                PartitionKey = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey(),
                RowKey = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsTradingInstrumentAvatarSvg(),
                Value = value
            };

            return _table.InsertOrReplaceAsync(entity);
        }

        public async ValueTask<string> GetTradingInstrumentAvatarSvgAsync()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsTradingInstrumentAvatarSvg();

            return (await _table.GetAsync(pk, rk))?.Value;
        }

        public ValueTask SetTradingInstrumentAvatarPngAsync(string value)
        {
            var entity = new DefaultValueMyNoSqlTableEntity
            {
                PartitionKey = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey(),
                RowKey = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsTradingInstrumentAvatarPng(),
                Value = value
            };

            return _table.InsertOrReplaceAsync(entity);
        }

        public async ValueTask<string> GetTradingInstrumentAvatarPngAsync()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsTradingInstrumentAvatarPng();

            return (await _table.GetAsync(pk, rk))?.Value;
        }

        public ValueTask SetPaymentMethodSvgAsync(string value)
        {
            var entity = new DefaultValueMyNoSqlTableEntity
            {
                PartitionKey = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey(),
                RowKey = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsPaymentMethodSvg(),
                Value = value
            };

            return _table.InsertOrReplaceAsync(entity);
        }

        public async ValueTask<string> GetPaymentMethodSvgAsync()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsPaymentMethodSvg();

            return (await _table.GetAsync(pk, rk))?.Value;
        }

        public ValueTask SetPaymentMethodPngAsync(string value)
        {
            var entity = new DefaultValueMyNoSqlTableEntity
            {
                PartitionKey = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey(),
                RowKey = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsPaymentMethodPng(),
                Value = value
            };

            return _table.InsertOrReplaceAsync(entity);
        }

        public async ValueTask<string> GetPaymentMethodPngAsync()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsPaymentMethodPng();

            return (await _table.GetAsync(pk, rk))?.Value;
        }


        public ValueTask SetDefaultLanguageAsync(string value)
        {
            var entity = new DefaultValueMyNoSqlTableEntity
            {
                PartitionKey = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey(),
                RowKey = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsDefaultLanguage(),
                Value = value
            };

            return _table.InsertOrReplaceAsync(entity);
        }

        public async ValueTask<string> GetDefaultLanguageAsync()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsDefaultLanguage();

            return (await _table.GetAsync(pk, rk))?.Value;
        }

        public ValueTask SetCountryOfRegistrationAsync(string value)
        {
            var entity = new DefaultValueMyNoSqlTableEntity
            {
                PartitionKey = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey(),
                RowKey = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsCountryOfRegistration(),
                Value = value
            };

            return _table.InsertOrReplaceAsync(entity);
        }

        public async ValueTask<string> GetCountryOfRegistrationAsync()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsCountryOfRegistration();

            return (await _table.GetAsync(pk, rk))?.Value;
        }


        ValueTask IDefaultLiquidityProviderWriter.SetAsync(string value)
        {
            var entity = new DefaultValueMyNoSqlTableEntity
            {
                PartitionKey = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey(),
                RowKey = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsLiquidityProviderId(),
                Value = value
            };

            return _table.InsertOrReplaceAsync(entity);
        }


        async ValueTask<string> IDefaultLiquidityProviderWriter.GetAsync()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsLiquidityProviderId();

            return (await _table.GetAsync(pk, rk))?.Value;
        }



        ValueTask IDefaultMarkupProfileWriter.SetAsync(string value)
        {
            var entity = new DefaultValueMyNoSqlTableEntity
            {
                PartitionKey = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey(),
                RowKey = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsMarkupProfile(),
                Value = value
            };

            return _table.InsertOrReplaceAsync(entity);
        }

        async ValueTask<string> IDefaultMarkupProfileWriter.GetAsync()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsMarkupProfile();

            return (await _table.GetAsync(pk, rk))?.Value;
        }

        
        ValueTask IDefaultBackupLiquidityProvidersWriter.SetAsync(IEnumerable<string> values)
        {
            var entity = new DefaultValueMyNoSqlTableEntity
            {
                PartitionKey = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey(),
                RowKey = DefaultValueMyNoSqlTableEntity.GetRowKeyAsBackupLiquidityProviders(),
                Values = values.ToArray()
            };

            return _table.InsertOrReplaceAsync(entity);
        }
        
        async ValueTask<IReadOnlyList<string>> IDefaultBackupLiquidityProvidersWriter.GetAsync()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GetRowKeyAsBackupLiquidityProviders();
            return (await _table.GetAsync(pk, rk))?.Values ?? Array.Empty<string>();
        }

        ValueTask IQuotesFeedRouterBackupTimeoutWriter.SetAsync(TimeSpan value)
        {
            var entity = new QuotesFeedRouterBackupTimeoutEntity
            {
                PartitionKey = QuotesFeedRouterBackupTimeoutEntity.GeneratePartitionKey(),
                RowKey = QuotesFeedRouterBackupTimeoutEntity.GenerateRowKey(),
                Value = value
            };

            return _tableTimeSpan.InsertOrReplaceAsync(entity);
        }

        async ValueTask<TimeSpan?> IQuotesFeedRouterBackupTimeoutWriter.GetAsync()
        {
            var pk = QuotesFeedRouterBackupTimeoutEntity.GeneratePartitionKey();
            var rk = QuotesFeedRouterBackupTimeoutEntity.GenerateRowKey();
            return (await _tableTimeSpan.GetAsync(pk, rk))?.Value;
        }        
    }
}