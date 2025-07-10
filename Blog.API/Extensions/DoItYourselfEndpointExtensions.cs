using Blog.Dataccess.Entities.DIY;
using Blog.Dataccess.Entities.Foods;
using Blog.Dataccess.Repositorys.DIY;
using Blog.Dataccess.Repositorys.Foods;
using Blog.Shared.DTOs.DIY;

namespace Blog.API.Extensions
{
    public static class DoItYourselfEndpointExtensions
    {
        public static IEndpointRouteBuilder MapDoItYourselfEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/diy", async (DoItYourselfRepository repo) =>
            {
                var diyItems = await repo.GetAllDIYsAsync();
                if (diyItems is null || !diyItems.Any())
                {
                    return Results.NotFound("No DIY items found");
                }
                return Results.Ok(diyItems);
            });

            app.MapGet("/api/diy/{id:int}", async (int id, DoItYourselfRepository repo) =>
            {
                var diyItem = await repo.GetDIYByIdAsync(id);
                return diyItem is null ? Results.NotFound($"DIY with ID {id} was not found") : Results.Ok(diyItem);
            });

            app.MapPost("/api/diy", async (DoItYourself diy, DoItYourselfRepository repo) =>
            {
                await repo.AddDIYAsync(diy);
                return Results.Ok("DIY successfully added!");
            });

            app.MapPut("/api/diy/{id:int}", async (int id, DoItYourselfDto diy, DoItYourselfRepository repo) =>
            {
                var existingDIY = await repo.GetDIYByIdAsync(id);
                if (existingDIY is null)
                {
                    return Results.NotFound($"DIY with id {id} was not found");
                }
                await repo.UpdateDIYAsync(diy);
                return Results.Ok($"DIY with id {id} was updated successfully");
            });

            app.MapDelete("/api/diy/{id:int}", async (int id, DoItYourselfRepository repo) =>
            {
                var existingDIY = await repo.GetDIYByIdAsync(id);
                if (existingDIY is null)
                {
                    return Results.NotFound($"DIY with id {id} was not found");
                }
                await repo.DeleteDIYAsync(id);
                return Results.Ok("DIY has successfully been removed");
            });

            return app;
        }
    }
}
