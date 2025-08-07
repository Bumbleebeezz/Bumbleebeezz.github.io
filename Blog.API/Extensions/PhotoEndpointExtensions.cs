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
                if (photos is null || !photos.Any())
                {
                    return Results.NotFound("No photos found");
                }
                return Results.Ok(photos);
            });

            app.MapGet("/api/photos/{id:int}", async (int id, PhotografyRepository repo) =>
            {
                var photo = await repo.GetPhotografyByIdAsync(id);
                return photo is null ? Results.NotFound($"Photo with ID {id} was not found") : Results.Ok(photo);
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
            app.MapPost("/api/photos", async (Photo photo, PhotografyRepository repo) =>
            {
                await repo.AddPhotografyAsync(photo);
                return Results.Ok("Photo successfully added!");
            });

            app.MapPut("/api/photos/{id:int}", async (int id, PhotoDto photoDto, PhotografyRepository repo) =>
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
                return Results.Ok("Photo has successfully been removed");
            });

            return app;
        }
    }
}
