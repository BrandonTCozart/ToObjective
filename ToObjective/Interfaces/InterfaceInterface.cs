using ToObjective.Models;

namespace ToObjective.Interfaces
{
    public interface InterfaceInterface
    {
        List<Objective> getObjectives();
        void setObjectives(List<Objective> list);
        Objective getObjectiveById(int id);
        void deleteObjective(int id);
        void completeObjective(int id);
    }
}
