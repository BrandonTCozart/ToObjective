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

        public async Task CreateOrChangeObjective(Objective obj)
        {
            if (await _db.Objectives.FindAsync(obj.Id) != null)
            {
                if (!await IsComplete(obj))
                {
                    try
                    {
                        _db.Update(obj);
                        await _db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            else
            {
                await _db.AddAsync(new Objective(obj.Title, obj.Description, obj.CompleteByDate));
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> IsComplete(Objective obj)
        {
            var objec = await _db.Objectives.FindAsync(obj.Id);
            if (objec != null && objec.CompletedDate != null)
            {
                _db.Entry(objec).State = EntityState.Detached;
                return true;
            }
            _db.Entry(objec).State = EntityState.Detached;
            return false;
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
            }
            catch (Exception ex)
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Objective> GetObjectiveById(int id)
        {
            return await _db.Objectives.FindAsync(id);
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
