using backend;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDataContext>(options => options.UseNpgsql(connectionString));


var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
