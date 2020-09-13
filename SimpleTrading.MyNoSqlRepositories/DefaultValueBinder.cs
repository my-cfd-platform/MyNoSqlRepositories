using System;
using MyDependencies;
using MyNoSqlServer.DataReader;
using SimpleTrading.MyNoSqlRepositories.DefaultValues;
using SimpleTrading.QuotesFeedRouter.Abstractions;

namespace SimpleTrading.MyNoSqlRepositories
{
    
    public class DefaultValueReaderBinderHelper
    {
        private readonly IServiceRegistrator _sr;
        private readonly DefaultValuesMyNoSqlReader _reader;

        public DefaultValueReaderBinderHelper(IServiceRegistrator sr, DefaultValuesMyNoSqlReader reader)
        {
            _sr = sr;
            _reader = reader;
        }

        public DefaultValueReaderBinderHelper BindDefaultMarkupProfiles()
        {
            _sr.Register<IDefaultMarkupProfileReader>(_reader);
            return this;
        }
        
        public DefaultValueReaderBinderHelper BindDefaultLiquidityProviders()
        {
            _sr.Register<IDefaultLiquidityProviderReader>(_reader);
            return this;
        }
        
        public DefaultValueReaderBinderHelper BindDefaultBackupLiquidityProvidersReader()
        {
            _sr.Register<IDefaultBackupLiquidityProvidersReader>(_reader);
            return this;
        }
        
        public DefaultValueReaderBinderHelper BindQuotesFeedRouterBackupTimeoutReader()
        {
            _sr.Register<IQuotesFeedRouterBackupTimeoutReader>(_reader);
            return this;
        }        

        public IServiceRegistrator Build()
        {
            return _sr;
        }
    }

    public class DefaultValueWriterBinderHelper
    {
        private readonly IServiceRegistrator _sr;
        private readonly DefaultValuesMyNoSqlWriter _writer;

        public DefaultValueWriterBinderHelper(IServiceRegistrator sr, DefaultValuesMyNoSqlWriter writer)
        {
            _sr = sr;
            _writer = writer;
        }
        
        public DefaultValueWriterBinderHelper BindMarkupProfiles()
        {
            _sr.Register<IDefaultMarkupProfileWriter>(_writer);
            return this;
        }
        
        public DefaultValueWriterBinderHelper BindLiquidityProviders()
        {
            _sr.Register<IDefaultLiquidityProviderWriter>(_writer);
            return this;
        }
        
        public DefaultValueWriterBinderHelper BindDefaultBackupLiquidityProvidersReaderWriter()
        {
            _sr.Register<IDefaultBackupLiquidityProvidersWriter>(_writer);
            return this;
        }
        
        public DefaultValueWriterBinderHelper BindQuotesFeedRouterBackupTimeoutWriter()
        {
            _sr.Register<IQuotesFeedRouterBackupTimeoutWriter>(_writer);
            return this;
        }        


        public IServiceRegistrator Build()
        {
            return _sr;
        }
    }
    
    public static class DefaultValueBinder
    {
        public static DefaultValueReaderBinderHelper BindDefaultValueReader(this IServiceRegistrator sr,
            MyNoSqlTcpClient connection)
        {
            var reader = connection.CreateDefaultValuesMyNoSqlReader();
            return new DefaultValueReaderBinderHelper(sr, reader);
        }
        
        public static DefaultValueWriterBinderHelper BindDefaultValueWriter(this IServiceRegistrator sr,
            Func<string> getUrl)
        {
            var writer = MyNoSqlServerFactory.CreateDefaultValueMyNoSqlRepository(getUrl);
            return new DefaultValueWriterBinderHelper(sr, writer);
        }
    }
}