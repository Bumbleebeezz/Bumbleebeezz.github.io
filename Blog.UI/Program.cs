using Blog.Shared.DTOs.DIY;
using Blog.Shared.DTOs.Foods;
using Blog.Shared.DTOs.Photografy;
using Blog.Shared.Interfaces.DIY;
using Blog.Shared.Interfaces.Foods;
using Blog.Shared.Interfaces.Photografy;
using Blog.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();

builder.Services.AddHttpClient("RestApi", client =>
{
    client.BaseAddress = new Uri(System.Environment.GetEnvironmentVariable("apiUrl") ?? "http://localhost:5089");
});

builder.Services.AddScoped<RecipeService>();
builder.Services.AddScoped<PhotografyService>();
builder.Services.AddScoped<DoItYourselfService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();




//app.UseHttpsRedirection();

//app.UseRouting();

//app.UseAuthorization();

//app.MapStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
