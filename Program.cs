using Facul.Database;
using Facul.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IDatabaseConnection, SqlServerAdapter>();
var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
