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
            var result = await _db.Objectives.FindAsync(id);
            try
            {
                result.CompletedDate = DateTime.Now;
                result.UpdatedDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                return;
            }
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

            var query = await _db.Objectives.FindAsync(id);
            return query;
        }

        public async Task EditObjectives(Objective o)
        {
            _db.Update(o);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Objective>> GetByTitleDescription(string searchBoxString = null)
        {

            var query = from x in _db.Objectives
                        where searchBoxString == null || x.Title.Contains(searchBoxString) || x.Description.Contains(searchBoxString)
                        orderby x.CompletedDate ascending, x.CompleteByDate ascending
                        select x;
            return await query.ToListAsync();


        }
    }
}
