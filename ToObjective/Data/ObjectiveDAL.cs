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
            DbSet<Objective> objectivesList = _db.Objectives;
            objectivesList.Add(o);
            _db.Objectives = objectivesList;
            _db.SaveChanges();
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
            DbSet<Objective> objectivesList = _db.Objectives;

            foreach (Objective obj in objectivesList)
            {
                if (obj.Id == id)
                {
                    _db.Objectives.Remove(obj);
                    _db.SaveChanges();
                }
            }
        }

        public Objective GetObjectiveById(int id)
        {
            return _db.Objectives.Where(x => x.Id == id).First();
        }

        public IEnumerable<Objective> GetObjectives()
        {
            IEnumerable<Objective> objectivesList = _db.Objectives;
            return objectivesList;
        }

        public void SetObjectives(List<Objective> list)
        {
            throw new NotImplementedException();
        }
    }
}
