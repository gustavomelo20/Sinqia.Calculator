using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Sinqia.Calculator.Api.Configurations;
using Sinqia.Calculator.Api.Filters;
using Sinqia.Calculator.Application;
using Sinqia.Calculator.Infrastructure;
using Sinqia.Calculator.Infrastructure.DataAccess;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(
        new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

MigrateDatabase();

await app.RunAsync();

void MigrateDatabase()
{
    var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();

    DatabaseMigration.Migrate(serviceScope.ServiceProvider);
}


