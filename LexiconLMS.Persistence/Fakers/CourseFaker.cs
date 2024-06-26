using Bogus;

namespace LexiconLMS.Persistence.Fakers
{
    public class CourseFaker : Faker<Course>
    {
        public CourseFaker()
        {
            RuleFor(c => c.Name, f => f.Company.CompanyName());
            RuleFor(c => c.Description, f => f.Company.Bs());
            RuleFor(c => c.StartDate, DateTime.Now.AddMonths(1));
            RuleFor(c => c.EndDate, DateTime.Now.AddMonths(3));
            RuleFor(c => c.Created, DateTime.Now);
        }
    }
}
