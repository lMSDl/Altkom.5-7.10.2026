using Models;
using Services.InMemory;
using Services.Interfaces;
using System.Reflection.Metadata.Ecma335;
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
    Console.WriteLine("Commands: create, edit, delete, exit");

    string input = Console.ReadLine()!; // ! - operator null-forgiving, mówi kompilatorowi, że nie spodziewamy się tu mimo wszystko nulla

    switch (input.ToLower())
    {
        case "create":
            Create();
            break;
        case "edit":
            Edit();
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

void Edit()
{
    int id = ReadInt("Id");
    Product? entity = service.Read(id);
    if(entity == null)
    {
        Console.WriteLine("Id not found");
        return;
    }

    entity = new Product();

    entity.Name = ReadString("Name");
    entity.Price = ReadFloat("Price");
    entity.CreatedAt = ReadDate("Created at");

    service.Update(id, entity);
}

void Create()
{
    Product entity = new Product();

    entity.Name = ReadString("Name");
    entity.Price = ReadFloat("Price");
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

int ReadInt(string label)
{
    string input = ReadString(label);

    int result;
    //tryParse - próbuje przekonwertować string na int, jeśli się nie uda, to nie rzuca wyjątku, tylko zwraca false
    //rezultat konwersji jest zwracany przez parametr oznaczony jako out
    //out - oznacza, że parametr jest przekazywany przez referencję i może być modyfikowany w funkcji
    bool success = int.TryParse(input, out result);

    if(success)
        return result;

    Console.WriteLine("Invalid number format");
    return ReadInt(label);
}

float ReadFloat(string label)
{
    float result;
    if(!TryReadFloat(label, out result))
    {
        return ReadFloat(label);
    }
    return result;
}

//własna implementacja TryPattern - pozwala na obsługę wyjątków w bardziej elegancki sposób
//zgodnie ze wzorcem funkcja zwraca bool, a wynik konwersji jest zwracany przez parametr out
bool TryReadFloat(string label, out float result)
{
    string input = ReadString(label);

    try
    {
        result = float.Parse(input);
        return true;
    }
    catch 
    {
        Console.WriteLine("Invalid number format");
        result = default;
        return false;
    }
}