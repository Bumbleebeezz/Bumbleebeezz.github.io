

using Blog.API.Services.DIY;
using Blog.API.Services.Foods;
using Blog.API.Services.Photografy;
using Blog.Shared.DTOs.Foods;
using Blog.Shared.DTOs.Photografy;
using Blog.Shared.Interfaces.Foods;
using Blog.Shared.Interfaces.Photografy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

builder.Services.AddScoped<IDoItYourselfService, IDoItYourselfService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IPhotografyService, PhotografyService>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
