using LexiconLMS.Components;
using LexiconLMS.Core.Identity;
using LexiconLMS.Core.Repository;
using LexiconLMS.Persistence;
using LexiconLMS.Persistence.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LexiconLMS.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Logging is configured in appsettings.json
var logging = builder.Logging
    .AddConfiguration(builder.Configuration)
    .AddConsole()
    .AddTraceSource("Information, ActivityTracing")
    .AddDebug();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
}).AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<LexiconDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Register repositories and unit of work
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(provider => new UnitOfWork(provider.GetRequiredService<LexiconDbContext>()));

// Register application services (uncomment when needed)
//builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<ICourseService, CourseService>();
//builder.Services.AddScoped<IDocumentService, DocumentService>();
//builder.Services.AddScoped<IModuleService, ModuleService>();
//builder.Services.AddScoped<IUserService, UserService>();

// Configure Identity services
builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LexiconDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
