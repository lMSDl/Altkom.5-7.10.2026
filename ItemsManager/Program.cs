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
    Console.WriteLine("Commands: delete, exit");

    string input = Console.ReadLine()!; // ! - operator null-forgiving, mówi kompilatorowi, że nie spodziewamy się tu mimo wszystko nulla

    switch (input.ToLower())
    {
        case "delete":
            Delete();
            break;
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



void Delete()
{
    Console.Write("Id: ");
    string input = Console.ReadLine()!;
    int id;

    //try-catch - służy do obsługi wyjątków
    //w bloku try umieszczamy kod, który może rzucić wyjątek
    try
    {
        id = int.Parse(input);
    }
    //catch (bez parametrów) - przechwytujemy wszystkie wyjątki i nie dostajemy informacji jaki to wyjątek
    catch
    {
        id = -1;
    }
    
    if(!service.Delete(id))
    {
        Console.WriteLine("Id not found");
    }
}