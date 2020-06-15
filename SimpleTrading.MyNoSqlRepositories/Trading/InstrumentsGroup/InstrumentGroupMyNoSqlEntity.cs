using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Trading.InstrumentsGroup;

namespace SimpleTrading.MyNoSqlRepositories.Trading.InstrumentsGroup
{
    public class InstrumentGroupMyNoSqlEntity : MyNoSqlDbEntity, IInstrumentGroup
    {
        public static string GeneratePartitionKey()
        {
            return "ig";
        }

        public static string GenerateRowKey(string id)
        {
            return id;
        }

        public string Id => RowKey;
        
        public string Name { get; set; }

        public static InstrumentGroupMyNoSqlEntity Create(IInstrumentGroup src)
        {
            return new InstrumentGroupMyNoSqlEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(src.Id),
                Name = src.Name
            };
        }
    }
}