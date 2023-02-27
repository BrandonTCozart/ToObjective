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
            var result = _db.Objectives.Where(x => x.Id == id).FirstOrDefault();
            result.CompletedDate = DateTime.Now;
            result.UpdatedDate = DateTime.Now;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteObjective(int id)
        {
            _db.Objectives.Remove(_db.Objectives.Where(x => x.Id == id).FirstOrDefault());
            await _db.SaveChangesAsync();
        }

        public async Task<Objective> GetObjectiveById(int id)
        {
            return await Task.FromResult(_db.Objectives.Where(x => x.Id == id).FirstOrDefault());
        }

        public async Task<IEnumerable<Objective>> GetObjectivesAsync()
        {
            return await Task.FromResult(from x in _db.Objectives
                                         orderby x.CompletedDate ascending,x.CompleteByDate ascending
                                         select x);
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

        public async Task<IEnumerable<Objective>> GetByTitleDescription(string s)
        {
            if (s == null)
            {
                return await Task.FromResult(from x in _db.Objectives
                       orderby x.CompletedDate ascending
                       select x);
            }
            return await Task.FromResult(from x in _db.Objectives
                   where x.Title.Contains(s) || x.Description.Contains(s)
                   orderby x.CompletedDate ascending
                   select x);
            
            
        }
    }
}
