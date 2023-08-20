using Ratsatak.Api.Common.Errors;
using Ratsatak.Api.Common.Mapping;
using Ratsatak.Application;
using Ratsatak.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMappings();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();

using var log = new LoggerConfiguration() //new
    .WriteTo.Console()
    .WriteTo.File("F:\\logs\\ratsatak-api-log.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Error()
    .CreateLogger();

Log.Logger = log;

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>(); // register custom error handling middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();