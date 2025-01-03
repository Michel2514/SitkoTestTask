using Microsoft.AspNetCore.Http.HttpResults;
using SitkoTestTask.Data;

namespace SitkoTestTask.Interfaces
{
    public interface ITODOListService
    {
        public Task<bool> TODOListCreatedAsync(TODOList tODOList);
        public bool TODOListCreated(TODOList tODOList);

        public Task<bool> TODOListDeleted(Guid tODOListId);
        public Task<bool> TODOListUpdated(TODOList tODOListId);
        public Task<TODOList> TODOListById (Guid tODOListId);

        public Task<List<TODOList>> TODOListGetAllAsync();
        public List<TODOList> TODOListGetAll();

        public Task<List<TODOList>> TODOListComplitedsAsync(bool completed);
        public Task<List<TODOList>> TODOListActives();
        public List<TODOList> TODOListCompliteds(bool completed);
    }
}
