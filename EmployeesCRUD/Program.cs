using System.Text.Json.Serialization;
using EmployeesCRUD;
using FluentValidation;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddDbContext<DataBaseContext>();
builder.Services.AddMediatR(x=> x.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddAutoMapper(x => x.AddProfile(typeof(MappingProfile)));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
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

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy => policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    )
);

var app = builder.Build();
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
app.MapGet("/", () => "Hello World!");
app.UseRouting();
app.MapControllers();
app.Run();