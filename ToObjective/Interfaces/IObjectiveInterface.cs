using ToObjective.Models;

namespace ToObjective.Interfaces
{
    public interface IObjectiveInterface
    {
        Task<Objective> GetObjectiveById(int id);
        Task<object> DeleteObjective(int id);
        Task CompleteObjective(int id);
        Task AddObjective(Objective obj);
        Task EditObjectives(Objective obj);
        Task<IEnumerable<Objective>> GetByTitleDescription(string searchBoxString = null);
    }
}
