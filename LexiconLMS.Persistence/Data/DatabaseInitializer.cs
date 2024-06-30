using Bogus;
using LexiconLMS.Persistence.Fakers;
using Microsoft.AspNetCore.Identity;

namespace LexiconLMS.Persistence.Data
{
    public class DatabaseInitializer
    {
        private const int TOTAL_TEACHERS = 5;
        private const int TOTAL_STUDENTS_PER_COURSE = 10;
        private const int TOTAL_DOCUMENTS_PER_USER = 5;
        private const int TOTAL_COURSES = 10;
        private const int TOTAL_MODULES_PER_COURSE = 5;
        private const int TOTAL_ACTIVITIES_PER_MODULE = 3;

        private static readonly string[] ROLES = ["Teacher", "Student"];
        private static readonly string TEACHER_ROLE = "Teacher";
        private static readonly string STUDENT_ROLE = "Student";

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
            await CreateTeachers(userManager);

            await CreateCourses(context);
            await CreateStudents(userManager, context);
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
            foreach (var role in ROLES)
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

        public static async Task CreateTeachers(UserManager<User> userManager)
        {
            var teachers = _userFaker.Generate(TOTAL_TEACHERS);
            if (teachers != null && teachers.Count() > 0)
            {
                foreach (var teacher in teachers)
                {
                    teacher.PasswordHash = userManager.PasswordHasher.HashPassword(teacher, _faker.Internet.Password());

                    var identityResult = await userManager.CreateAsync(teacher);
                    if (identityResult.Succeeded)
                    {
                        await userManager.AddToRoleAsync(teacher, TEACHER_ROLE);
                    }
                }
            }
        }

        public static async Task CreateStudents(UserManager<User> userManager, LexiconDbContext context)
        {
            var courses = await context.Courses.ToListAsync();
            foreach (var course in courses)
            {
                await AddStudentsToCourse(course.Id, userManager);
            }
        }

        private static async Task AddStudentsToCourse(int courseId, UserManager<User> userManager)
        {
            var students = _userFaker.Generate(TOTAL_STUDENTS_PER_COURSE);
            if (students != null && students.Count() > 0)
            {
                foreach (var student in students)
                {
                    student.CourseId = courseId;
                    student.PasswordHash = userManager.PasswordHasher.HashPassword(student, _faker.Internet.Password());

                    var identityResult = await userManager.CreateAsync(student);
                    if (identityResult.Succeeded)
                    {
                        await userManager.AddToRoleAsync(student, STUDENT_ROLE);
                    }
                }
            }
        }
    }
}
