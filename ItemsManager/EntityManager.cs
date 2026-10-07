using Models;
using Services.InMemory;
using Services.Interfaces;
using System.Text.Json;
using System.Xml.Serialization;

namespace ItemsManager
{
    // <T> - parametr generyczny, który pozwala na tworzenie klas, metod i interfejsów, które mogą działać z różnymi typami danych.
    //      Dzięki temu możemy tworzyć bardziej elastyczne i wielokrotnego użytku komponenty, które mogą być używane z różnymi typami danych bez konieczności duplikowania kodu.
    // where T : - ograniczenie generyczne, które określa, że typ T musi dziedziczyć po klasie Entity.
    //      Oznacza to, że możemy używać tylko tych typów danych, które są klasami dziedziczącymi po Entity, co pozwala na korzystanie z właściwości i metod zdefiniowanych w klasie Entity w naszej klasie EntityManager.
    internal abstract class EntityManager<T> where T : Entity
    {
        protected IEntityService _service = new EntityService();

        public virtual void Run()
        {
            bool exit = false;
            do
            {
                Console.Clear();
                foreach (var e in _service.ReadAll())
                {
                    Console.WriteLine(e.ToString());
                }

                Console.WriteLine();
                Console.WriteLine("Commands: create, edit, delete, json, xml, exit");

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
                    case "json":
                        ToJson();
                        break;
                    case "xml":
                        ToXml();
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

        }

        //serializacja - proces przekształcania obiektu w format, który można przechowywać lub przesyłać
        private void ToJson()
        {
            var items = _service.ReadAll().Cast<T>(); // Cast<T>() - rzutowanie elementów kolekcji na typ T, ponieważ ReadAll() zwraca IEnumerable<Entity>, a my chcemy IEnumerable<T>

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true, // WriteIndented - pozwala na ładne formatowanie JSON-a z wcięciami i nowymi liniami, co ułatwia jego czytanie
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // PropertyNamingPolicy - pozwala na określenie sposobu nazewnictwa właściwości w JSON-ie. W tym przypadku używamy CamelCase, czyli pierwsza litera mała, a kolejne słowa zaczynają się od wielkiej litery
                IgnoreReadOnlyProperties = true, // IgnoreReadOnlyProperties - pozwala na pominięcie właściwości tylko do odczytu podczas serializacji, co może być przydatne, jeśli chcemy uniknąć niepotrzebnych danych w JSON-ie
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault, // DefaultIgnoreCondition - pozwala na określenie warunku, kiedy właściwości mają być pomijane podczas serializacji. W tym przypadku pomijamy właściwości, które mają wartość domyślną (np. null dla referencji, 0 dla liczb, false dla bool)
            };

            //JsonSerializer - klasa do serializacji obiektów do formatu JSON
            //JsonSerializer może serializować obiekty bezpośrednio do stringa
            string json = JsonSerializer.Serialize(items, options);
            Console.WriteLine(json);
        }

        private void ToXml()
        {
            var items = _service.ReadAll().Cast<T>().ToList();
            XmlSerializer xmlSerializer = new XmlSerializer(items.GetType());

            MemoryStream memoryStream = new MemoryStream(); // strumień pamięci do przechowywania danych XML
            xmlSerializer.Serialize(memoryStream, items);

            var xmlArray = memoryStream.ToArray(); //konwertujemy strumień pamięci na tablicę bajtów
            var xml = System.Text.Encoding.Default.GetString(xmlArray); //konwertujemy tablicę bajtów na string

            Console.WriteLine(xml);
        }

        void Edit()
        {
            int id = ReadInt("Id");
            T? entity = (T?)_service.Read(id);
            if (entity == null)
            {
                Console.WriteLine("Id not found");
                return;
            }

            T newEntity = Activator.CreateInstance<T>();

            newEntity.Name = ReadString($"Name ({entity.Name})", entity.Name);
            ExtraEdit(entity, newEntity);

            _service.Update(id, newEntity);
        }
        protected abstract void ExtraEdit(T current, T edited);

        void Create()
        {
            T entity = Activator.CreateInstance<T>();

            entity.Name = ReadString("Name");
            ExtraCreate(entity);

            _service.Create(entity);
        }

        protected abstract void ExtraCreate(T entity);


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

            if (!_service.Delete(id))
            {
                Console.WriteLine("Id not found");
            }
        }

        /*string ReadString(string label)
        {
            Console.Write($"{label}: ");
            return Console.ReadLine()!;
        }*/

        //@ - pozwala używać słów kluczowych jako nazw zmiennych, parametrów itp. - przydatne gdy chcemy zachować czytelność kodu i użyć słowa kluczowego jako nazwy
        //parametr opcjonalny - pozwala na pominięcie argumentu przy wywołaniu funkcji, jeśli nie chcemy go podawać. Musimy podać wartość domyślną dla parametru opcjonalnego.
        //W tym przypadku, jeśli nie podamy wartości dla parametru @default, to zostanie użyta wartość domyślna "" (pusty string)
        static string ReadString(string label, string @default = "")
        {
            Console.Write($"{label}: ");
            string input = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(input))
            {
                return @default;
            }
            return input;
        }

        protected DateTime ReadDate(string label, DateTime? @default = null)
        {
            string input = ReadString(label, @default?.ToString() ?? "");
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

        public static int ReadInt(string label, int @default = 0)
        {
            string input = ReadString(label, @default.ToString());

            int result;
            //tryParse - próbuje przekonwertować string na int, jeśli się nie uda, to nie rzuca wyjątku, tylko zwraca false
            //rezultat konwersji jest zwracany przez parametr oznaczony jako out
            //out - oznacza, że parametr jest przekazywany przez referencję i może być modyfikowany w funkcji
            bool success = int.TryParse(input, out result);

            if (success)
                return result;

            Console.WriteLine("Invalid number format");
            return ReadInt(label);
        }

        protected float ReadFloat(string label, float @default = 0)
        {
            string input = ReadString(label, @default.ToString());
            float result;
            if (!TryReadFloat(input, out result))
            {
                return ReadFloat(label, @default);
            }
            return result;
        }

        //własna implementacja TryPattern - pozwala na obsługę wyjątków w bardziej elegancki sposób
        //zgodnie ze wzorcem funkcja zwraca bool, a wynik konwersji jest zwracany przez parametr out
        bool TryReadFloat(string input, out float result)
        {
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
    }
}
