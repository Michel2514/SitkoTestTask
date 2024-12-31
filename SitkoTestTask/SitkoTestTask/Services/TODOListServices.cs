using Microsoft.EntityFrameworkCore;
using SitkoTestTask.Data;
using SitkoTestTask.Interfaces;

namespace SitkoTestTask.Services
{
    public class TODOListServices : ITODOListService
    {
        private readonly TestDbContext db;
        public async Task<TODOList> TODOListById(Guid tODOListId)
        {
            var tODOLiistById = await db.TODOLists.FirstOrDefaultAsync(x => x.Id == tODOListId);
            return tODOLiistById ?? new TODOList();
        }
        public async Task<List<TODOList>> TODOListGetAll() => await db.TODOLists.ToListAsync() ?? new List<TODOList>();
        public async Task<bool> TODOListCreated(TODOList tODOList)
        {
            try
            {
                await db.TODOLists.AddAsync(tODOList);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> TODOListDeleted(Guid tODOListId)
        {
            var tODOListDeletedById = await db.TODOLists.FirstOrDefaultAsync(x=> x.Id == tODOListId);
            if (tODOListDeletedById == null)
                return false;
            db.TODOLists.Remove(tODOListDeletedById);
            await db.SaveChangesAsync();
            return true;
        }

       

        public async Task<bool> TODOListUpdated(TODOList tODOListId)
        {
            var enyIdTODOList = await db.TODOLists.FirstOrDefaultAsync
                (x => x.Id == tODOListId.Id);
            if(enyIdTODOList == null)
                return false;
            db.TODOLists.Update(enyIdTODOList);
            db.SaveChanges();

            return true;
        }
    }
}
