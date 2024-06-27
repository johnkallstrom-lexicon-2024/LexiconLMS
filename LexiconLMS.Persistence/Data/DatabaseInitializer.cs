using Bogus;
using LexiconLMS.Persistence.Fakers;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Persistence.Data
{
    public class DatabaseInitializer
    {
        private const int TOTAL_USERS = 50;
        private const int TOTAL_DOCUMENTS_PER_USER = 5;
        private const int TOTAL_COURSES = 25;
        private const int TOTAL_MODULES_PER_COURSE = 10;
        private const int TOTAL_ACTIVITIES_PER_MODULE = 5;

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

            await CreateRoles(roleManager);
            await CreateUsers(userManager);

            await CreateCourses(context);
            await CreateModules(context);
            await CreateActivities(context);
            await CreateDocuments(context, userManager);
        }

        public static async Task CreateDocuments(LexiconDbContext context, UserManager<User> userManager)
        {
            // Fetch all users from db
            var users = await context.Users
                .AsTracking()
                .ToListAsync();

            if (users != null && users.Count() > 0)
            {
                // Go through each user and add uploaded documents
                foreach (var user in users)
                {
                    var documents = _documentFaker.Generate(TOTAL_DOCUMENTS_PER_USER);
                    foreach (var document in documents)
                    {
                        user.Documents.Add(document);
                    }
                }

                context.UpdateRange(users);
                await context.SaveChangesAsync();
            } 
        }

        public static async Task CreateActivities(LexiconDbContext context)
        {
            // Fetch all modules from db
            var modules = await context.Modules
                .AsTracking()
                .ToListAsync();

            if (modules != null && modules.Count() > 0)
            {
                // Go through each module and add activities
                foreach (var module in modules)
                {
                    var activities = _activityFaker.Generate(TOTAL_ACTIVITIES_PER_MODULE);
                    foreach (var activity in activities)
                    {
                        module.Activities.Add(activity);
                    }
                }

                context.UpdateRange(modules);
                await context.SaveChangesAsync();
            }
        }

        public static async Task CreateModules(LexiconDbContext context)
        {
            // Fetch all courses from db
            var courses = await context.Courses
                .AsTracking()
                .ToListAsync();

            if (courses != null && courses.Count() > 0)
            {
                foreach (var course in courses)
                {
                    // Go through each course and add modules
                    var modules = _moduleFaker.Generate(TOTAL_MODULES_PER_COURSE);
                    foreach (var module in modules)
                    {
                        course.Modules.Add(module);
                    }
                }

                // Update db
                context.UpdateRange(courses);
                await context.SaveChangesAsync();
            }
        }

        public static async Task CreateCourses(LexiconDbContext context)
        {
            var courses = _courseFaker.Generate(TOTAL_COURSES);
            if (courses != null && courses.Count() > 0)
            {
                await context.AddRangeAsync(courses);
                await context.SaveChangesAsync();
            }
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
