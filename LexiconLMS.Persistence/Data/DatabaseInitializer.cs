using Bogus;
using LexiconLMS.Persistence.Fakers;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Persistence.Data
{
    public class DatabaseInitializer
    {
        private static readonly string[] _roles = ["Teacher", "Student"];
        private static UserFaker _userFaker = new();
        private static Faker _faker = new();

        public static async Task SeedAsync(LexiconDbContext context)
        {
            await Task.CompletedTask;
        }

        public static async Task SeedIdentityAsync(
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {
            await CreateRoles(roleManager);
            await CreateUsers(userManager);
        }

        public static async Task CreateRoles(RoleManager<Role> roleManager)
        {
            foreach (var role in _roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new Role
                    {
                        Name = role,
                        NormalizedName = role,
                    });
                }
            }
        }

        public static async Task CreateUsers(UserManager<User> userManager)
        {
            var users = _userFaker.Generate(100);

            if (users != null && users.Count() > 0)
            {
                foreach (var user in users)
                {
                    user.PasswordHash = userManager.PasswordHasher.HashPassword(user, _faker.Internet.Password());

                    var identityResult = await userManager.CreateAsync(user);
                    if (identityResult.Succeeded)
                    {
                        string role = _roles[_faker.Random.Int(min: 0, max: (_roles.Count() - 1))];
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
            }
        }
    }
}
