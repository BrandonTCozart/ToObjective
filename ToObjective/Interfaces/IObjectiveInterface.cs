using ToObjective.Models;

namespace ToObjective.Interfaces
{
    public interface IObjectiveInterface
    {
        Task<Objective> GetObjectiveById(int id);
        Task DeleteObjective(int id);
        Task CompleteObjective(int id);
        Task CreateOrChangeObjective(Objective obj);
        Task<IEnumerable<Objective>> GetByTitleDescription(string searchBoxString = null);
    }
}
