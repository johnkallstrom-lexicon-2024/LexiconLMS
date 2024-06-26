using Bogus;

namespace LexiconLMS.Persistence.Fakers
{
    public class ModuleFaker : Faker<Module>
    {
        public ModuleFaker()
        {
            RuleFor(m => m.Name, f => $"Module {f.IndexFaker}");
            RuleFor(m => m.Description, f => f.Lorem.Paragraph());
            RuleFor(m => m.StartDate, DateTime.Now.AddMonths(1));
            RuleFor(m => m.EndDate, DateTime.Now.AddMonths(2));
            RuleFor(m => m.Created, DateTime.Now);
        }
    }
}
