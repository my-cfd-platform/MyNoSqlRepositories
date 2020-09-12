using System;
using MyDependencies;
using MyNoSqlServer.DataReader;
using SimpleTrading.Abstraction.DefaultValues;
using SimpleTrading.MyNoSqlRepositories.DefaultValues;

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

        public DefaultValueReaderBinderHelper BindMarkupProfiles()
        {
            _sr.Register<IMarkupProfileReader>(_reader);
            return this;
        }
        
        public DefaultValueReaderBinderHelper BindLiquidityProviders()
        {
            _sr.Register<ILiquidityProviderReader>(_reader);
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
            _sr.Register<IMarkupProfileWriter>(_writer);
            return this;
        }
        
        public DefaultValueWriterBinderHelper BindLiquidityProviders()
        {
            _sr.Register<ILiquidityProviderWriter>(_writer);
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