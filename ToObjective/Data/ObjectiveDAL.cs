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
            if (id == null)
            {
                return;
            }
            _db.Objectives.Remove(await _db.Objectives.FindAsync(id));
            await _db.SaveChangesAsync();
        }

        public async Task<Objective> GetObjectiveById(int id)
        {
            var query = await _db.Objectives.Where(x => x.Id == id).ToListAsync();
            return query.FirstOrDefault();
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

            var obj = _db.Objectives.Where(x => x.Id == o.Id).FirstOrDefault();
            obj.UpdatedDate = DateTime.Now;
            obj.Title= o.Title;
            obj.Description= o.Description;
            obj.CompleteByDate = o.CompleteByDate;
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
