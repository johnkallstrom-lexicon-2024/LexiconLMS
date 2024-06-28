using Bogus;

namespace LexiconLMS.Persistence.Fakers
{
    public class CourseFaker : Faker<Course>
    {
        private readonly string[] _names = ["Crash Course in JavaScript", "Foundations of C#", "React 101", "Azure Cloud Development", "SQL Databases", "Unity Beginner Course"];

        public CourseFaker()
        {
            RuleFor(c => c.Name, f => f.PickRandom(_names));
            RuleFor(c => c.Description, f => f.Lorem.Paragraphs(count: 1));
            RuleFor(c => c.StartDate, DateTime.Now.AddMonths(1));
            RuleFor(c => c.EndDate, DateTime.Now.AddMonths(3));
        }
    }
}
