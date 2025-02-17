using Microsoft.Extensions.DependencyInjection;
using OptimalRoute.Aplication.Interfaces;
using OptimalRoute.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection
builder.Services.AddScoped<IRouteService, RouteService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "OptimalRoute API",
        Version = "v1",
        Description = "API to calculate optimal route between two cities"
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OptimalRoute API v1");
        c.RoutePrefix = string.Empty;  
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();