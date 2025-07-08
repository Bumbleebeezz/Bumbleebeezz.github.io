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
                return Results.Ok(diyItems);
            });

            app.MapGet("/api/diy/{id:int}", async (int id, DoItYourselfRepository repo) =>
            {
                var diyItem = await repo.GetDIYByIdAsync(id);
                return diyItem is not null ? Results.Ok(diyItem) : Results.NotFound();
            });

            app.MapPut("/api/diy", async (DoItYourself diy, DoItYourselfRepository repo) =>
            {
                await repo.AddDIYAsync(diy);
                return Results.NoContent();
            });

            app.MapPatch("/api/diy/{id:int}", async (int id, DoItYourselfDto diy, DoItYourselfRepository repo) =>
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
                return Results.NoContent();
            });

            return app;
        }
    }
}
