using Models;

namespace Services.Interfaces
{
    public interface IEntityAsyncService : IEntityService
    {
        Task CreateAsync(Entity entity);
        Task<Entity?> ReadAsync(int id);
        Task<IEnumerable<Entity>> ReadAllAsync();
        Task<bool> UpdateAsync(int id, Entity entity);
        Task<bool> DeleteAsync(int id);
    }
}
