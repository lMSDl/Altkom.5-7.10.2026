using Models;

namespace Services.Interfaces
{
    public interface IEntityService
    {
        void Create(Entity entity);
        Entity? Read(int id);
        IEnumerable<Entity> ReadAll();
        bool Update(int id, Entity entity);
        bool Delete(int id);
    }
}
