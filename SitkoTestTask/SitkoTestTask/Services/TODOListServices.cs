using Microsoft.EntityFrameworkCore;
using SitkoTestTask.Data;
using SitkoTestTask.Interfaces;

namespace SitkoTestTask.Services
{
    public class TODOListServices : ITODOListService
    {
        private readonly TestDbContext _db;
        public TODOListServices(TestDbContext db)
        {
            _db = db;
        }

        public async Task<TODOList> TODOListById(Guid tODOListId)
        {
            var tODOLiistById = await _db.TODOLists.FirstOrDefaultAsync(x => x.Id == tODOListId);
            return tODOLiistById ?? new TODOList();
        }
        public async Task<List<TODOList>> TODOListGetAllAsync() => await _db.TODOLists.ToListAsync();
        public List<TODOList> TODOListGetAll()=> _db.TODOLists.ToList();
        public async Task<bool> TODOListCreatedAsync(TODOList tODOList)
        {
            try
            {
               
                await _db.TODOLists.AddAsync(tODOList);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool TODOListCreated(TODOList tODOList)
        {
            _db.TODOLists.Add(tODOList);
            _db.SaveChanges();
            return true;
        }

        public async Task<bool> TODOListDeleted(Guid tODOListId)
        {
            var tODOListDeletedById = await _db.TODOLists.FirstOrDefaultAsync(x=> x.Id == tODOListId);
            if (tODOListDeletedById == null)
                return false;
            _db.TODOLists.Remove(tODOListDeletedById);
            await _db.SaveChangesAsync();
            return true;
        }

       

        public async Task<bool> TODOListUpdated(TODOList tODOListId)
        {
            var enyIdTODOList = await _db.TODOLists.FirstOrDefaultAsync
                (x => x.Id == tODOListId.Id);
            if(enyIdTODOList == null)
                return false;
            _db.TODOLists.Update(enyIdTODOList);
            _db.SaveChanges();

            return true;
        }
   
        public Task<List<TODOList>> TODOListActives()
        {
            throw new NotImplementedException();
        }

        public async Task<List<TODOList>> TODOListComplitedsAsync(bool completed)
        {
            return await _db.TODOLists.Where(x=>x.Completed == completed).ToListAsync();
        }

        List<TODOList> ITODOListService.TODOListCompliteds(bool completed)
        {
            return _db.TODOLists.Where(x => x.Completed == completed).ToList();
        }
    }
}
