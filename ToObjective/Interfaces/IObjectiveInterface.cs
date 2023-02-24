using ToObjective.Models;

namespace ToObjective.Interfaces
{
    public interface IObjectiveInterface
    {
        Task<IEnumerable<Objective>> GetObjectivesAsync();
        Task<Objective> GetObjectiveById(int id);
        Task DeleteObjective(int id);
        Task CompleteObjective(int id);
        Task AddObjective(Objective o);
        Task EditObjectives(Objective o);
        Task<IEnumerable<Objective>> GetByTitle(string s);
    }
}
