using ToObjective.Models;

namespace ToObjective.Interfaces
{
    public interface IObjectiveInterface
    {
        Task<IEnumerable<Objective>> GetObjectivesAsync();
        Task<Objective> GetObjectiveById(int id);
        void DeleteObjective(int id);
        void CompleteObjective(int id);
        Task AddObjective(Objective o);
        void EditObjectives(Objective o);
        Task<IEnumerable<Objective>> GetByTitle(string s);
    }
}
