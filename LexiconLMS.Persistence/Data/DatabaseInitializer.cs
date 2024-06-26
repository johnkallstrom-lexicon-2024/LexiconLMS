using Bogus;
using LexiconLMS.Persistence.Fakers;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Persistence.Data
{
    public class DatabaseInitializer
    {
        private const int TOTAL_DOCUMENTS = 100;
        private const int TOTAL_USERS = 50;
        private const int TOTAL_COURSES = 25;
        private const int MODULES_PER_COURSE = 10;
        private const int ACTIVITIES_PER_MODULE = 5;

        private static readonly string[] _roles = ["Teacher", "Student"];
        
        private static Faker _faker = new();
        private static CourseFaker _courseFaker = new();
        private static ModuleFaker _moduleFaker = new();
        private static ActivityFaker _activityFaker = new();
        private static DocumentFaker _documentFaker = new();
        private static UserFaker _userFaker = new();

        public static async Task SeedAsync(
            LexiconDbContext context,
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {

            var courses = _courseFaker.Generate(TOTAL_COURSES);
            foreach (var course in courses)
            {
                var courseModules = _moduleFaker.Generate(MODULES_PER_COURSE);
                foreach (var module in courseModules)
                {
                    course.Modules.Add(module);
                }
            }

            if (courses != null && courses.Count() > 0)
            {
                await context.AddRangeAsync(courses);
                await context.SaveChangesAsync();
            }

            var modules = await context.Modules
                .AsTracking()
                .ToListAsync();

            foreach (var module in modules)
            {
                var activities = _activityFaker.Generate(ACTIVITIES_PER_MODULE);
                foreach (var activity in activities)
                {
                    module.Activities.Add(activity);
                }

            }

            context.Modules.UpdateRange(modules);

            var documents = _documentFaker.Generate(TOTAL_DOCUMENTS);
            await context.Documents.AddRangeAsync(documents);
            await context.SaveChangesAsync();

            await CreateRoles(roleManager);
            await CreateUsers(userManager);
        }

        public static IEnumerable<Course> GenerateCoursesWithModules()
        {
            var courses = _courseFaker.Generate(50);
            foreach (var course in courses)
            {
                var modules = _moduleFaker.Generate(10);
                foreach (var module in modules)
                {
                    course.Modules.Add(module);
                }
            }

            return courses;
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
            var users = _userFaker.Generate(TOTAL_USERS);

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
