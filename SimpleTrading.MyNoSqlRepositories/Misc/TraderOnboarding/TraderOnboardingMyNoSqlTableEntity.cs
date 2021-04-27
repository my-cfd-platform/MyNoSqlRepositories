using MyNoSqlServer.Abstractions;
using SimpleTrading.Abstraction.Misc.TraderOnboarding;

namespace SimpleTrading.MyNoSqlRepositories.Misc.Onboarding
{
    public class TraderOnboardingMyNoSqlTableEntity : MyNoSqlDbEntity, ITraderOnboarding
    {
        public short Id { get; set; }

        public static string GeneratePartitionKey() => "id";

        public static string GenerateRowKey() => "id";

        public static TraderOnboardingMyNoSqlTableEntity Create(ITraderOnboarding onboarding) =>
            new TraderOnboardingMyNoSqlTableEntity
            {
                PartitionKey = GeneratePartitionKey(),
                RowKey = GenerateRowKey(),
                Id = onboarding.Id
            };
    }
}
