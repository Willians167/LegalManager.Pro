var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "LegalManager.Pro API",
        Version = "v1.0.0",
        Description = "Sistema de Gestão Jurídica para Escritórios de Advocacia",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "LegalManager Team",
            Email = "dev@legalmanager.com"
        }
    });
});
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "LegalManager.Pro API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.MapGet("/", () => new
{
    name = "LegalManager.Pro API",
    version = "v1.0.0",
    status = "Online",
    environment = app.Environment.EnvironmentName,
    timestamp = DateTime.UtcNow,
    endpoints = new
    {
        swagger = "/swagger",
        health = "/health"
    }
})
.WithName("GetApiInfo")
.WithTags("System")
.WithSummary("Get API information")
.WithDescription("Returns basic information about the API including version, status, and available endpoints");

app.MapHealthChecks("/health");

// Weather forecast endpoint for demonstration purposes
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithTags("Demo")
.WithSummary("Get weather forecast")
.WithDescription("Returns a 5-day weather forecast with random data for demonstration purposes");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
