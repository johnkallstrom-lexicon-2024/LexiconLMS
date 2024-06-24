using Bogus;

namespace LexiconLMS.Persistence.Fakers
{
    public class UserFaker : Faker<User>
    {
        public UserFaker()
        {
            RuleFor(u => u.UserName, f => f.Person.UserName);
            RuleFor(u => u.FirstName, f => f.Person.FirstName);
            RuleFor(u => u.LastName, f => f.Person.LastName);
            RuleFor(u => u.Email, f => f.Person.Email);
        }
    }
}
