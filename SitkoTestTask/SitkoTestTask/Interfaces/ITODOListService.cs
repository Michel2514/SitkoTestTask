using Microsoft.AspNetCore.Http.HttpResults;
using SitkoTestTask.Data;

namespace SitkoTestTask.Interfaces
{
    public interface ITODOListService
    {
        public Task<bool> TODOListCreated(TODOList tODOList);
        public Task<bool> TODOListDeleted(Guid tODOListId);
        public Task<bool> TODOListUpdated(TODOList tODOListId);
        public Task<TODOList> TODOListById (Guid tODOListId);
        public Task<List<TODOList>> TODOListGetAll();
    }
}
