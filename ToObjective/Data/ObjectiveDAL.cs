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

        public void AddObjective(Objective o)
        {
            if (o == null)
            { }
            else
            {
                _db.Objectives.Add(o);
                _db.SaveChanges();
            }
        }

        public void CompleteObjective(int id)
        {
            var result = _db.Objectives.Where(x => x.Id == id).First();
            result.CompletedDate = DateTime.Now;
            result.UpdatedDate = DateTime.Now;
            _db.SaveChanges();
        }

        public void DeleteObjective(int id)
        {
            _db.Objectives.Remove(_db.Objectives.Where(x => x.Id == id).First());
            _db.SaveChanges();
        }

        public Objective GetObjectiveById(int id)
        {
            return _db.Objectives.Where(x => x.Id == id).First();
        }

        public IEnumerable<Objective> GetObjectives()
        {
            return from x in _db.Objectives
                   orderby x.CompleteByDate ascending
                   orderby x.CompletedDate ascending
                   select x;
        }

        public void EditObjectives(Objective o)
        {
            var obj = _db.Objectives.Where(x => x.Id == o.Id).First();
            obj.UpdatedDate = DateTime.Now;
            obj.Title= o.Title;
            obj.Description= o.Description;
            obj.CompleteByDate = o.CompleteByDate;
            _db.SaveChanges();
        }

        public IEnumerable<Objective> GetByTitle(string s)
        {
            if (s == "" || s == null)
            {
                return from x in _db.Objectives
                       orderby x.CompletedDate ascending
                       select x;
            }
            else
            {
                return from x in _db.Objectives
                       where x.Title.Contains(s)
                       orderby x.CompletedDate ascending
                       select x;
            }
            
        }
    }
}
