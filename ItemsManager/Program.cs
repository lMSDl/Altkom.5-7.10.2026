using Models;
using Services.InMemory;
using Services.Interfaces;

IProductsService service = new ProductsService();

//inicjalizator obiektowy - pozwala na tworzenie obiektu i inicjalizowanie jego właściwości w jednym kroku
service.Create(new Models.Product { Name = "Czajnik", Price = 99.99f });

//bez inicjalizatora obiektowego:
Product product = new Product();
product.Name = "Mikser";
product.Price = 199.99f;
service.Create(product);

foreach (var p in service.ReadAll())
{
    Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Price: {p.Price}, CreatedAt: {p.CreatedAt}");
}