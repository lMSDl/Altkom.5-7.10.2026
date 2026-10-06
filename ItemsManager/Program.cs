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

bool exit = false;
do
{
    Console.Clear();
    Console.WriteLine("Id - Name - Price");
    foreach (var p in service.ReadAll())
    {
        Console.WriteLine($"{p.Id} - {p.Name} - {p.Price}");
    }

    Console.WriteLine();
    Console.WriteLine("Commands: exit");

    string input = Console.ReadLine()!; // ! - operator null-forgiving, mówi kompilatorowi, że nie spodziewamy się tu mimo wszystko nulla

    switch (input.ToLower())
    {
        case "exit":
            exit = true;
            break;
        default:
            Console.WriteLine("Unknown command");
            break;
    }

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
} while (!exit);