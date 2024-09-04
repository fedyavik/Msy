using System.Reflection;
using Microsoft.OpenApi.Models;
using MSY.Database.Extension;
using MSY.Filters;
using MSY.Infrastructure.Extension;
using MSY.Infrastructure.Migrations.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
ConfigureSwagger(builder.Services);
builder.Services.ConfigureMigrator(builder.Configuration);
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.AddInfrastructureServices();
var app = builder.Build();

app.Migrate();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo {
            Title = "MSYService",
            Version = "v1"
        });
        options.CustomSchemaIds(x=> x.FullName);
                
        var xmlFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
        var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
        options.IncludeXmlComments(xmlFilePath);
    });
}