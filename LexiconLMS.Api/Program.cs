using LexiconLMS.Api;
using LexiconLMS.Core.Jwt;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(config =>
{
    config.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddTransient<IJwtProvider, JwtProvider>();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddCoreServices();

builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await app.SeedDatabaseAsync();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
