using Bogus;

namespace LexiconLMS.Persistence.Fakers
{
    public class ActivityFaker : Faker<Activity>
    {
        public ActivityFaker()
        {
            var length = Enum.GetValues<ActivityType>().Length;

            RuleFor(a => a.Name, f => $"Activity {f.IndexFaker}");
            RuleFor(a => a.Description, f => f.Lorem.Paragraphs());
            RuleFor(a => a.Type, f => (ActivityType)f.Random.Int(min: 0, max: (length - 1)));
            RuleFor(a => a.StartDate, DateTime.Now.AddMonths(1));
            RuleFor(a => a.EndDate, DateTime.Now.AddMonths(2));
            RuleFor(a => a.Created, DateTime.Now);
        }
    }
}
