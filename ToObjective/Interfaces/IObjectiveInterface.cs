using ToObjective.Models;

namespace ToObjective.Interfaces
{
    public interface IObjectiveInterface
    {
        IEnumerable<Objective> GetObjectives();
        void SetObjectives(List<Objective> list);
        Objective GetObjectiveById(int id);
        void DeleteObjective(int id);
        void CompleteObjective(int id);
        void AddObjective(Objective o);
    }
}
