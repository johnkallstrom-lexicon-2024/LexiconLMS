using Bogus;
using LexiconLMS.Persistence.Fakers;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Persistence
{
    public class DatabaseInitializer
    {
        private static UserFaker _userFaker = new();
        private static Faker _faker = new();

        public static async Task SeedIdentityDataAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            await CreateRoles(roleManager);
        }

        public static async Task CreateRoles(RoleManager<Role> roleManager)
        {
            string[] roles = ["Teacher", "Student"];

            foreach (var role in roles)
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

        public static async Task CreateUser(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            var roles = roleManager.Rol

            var users = _userFaker.Generate(100);
            if (users != null && users.Count() > 0)
            {
                foreach (var user in users)
                {
                    user.PasswordHash = userManager.PasswordHasher.HashPassword(user, _faker.Internet.Password());

                    var identityResult = await userManager.CreateAsync(user);
                    if (identityResult.Succeeded)
                    {
                    }
                }
            }
        }
    }
}
