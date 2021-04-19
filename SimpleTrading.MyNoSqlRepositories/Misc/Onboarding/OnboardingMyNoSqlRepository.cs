using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Misc.Onboarding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleTrading.MyNoSqlRepositories.Misc.Onboarding
{
    public class OnboardingMyNoSqlRepository : IOnboardingRepository
    {
        private readonly IMyNoSqlServerDataWriter<OnboardingMyNoSqlTableEntity> _writer;

        public OnboardingMyNoSqlRepository(IMyNoSqlServerDataWriter<OnboardingMyNoSqlTableEntity> writer)
        {
            _writer = writer;
        }

        public async Task<IEnumerable<IOnboarding>> GetAsync() =>
           await _writer.GetAsync();

        public async Task CreateAsync(IOnboarding onboardingFlow)
        {
            var entity = OnboardingMyNoSqlTableEntity.Create(onboardingFlow);

            await _writer.InsertAsync(entity);
        }

        public async Task UpdateAsync(IOnboarding onboardingFlow)
        {
            var entity = OnboardingMyNoSqlTableEntity.Create(onboardingFlow);

            await _writer.InsertOrReplaceAsync(entity);
        }

        public async Task DeleteAsync(string brandId, string name)
        {
            await _writer.DeleteAsync(brandId, name);
        }
    }
}
