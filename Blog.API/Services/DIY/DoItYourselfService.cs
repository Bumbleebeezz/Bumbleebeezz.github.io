using Blog.Dataccess.Entities.DIY;
using Blog.Dataccess.Repositorys.DIY;
using Blog.Shared.DTOs.DIY;
using Blog.Shared.Interfaces.DIY;

namespace Blog.API.Services.DIY
{
    public class DoItYourselfService(DoItYourselfRepository doItYourselfRepository) : IDoItYourselfService<DoItYourself>
    {
        public Task AddDIYAsync(DoItYourselfDto diy)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDIYAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DoItYourself>> GetAllDIYsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DoItYourself> GetDIYByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DoItYourself>> GetDIYsByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DoItYourself>> SearchDIYsAsync(string searchDIY)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDIYAsync(DoItYourselfDto diy)
        {
            throw new NotImplementedException();
        }
    }
}
