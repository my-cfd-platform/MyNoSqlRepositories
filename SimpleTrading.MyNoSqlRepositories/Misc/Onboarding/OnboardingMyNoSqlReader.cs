using MyNoSqlServer.Abstractions;
using MyNoSqlServer.DataReader;
using SimpleTrading.Abstraction.Misc.Onboarding;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTrading.MyNoSqlRepositories.Misc.Onboarding
{
    public class OnboardingMyNoSqlReader : IOnboardingReader
    {
        private readonly IMyNoSqlServerDataReader<OnboardingMyNoSqlTableEntity> _readRepository;

        public OnboardingMyNoSqlReader(
            MyNoSqlReadRepository<OnboardingMyNoSqlTableEntity> readRepository)
        {
            _readRepository = readRepository;
        }

        public IEnumerable<IOnboarding> Get() =>
             _readRepository.Get(o => true);

        public IOnboarding Get(string brandId, string name) =>
             _readRepository.Get(brandId, name);

        public IEnumerable<IOnboardingStep> GetSteps(string brandId, byte deviceId, string countryId) =>
           _readRepository.Get(brandId)
            .FirstOrDefault(f => f.DeviceId == deviceId && f.CountryId == countryId)?.Steps ?? Enumerable.Empty<IOnboardingStep>();
    }
}
