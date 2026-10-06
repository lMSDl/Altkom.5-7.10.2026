using Models;

namespace ItemsManager
{
    internal class ProductManager : EntityManager
    {
        protected override Entity CreateEntity()
        {
            return new Product();
        }

        protected override void ExtraCreate(Entity entity)
        {
            Product product = (Product)entity;

            product.Price = ReadFloat("Price");
            product.CreatedAt = ReadDate("Created at");
        }

        protected override void ExtraEdit(Entity current, Entity edited)
        {
            Product currentProduct = (Product)current;         
            Product editedProduct = (Product)edited;

            editedProduct.Price = ReadFloat($"Price ({currentProduct.Price})", currentProduct.Price);
            editedProduct.CreatedAt = ReadDate($"Created at ({currentProduct.CreatedAt})", currentProduct.CreatedAt);
        }

        public override void Run()
        {
            //inicjalizator obiektowy - pozwala na tworzenie obiektu i inicjalizowanie jego właściwości w jednym kroku
            _service.Create(new Models.Product { Name = "Czajnik", Price = 99.99f });

            //bez inicjalizatora obiektowego:
            Product product = new Product();
            product.Name = "Mikser";
            product.Price = 199.99f;
            _service.Create(product);

            base.Run();

            Console.WriteLine("Finished running ProductManager.");
        }
    }
}
