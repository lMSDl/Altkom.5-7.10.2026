using Models;
using Services.InMemory;
using Services.Interfaces;

namespace ItemsManager
{
    internal abstract class EntityManager
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

        }

        void Edit()
        {
            int id = ReadInt("Id");
            Entity? entity = _service.Read(id);
            if (entity == null)
            {
                Console.WriteLine("Id not found");
                return;
            }

            Entity newEntity = CreateEntity();

            newEntity.Name = ReadString($"Name ({entity.Name})", entity.Name);
            ExtraEdit(entity, newEntity);

            _service.Update(id, newEntity);
        }
        protected abstract void ExtraEdit(Entity current, Entity edited);

        void Create()
        {
            Entity entity = CreateEntity();

            entity.Name = ReadString("Name");
            ExtraCreate(entity);

            _service.Create(entity);
        }

        protected abstract Entity CreateEntity();
        protected abstract void ExtraCreate(Entity entity);


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
        string ReadString(string label, string @default = "")
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

        int ReadInt(string label)
        {
            string input = ReadString(label);

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
