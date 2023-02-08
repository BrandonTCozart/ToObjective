using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToObjective.Data;
using ToObjective.Interfaces;
using ToObjective.Models;


namespace ToObjective.Controllers
{
    public class DataAccess : InterfaceInterface
    {
        private readonly ObjectiveDbContext _db;

        public DataAccess(ObjectiveDbContext db)
        {
            _db = db;
        }

        public void completeObjective(int id)
        {
            var result = _db.Objectives.Where(x => x.Id == id).First();
            result.CompletedDate = DateTime.Now;
            result.UpdatedDate = DateTime.Now;
            _db.SaveChanges();
        }

        public void deleteObjective(int id)
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

        public Objective getObjectiveById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Objective> getObjectives()
        {
            IEnumerable<Objective> objectivesList = _db.Objectives;
            return (List<Objective>)objectivesList;
        }

        public void setObjectives(List<Objective> list)
        {
            throw new NotImplementedException();
        }
    }
}
