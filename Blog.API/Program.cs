using Blog.API.Extensions;
using Blog.Dataccess;
using Blog.Dataccess.Repositorys.DIY;
using Blog.Dataccess.Repositorys.Foods;
using Blog.Dataccess.Repositorys.Photografy;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("BlogDb");
builder.Services.AddDbContext<BlogDbContext>(
    options =>
        options.UseSqlServer(connectionString)
);
builder.Services.AddHttpClient("RestApi", client =>
{
    client.BaseAddress = new Uri(System.Environment.GetEnvironmentVariable("apiUrl") ?? "http://localhost:5089"); // locate to github location
});

//builder.Services.AddControllers();

builder.Services.AddScoped<DoItYourselfRepository>();
builder.Services.AddScoped<RecipeRepository>();
builder.Services.AddScoped<PhotografyRepository>();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();




var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();


//app.MapControllers();

app.MapGet("/", () => "API is running!");
app.MapPhotoEndpoints();
app.MapRecipeEndpoints();
app.MapDoItYourselfEndpoints();

app.Run();
