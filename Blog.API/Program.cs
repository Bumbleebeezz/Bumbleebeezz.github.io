using Blog.API.Services.DIY;
using Blog.API.Services.Foods;
using Blog.API.Services.Photografy;
using Blog.Dataccess;
using Blog.Dataccess.Entities.Foods;
using Blog.Dataccess.Repositorys.DIY;
using Blog.Dataccess.Repositorys.Foods;
using Blog.Dataccess.Repositorys.Photografy;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("BlogDb");
//builder.Services.AddDbContext<BlogDbContext>(
//    options =>
//        options.UseSqlServer(connectionString)
//);
builder.Services.AddHttpClient("RestApi", client =>
{
    client.BaseAddress = new Uri(System.Environment.GetEnvironmentVariable("apiUrl") ?? "http://localhost:5089"); // locate to github location
});



builder.Services.AddControllers();


builder.Services.AddScoped<DoItYourselfRepository>();
builder.Services.AddScoped<RecipeRepository>();
builder.Services.AddScoped<PhotografyRepository>();

//builder.Services.AddScoped<IDoItYourselfService,DoItYourselfService>();
//builder.Services.AddScoped<IRecipeService,RecipeService>();
//builder.Services.AddScoped<IPhotografyService,PhotografyService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();


//app.MapControllers();

app.Run();
