using DealershipRun.AppHost.Car;
using DealershipRun.AppHost.Data;
using DealershipRun.AppHost.Middleware;
using DealershipRun.AppHost.Order;
using DealershipRun.AppHost.User;
using DotNetEnv;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");

Env.Load(dotenv);

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5001");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DealershipRunDBcontext>(options => 
{
    var host = Environment.GetEnvironmentVariable("DBHost");
    var port = Environment.GetEnvironmentVariable("DBPort");
    var db = Environment.GetEnvironmentVariable("DBName");
    var user = Environment.GetEnvironmentVariable("DBUser");
    var password = Environment.GetEnvironmentVariable("DBPassword");
    options.UseNpgsql($"Host={host};Port={port};Database={db};Username={user};Password={password}");
});

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.UseExceptionHandler(a => a.Run(async context =>
{
    var feature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
    var exception = feature?.Error;
    await context.Response.WriteAsJsonAsync(new { error = exception?.Message, detail = exception?.ToString() });
}));

app.Run();
