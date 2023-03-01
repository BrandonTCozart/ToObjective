using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToObjective.Interfaces;
using ToObjective.Models;


namespace ToObjective.Data
{
    public class ObjectiveDAL : IObjectiveInterface
    {
        private readonly ObjectiveDbContext _db;

        public ObjectiveDAL(ObjectiveDbContext db)
        {
            _db = db;
        }

        public async Task AddObjective(Objective o)
        {
            if (o != null)
            {
                _db.Objectives.Add(o);
                await _db.SaveChangesAsync();
            }
        }

        public async Task CompleteObjective(int id)
        {
            var result = _db.Objectives.FindAsync(id);
            result.Result.CompletedDate= DateTime.Now;
            result.Result.UpdatedDate = DateTime.Now;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteObjective(int id)
        {
            if (await _db.Objectives.FindAsync(id) == null)
            {
                return;
            }
            _db.Objectives.Remove(await _db.Objectives.FindAsync(id));
            await _db.SaveChangesAsync();
        }

        public async Task<Objective> GetObjectiveById(int id)
        {
            try
            {
                var query = await _db.Objectives.Where(x => x.Id == id).FirstAsync();
                return query;
            }
            catch(Exception ex)
            {
                return null;
            }
         
        }

        public async Task<IEnumerable<Objective>> GetObjectivesAsync()
        {
            var query = from x in _db.Objectives
                                         orderby x.CompletedDate ascending,x.CompleteByDate ascending
                                         select x;
            return await query.ToListAsync();
        }
        
        public async Task EditObjectives(Objective o)
        {

            var obj = _db.Objectives.Where(x => x.Id == o.Id).FirstAsync();
            obj.Result.UpdatedDate = DateTime.Now;
            obj.Result.Title= o.Title;
            obj.Result.Description= o.Description;
            obj.Result.CompleteByDate = o.CompleteByDate;
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Objective>> GetByTitleDescription(string searchBoxString)
        {
            
             var query = from x in _db.Objectives
                   where searchBoxString == null || x.Title.Contains(searchBoxString) || x.Description.Contains(searchBoxString)
                   orderby x.CompletedDate ascending
                   select x;
            return await query.ToListAsync();


        }
    }
}
