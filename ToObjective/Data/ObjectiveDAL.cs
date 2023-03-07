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

        public async Task AddObjective(Objective obj)
        {
            if (obj == null)
            {
                return;
            }
            try
            {
                _db.Objectives.Add(obj);
                await _db.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CompleteObjective(int id)
        {
            try
            {
                var result = await _db.Objectives.FindAsync(id);
                if (result == null)
                {
                    return;
                }
                result.CompletedDate = DateTime.Now;
                result.UpdatedDate = (DateTime)result.CompletedDate;
                await _db.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task DeleteObjective(int id)
        {
            var obj = await _db.Objectives.FindAsync(id);
            if (obj == null)
            {
                return;
            }
            try
            {
                _db.Objectives.Remove(obj);
                await _db.SaveChangesAsync();
            }catch (Exception ex) { 
                throw new Exception(ex.Message);
            }
        }

        public async Task<Objective> GetObjectiveById(int id)
        {
            return await _db.Objectives.FindAsync(id);
        }

        public async Task EditObjectives(Objective obj)
        {
            try
            {
                _db.Update(obj);
                await _db.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Objective>> GetByTitleDescription(string searchBoxString = null)
        {
            try
            {
                var query = from x in _db.Objectives
                            where searchBoxString == null || x.Title.Contains(searchBoxString) || x.Description.Contains(searchBoxString)
                            orderby x.CompletedDate ascending, x.CompleteByDate ascending
                            select x;
                return await query.ToListAsync();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
