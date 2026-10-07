using Models;
using Services.Interfaces;

namespace Services.InMemory
{
    public class EntityAsyncService : EntityService, IEntityAsyncService
    {
        public async Task CreateAsync(Entity entity)
        {            
            //jeśli metoda jest oznaczona jako asynchroniczna, to nie znaczy, że musi być wykonywana w nowym wątku
            //tutaj metoda jest przerwana zanim odpalimy Task.Run
            if (entity is null)
                return;

            await Task.Run(() => Create(entity));
        }

        public Task<bool> DeleteAsync(int id)
        {
            if(ReadAsync(id) is null)
                return Task.FromResult(false);

            var retult = Delete(id);
            return Task.FromResult(retult); //opakowanie wyniku w Task, aby metoda była asynchroniczna
        }

        public async Task<IEnumerable<Entity>> ReadAllAsync()
        {
            await Task.Delay(5000);

            var result = ReadAll();
            return result; //jeśli użyliśmy await, to nie musimy używać Task.FromResult, bo metoda jest już asynchroniczna
        }

        public async Task<Entity?> ReadAsync(int id)
        {
            await Task.Delay(100); // symulacja opóźnienia asynchronicznego
            return Read(id);
        }

        public Task<bool> UpdateAsync(int id, Entity entity)
        {
            //return Task.Run(() => Update(id, entity)); //możemy użyć Task.Run, aby uruchomić metodę w nowym wątku

            var result = Update(id, entity);
            return Task.FromResult(result); //możemy też użyć Task.FromResult, aby zwrócić wynik synchronizacyjnie jako Task
        }
    }
}
