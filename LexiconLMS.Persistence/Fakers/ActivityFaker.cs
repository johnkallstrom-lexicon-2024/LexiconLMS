using Bogus;

namespace LexiconLMS.Persistence.Fakers
{
    public class ActivityFaker : Faker<Activity>
    {
        private int _length = Enum.GetValues<ActivityType>().Length;
        private readonly string[] _names = ["JavaScript Webinar 101", "Essay in English", "Countries Quiz", "Meetup with classmates", "C# Assignment"];

        public ActivityFaker()
        {
            RuleFor(a => a.Name, f => f.PickRandom(_names));
            RuleFor(a => a.Description, f => f.Lorem.Paragraphs(count: 1));
            RuleFor(a => a.Type, f => (ActivityType)f.Random.Int(min: 0, max: (_length - 1)));
            RuleFor(a => a.StartDate, DateTime.Now.AddMonths(1).AddDays(14));
            RuleFor(a => a.EndDate, DateTime.Now.AddMonths(2));
        }
    }
}
