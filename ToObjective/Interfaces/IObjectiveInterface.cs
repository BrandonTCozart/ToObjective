using ToObjective.Models;

namespace ToObjective.Interfaces
{
    public interface IObjectiveInterface
    {
        IEnumerable<Objective> GetObjectives();
        Objective GetObjectiveById(int id);
        void DeleteObjective(int id);
        void CompleteObjective(int id);
        void AddObjective(Objective o);
        void editObjectives(Objective o);

        //IEnumerable<Objective> GetObjectivesByTitle(string title);
    }
}
