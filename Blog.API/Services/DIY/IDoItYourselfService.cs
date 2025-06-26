using Blog.Shared.DTOs.DIY;

namespace Blog.API.Services.DIY
{
    public interface IDoItYourselfService
    {
        /// <summary>
        ///     Get a default list of all diys.
        /// </summary>
        /// <returns>A list of default diys</returns>
        Task<IEnumerable<DoItYourselfDto>> GetAllDIYsAsync();
        /// <summary>
        /// Asynchronously retrieves a diy by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the diy to retrieve.</param>
        /// <returns>The task result is a <see cref="DoItYourselfDto"/> containing the diy details.</returns>
        Task<DoItYourselfDto> GetDIYByIdAsync(int id);
        /// <summary>
        /// Creates a new diy.
        /// </summary>
        /// <param name="diy"></param>
        /// <returns>new diy</returns>
        Task AddDIYAsync(DoItYourselfDto diy);
        /// <summary>
        /// Update a diy.
        /// </summary>
        /// <param name="diy">DIY that should be updated</param>
        /// <returns> Updated diy</returns>
        Task UpdateDIYAsync(DoItYourselfDto diy);
        /// <summary>
        ///     Delete a diy with a given Id
        /// </summary>
        /// <param name="id">Id of diy to delete</param>
        /// <returns></returns>
        Task DeleteDIYAsync(int id);
        /// <summary>
        ///     Get a default list of diys by search string.
        /// </summary>
        /// <param searchDIY="searchDIY"></param>
        /// <returns>list of diys</returns>
        Task<IEnumerable<DoItYourselfDto>> SearchDIYsAsync(string searchDIY);
        /// <summary>
        ///     Get a default list of diys by category.
        /// </summary>
        /// <param category="category">Category of a diys</param>
        /// <returns>list of diys</returns>
        Task<IEnumerable<DoItYourselfDto>> GetDIYsByCategoryAsync(string category);
    }
}
