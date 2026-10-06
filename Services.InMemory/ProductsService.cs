using Models;
using Services.Interfaces;

namespace Services.InMemory
{
    // : IProductsService - oznacza, że klasa ProductsService implementuje interfejs IProductsService.
    // W praktyce oznacza to, że klasa ProductsService musi dostarczyć implementację wszystkich metod zadeklarowanych w interfejsie IProductsService.
    public class ProductsService : IProductsService
    {
        //private IEnumerable<Product> _entities; //IEnumerable nie pozwala na dodawanie, usuwanie i modyfikowanie elementów kolekcji, ponieważ jest to interfejs tylko do odczytu.
        //Aby móc modyfikować kolekcję produktów, należy użyć innego interfejsu, takiego jak ICollection<Product>, który rozszeża interfejs IEnumerable<Product> i umożliwia dodawanie, usuwanie i modyfikowanie elementów kolekcji.
        private ICollection<Product> _entities;

        public ProductsService()
        {    //inicjalizacja kolekcji, która pozwala na przechowywanie obiektów typu Product.
             //List<Product> jest implementacją interfejsu IEnumerable<Product>, który umożliwia iterowanie po kolekcji produktów.
             //Dzięki temu możemy dodawać, usuwać i modyfikować produkty w tej kolekcji.
             //_entities = new List<Product>();

            //skrócona wersja inicjalizacji pustej kolekcji, która jest zgodna z typem IEnumerable<Product>.
            //zapis wprowadzony w .NET8 (C#12)
            _entities = []; 
        }


        public void Create(Product entity)
        {
            int maxId = 0;
            foreach (var product in _entities)
            {
                if (product.Id > maxId)
                {
                    maxId = product.Id;
                }
            }

            entity.Id = maxId + 1;
            _entities.Add(entity);
        }

        public bool Delete(int id)
        {
            Product? entity = Read(id);
            if (entity != null)
            {
                _entities.Remove(entity);
                return true;
            }
            return false;
        }

        public Product? Read(int id)
        {
            /*Product? entity = null;
            foreach (var product in _entities)
            {
                if (product.Id == id)
                {
                    entity = product;
                    break;
                }
            }
            return entity;*/

            foreach (var product in _entities)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }

        public IEnumerable<Product> ReadAll()
        {
            //robimy kopię kolekcji produktów, aby zwrócić ją jako wynik metody.
            //Dzięki temu, jeśli ktoś zmieni kolekcję zwróconą przez metodę ReadAll(), nie wpłynie to na oryginalną kolekcję _entities.


            //return new List<Product>(_entities);
            return [.. _entities]; //zapis wprowadzony w .NET8 (C#12)
        }

        public bool Update(int id, Product entity)
        {
            /*Product? existingEntity = Read(id);
            if (existingEntity == null)
            {
                return false;
            }
            _entities.Remove(existingEntity);*/
            

            if(!Delete(id))
            {
                return false;
            }
            entity.Id = id;
            _entities.Add(entity);
            return true;
        }
    }
}
