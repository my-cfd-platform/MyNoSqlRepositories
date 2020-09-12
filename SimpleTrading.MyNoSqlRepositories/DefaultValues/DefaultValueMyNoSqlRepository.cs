using System;
using System.Threading.Tasks;
using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.DefaultValues;

namespace SimpleTrading.MyNoSqlRepositories.DefaultValues
{
    public class DefaultValuesMyNoSqlWriter : IDefaultValuesRepository, ILiquidityProviderWriter, IMarkupProfileWriter
    {
        private readonly IMyNoSqlServerDataWriter<DefaultValueMyNoSqlTableEntity> _table;

        public DefaultValuesMyNoSqlWriter(IMyNoSqlServerDataWriter<DefaultValueMyNoSqlTableEntity> table)
        {
            _table = table ?? throw new ArgumentNullException(nameof(table));
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


        ValueTask ILiquidityProviderWriter.SetAsync(string value)
        {
            var entity = new DefaultValueMyNoSqlTableEntity
            {
                PartitionKey = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey(),
                RowKey = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsLiquidityProviderId(),
                Value = value
            };

            return _table.InsertOrReplaceAsync(entity);
        }

        async ValueTask<string> ILiquidityProviderWriter.GetAsync()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsLiquidityProviderId();

            return (await _table.GetAsync(pk, rk))?.Value;
        }
        
        ValueTask IMarkupProfileWriter.SetAsync(string value)
        {
            var entity = new DefaultValueMyNoSqlTableEntity
            {
                PartitionKey = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey(),
                RowKey = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsMarkupProfile(),
                Value = value
            };

            return _table.InsertOrReplaceAsync(entity);
        }

        async ValueTask<string> IMarkupProfileWriter.GetAsync()
        {
            var pk = DefaultValueMyNoSqlTableEntity.GeneratePartitionKey();
            var rk = DefaultValueMyNoSqlTableEntity.GenerateRowKeyAsMarkupProfile();

            return (await _table.GetAsync(pk, rk))?.Value;
        }
    }
}