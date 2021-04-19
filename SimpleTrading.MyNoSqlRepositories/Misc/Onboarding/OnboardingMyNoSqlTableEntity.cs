using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Misc.Onboarding;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTrading.MyNoSqlRepositories.Misc.Onboarding
{
    public class OnboardingMyNoSqlTableEntity: MyNoSqlDbEntity, IOnboarding
    {
        public string Name => RowKey;

        public string BrandId => PartitionKey;

        public OnboardingFlowPlatform PlaformId { get; set; }

        public string CountryId { get; set; }

        public List<Lottie> Lotties { get; set; }

        IEnumerable<ILottie> IOnboarding.Lotties => Lotties;

        public static string GeneratePartitionKey(string brandId) => brandId;

        public static string GenerateRowKey(string name) => name;

        public static OnboardingMyNoSqlTableEntity Create(IOnboarding onboarding) =>
            new OnboardingMyNoSqlTableEntity
            {
                PartitionKey = GeneratePartitionKey(onboarding.BrandId),
                RowKey = GenerateRowKey(onboarding.Name),
                PlaformId = onboarding.PlaformId,
                CountryId = onboarding.CountryId,
                Lotties = onboarding.Lotties?.Select(Lottie.Create).ToList()
            };
    }

    public class Lottie : ILottie
    {
        public short StepId { get; set; }
        public string JsonContent { get; set; }

        public static Lottie Create(ILottie lottie) =>
            new Lottie
            {
                JsonContent = lottie.JsonContent,
                StepId = lottie.StepId
            };
    }
}
