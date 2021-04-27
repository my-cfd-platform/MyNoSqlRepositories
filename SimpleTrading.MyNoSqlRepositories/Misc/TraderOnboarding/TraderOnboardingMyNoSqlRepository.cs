using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Misc.TraderOnboarding;
using System.Threading.Tasks;

namespace SimpleTrading.MyNoSqlRepositories.Misc.Onboarding
{
    public class TraderOnboardingMyNoSqlRepository : ITraderOnboardingRepository
    {
        private readonly IMyNoSqlServerDataWriter<TraderOnboardingMyNoSqlTableEntity> _writer;

        public TraderOnboardingMyNoSqlRepository(IMyNoSqlServerDataWriter<TraderOnboardingMyNoSqlTableEntity> writer)
        {
            _writer = writer;
        }

        public async Task<short?> GetIdAsync() =>
            (await _writer.GetAsync("id", "id"))?.Id;

        public async Task UpdateIdAsync(short id)
        {
            var entity = new TraderOnboardingMyNoSqlTableEntity { 
                Id = id,
                PartitionKey = "id",
                RowKey = "id"
            };

            await _writer.InsertOrReplaceAsync(entity);
        }
    }
}
