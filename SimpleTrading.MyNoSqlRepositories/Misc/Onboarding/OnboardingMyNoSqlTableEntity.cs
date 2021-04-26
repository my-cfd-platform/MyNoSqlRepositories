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

        public short DeviceId { get; set; }

        public string CountryId { get; set; }

        public List<OnboardingStep> Steps { get; set; }

        IEnumerable<IOnboardingStep> IOnboarding.Steps => Steps;

        public static string GeneratePartitionKey(string brandId) => brandId;

        public static string GenerateRowKey(string name) => name;

        public static OnboardingMyNoSqlTableEntity Create(IOnboarding onboarding) =>
            new OnboardingMyNoSqlTableEntity
            {
                PartitionKey = GeneratePartitionKey(onboarding.BrandId),
                RowKey = GenerateRowKey(onboarding.Name),
                DeviceId = onboarding.DeviceId,
                CountryId = onboarding.CountryId,
                Steps = onboarding.Steps?.Select(OnboardingStep.Create).ToList()
            };
    }

    public class OnboardingStep : IOnboardingStep
    {
        public short Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool FullScreen { get; set; }
        public string LottieJson { get; set; }

        public List<OnboardingStepButton> Buttons { get; set; }

        IEnumerable<IOnboardingStepButton> IOnboardingStep.Buttons => Buttons;

        public static OnboardingStep Create(IOnboardingStep oboardingStep) =>
            new OnboardingStep
            {
                Id = oboardingStep.Id,
                Title = oboardingStep.Title,
                Description = oboardingStep.Description,
                FullScreen = oboardingStep.FullScreen,
                Buttons = oboardingStep.Buttons?.Select(OnboardingStepButton.Create).ToList(),
                LottieJson = oboardingStep.LottieJson
            };
    }

    public class OnboardingStepButton : IOnboardingStepButton
    {
        public string Text { get; set; }
        public short Action { get; set; }
   
        public static OnboardingStepButton Create(IOnboardingStepButton oboardingStepButton) =>
            new OnboardingStepButton
            {
               Text = oboardingStepButton.Text,
               Action = oboardingStepButton.Action
            };
    }
}
