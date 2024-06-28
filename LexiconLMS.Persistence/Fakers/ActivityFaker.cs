using Bogus;

namespace LexiconLMS.Persistence.Fakers
{
    public class ActivityFaker : Faker<Activity>
    {
        public ActivityFaker()
        {
            var length = Enum.GetValues<ActivityType>().Length;

            RuleFor(a => a.Name, f => $"Activity {f.Commerce.Ean8()}");
            RuleFor(a => a.Description, f => f.Lorem.Paragraphs(count: 1));
            RuleFor(a => a.Type, f => (ActivityType)f.Random.Int(min: 0, max: (length - 1)));
            RuleFor(a => a.StartDate, DateTime.Now.AddMonths(1).AddDays(14));
            RuleFor(a => a.EndDate, DateTime.Now.AddMonths(2));
        }
    }
}
