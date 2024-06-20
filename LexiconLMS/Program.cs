using LexiconLMS.Components;
using LexiconLMS.Core.Identity;
using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Repository;
using LexiconLMS.Persistence;
using LexiconLMS.Persistence.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LexiconDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LexiconLMSContext") ?? throw new InvalidOperationException("Connection string 'LexiconLMSContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter(); ;

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    }).AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<LexiconDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(provider => new UnitOfWork(provider.GetRequiredService<LexiconDbContext>()));

builder.Services.AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LexiconDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
