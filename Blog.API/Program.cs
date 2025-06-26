using Blog.API.Services.DIY;
using Blog.API.Services.Foods;
using Blog.API.Services.Photografy;
using Blog.Dataccess;
using Blog.Dataccess.Repositorys.DIY;
using Blog.Dataccess.Repositorys.Foods;
using Blog.Dataccess.Repositorys.Photografy;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("BlogDb");
//builder.Services.AddDbContext<BlogDbContext>(
//    options =>
//        options.UseSqlServer(connectionString)
//);
builder.Services.AddHttpClient("RestApi", client =>
{
    client.BaseAddress = new Uri(System.Environment.GetEnvironmentVariable("apiUrl") ?? "http://localhost:5231"); // locate to github location
});

builder.Services.AddControllers();

builder.Services.TryAddTransient<DoItYourselfRepository>();
builder.Services.TryAddTransient<RecipeRepository>();
builder.Services.TryAddTransient<PhotografyRepository>();

builder.Services.AddScoped<DoItYourselfService>();
builder.Services.AddScoped<RecipeService>();
builder.Services.AddScoped<PhotografyService>();


var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
