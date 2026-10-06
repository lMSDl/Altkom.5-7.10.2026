using Models;
using Services.InMemory;
using Services.Interfaces;
using System.Runtime.InteropServices;

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
    Console.WriteLine("Id - Name - Price - CreatedAt");
    foreach (var p in service.ReadAll())
    {
        Console.WriteLine($"{p.Id} - {p.Name} - {p.Price} - {p.CreatedAt}");
    }

    Console.WriteLine();
    Console.WriteLine("Commands: create, delete, exit");

    string input = Console.ReadLine()!; // ! - operator null-forgiving, mówi kompilatorowi, że nie spodziewamy się tu mimo wszystko nulla

    switch (input.ToLower())
    {
        case "create":
            Create();
            break;
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

void Create()
{
    Product entity = new Product();

    entity.Name = ReadString("Name");
    entity.CreatedAt = ReadDate("Created at");

    service.Create(entity);
}

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

string ReadString(string label)
{
    Console.Write($"{label}: ");
    return Console.ReadLine()!;
}

DateTime ReadDate(string label)
{
    string input = ReadString(label);
    DateTime dateTime;

    try
    {
        dateTime = DateTime.Parse(input);
        if (dateTime > DateTime.Now)
        {
            //rzucenie wyjątku - pozwala na przerwanie działania programu i przekazanie informacji o błędzie do wywołującego kodu
            throw new InvalidDataException("Date cannot be in the future");
        }
    }
    //filtrujemy wyjątki po typie - możemy obsłużyć różne wyjątki w różny sposób
    //catch z instancją wyjątku (e) - pozwala na dostęp do informacji o wyjątku
    catch (InvalidDataException e)
    {
        Console.WriteLine(e.Message);
        dateTime = ReadDate(label); //rekurencyjne wywołanie funkcji - pozwala na ponowne wczytanie daty
    }
    //catch tylko z typem wyjątku - nie mamy dostępu do informacji o wyjątku
    catch (FormatException)
    {
        Console.WriteLine($"Invalid date format");
        dateTime = ReadDate(label);
    }
    //kolejność catchów - jeśli wyjątek nie pasuje do żadnego z powyższych, to zostanie przechwycony przez ten catch
    //najpierw sprawdzamy bardziej szczegółowe wyjątki, a potem bardziej ogólne
    catch (Exception e)
    {
        Console.WriteLine($"Unexpected error: {e.Message}");
        dateTime = ReadDate(label);
    }

    return dateTime;
}