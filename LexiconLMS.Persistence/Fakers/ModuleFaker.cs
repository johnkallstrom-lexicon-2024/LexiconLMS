using Bogus;

namespace LexiconLMS.Persistence.Fakers
{
    public class ModuleFaker : Faker<Module>
    {
        private readonly string[] _names = ["Variables", "Loops", "Classes and interfaces", "Databases", "Cloud Services", "OOP", "Frontend"];

        public ModuleFaker()
        {
            RuleFor(m => m.Name, f => f.PickRandom(_names));
            RuleFor(m => m.Description, f => f.Lorem.Paragraphs(count: 1));
            RuleFor(m => m.StartDate, DateTime.Now.AddMonths(1).AddDays(14));
            RuleFor(m => m.EndDate, DateTime.Now.AddMonths(3));
        }
    }
}
