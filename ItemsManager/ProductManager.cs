using Models;

namespace ItemsManager
{
    internal class ProductManager : EntityManager<Product>
    {
        public ProductManager(string filePath) : base(filePath)
        {
        }

        protected override void ExtraCreate(Product entity)
        {
            entity.Price = ReadFloat("Price");
            entity.CreatedAt = ReadDate("Created at");
        }

        protected override void ExtraEdit(Product current, Product edited)
        {
            edited.Price = ReadFloat($"Price ({current.Price})", current.Price);
            edited.CreatedAt = ReadDate($"Created at ({current.CreatedAt})", current.CreatedAt);
        }

        public override void Run()
        {
            /*//inicjalizator obiektowy - pozwala na tworzenie obiektu i inicjalizowanie jego właściwości w jednym kroku
            _service.Create(new Models.Product { Name = "Czajnik", Price = 99.99f });

            //bez inicjalizatora obiektowego:
            Product product = new Product();
            product.Name = "Mikser";
            product.Price = 199.99f;
            _service.Create(product);*/

            base.Run();

            Console.WriteLine("Finished running ProductManager.");
        }
    }
}
