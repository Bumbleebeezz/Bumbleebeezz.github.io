using Blog.Dataccess.Entities.Photografy;
using Blog.Dataccess.Repositorys.Photografy;
using Blog.Shared.DTOs.Photografy;

namespace Blog.API.Extensions
{
    public static class PhotoEndpointExtensions
    {
        public static IEndpointRouteBuilder MapPhotoEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/photos", async (PhotografyRepository repo) =>
            {
                var photos = await repo.GetAllPhotografiesAsync();
                return Results.Ok(photos);
            });

            app.MapGet("/api/photos/{id:int}", async (int id, PhotografyRepository repo) =>
            {
                var photo = await repo.GetPhotografyByIdAsync(id);
                return photo is not null ? Results.Ok(photo) : Results.NotFound();
            });

            app.MapGet("/photos/search/{category}", async (PhotografyRepository repo, string category) =>
            {
                var photos = await repo.GetPhotografiesByCategoryAsync(category);
                if (photos is null)
                {
                    return Results.NotFound($"Photos with category {category} was not found");
                }

                return Results.Ok(photos);
            });
            app.MapPut("/api/photos", async (Photo photo, PhotografyRepository repo) =>
            {
                await repo.AddPhotografyAsync(photo);
                return Results.NoContent();
            });

            app.MapPatch("/api/photos/{id:int}", async (int id, PhotoDto photoDto, PhotografyRepository repo) =>
            {
                var existingPhoto = await repo.GetPhotografyByIdAsync(id);
                if (existingPhoto is null)
                {
                    return Results.NotFound($"Photo with id {id} was not found");
                }
                await repo.UpdatePhotografyAsync(photoDto);
                return Results.Ok($"Photo with id {id} was updated successfully");
            });

            app.MapDelete("/api/photos/{id:int}", async (int id, PhotografyRepository repo) =>
            {
                var existingPhoto = await repo.GetPhotografyByIdAsync(id);
                if (existingPhoto is null)
                {
                    return Results.NotFound($"Photo with id {id} was not found");
                }
                await repo.DeletePhotografyAsync(id);
                return Results.NoContent();
            });

            return app;
        }
    }
}
