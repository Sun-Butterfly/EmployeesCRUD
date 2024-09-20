using System.Text.Json.Serialization;
using EmployeesCRUD;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddDbContext<DataBaseContext>();
builder.Services.AddMediatR(x=> x.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddControllersWithViews().AddJsonOptions(opts =>
{
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
    opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddSwaggerGen(x=>x.SwaggerDoc("v1", new OpenApiInfo()
{
    Title = "Employees CRUD",
    Description = "example",
    Version = "1.0"
}));
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
app.MapGet("/", () => "Hello World!");
app.UseRouting();
app.MapControllers();
app.Run();