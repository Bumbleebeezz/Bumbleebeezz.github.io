using Blog.Shared.DTOs.Photografy;

namespace Blog.API.Services.Photografy
{
    public interface IPhotografyService
    {
        /// <summary>
        ///     Get a default list of all photos.
        /// </summary>
        /// <returns>A list of default photos</returns>
        Task<IEnumerable<PhotoDto>> GetAllPhotografiesAsync();
        /// <summary>
        /// Asynchronously retrieves a photo by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the photo to retrieve.</param>
        /// <returns>The task result is a <see cref="PhotoDto"/> containing the photo details.</returns>
        Task<PhotoDto> GetPhotografyByIdAsync(int id);
        /// <summary>
        /// Creates a new photografy.
        /// </summary>
        /// <param name="photografy"></param>
        /// <returns>new photografy</returns>
        Task AddPhotografyAsync(PhotoDto photografy);
        /// <summary>
        /// Update a photografy.
        /// </summary>
        /// <param name="photografy"></param>
        /// <returns>updated photo</returns>
        Task UpdatePhotografyAsync(PhotoDto photografy);
        /// <summary>
        ///     Delete a Photo with a given Id
        /// </summary>
        /// <param name="id">Id of photo to delete</param>
        /// <returns></returns>
        Task DeletePhotografyAsync(int id);
        /// <summary>
        ///     Get a default list of photos by search string.
        /// </summary>
        /// <param searchTerm="searchTerm"></param>
        /// <returns>list of photos</returns>
        Task<IEnumerable<PhotoDto>> SearchPhotografiesAsync(string searchTerm);
        /// <summary>
        ///     Get a default list of photos by category.
        /// </summary>
        /// <param category="category">Category of a photo</param>
        /// <returns>list of photos</returns>
        Task<IEnumerable<PhotoDto>> GetPhotografiesByCategoryAsync(string category);
    }
}
