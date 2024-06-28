using LexiconLMS.Core.Services;
using LexiconLMS.Http;
using LexiconLMS.HttpServices;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(config =>
{
    config.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<ICourseService, HttpCourseService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddCoreServices();

builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //await app.SeedDatabaseAsync();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
