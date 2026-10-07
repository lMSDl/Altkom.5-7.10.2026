using Models;
using System.Linq;

namespace Delegates
{

    //LINQ - language integrated query - to zestaw metod rozszerzających, które umożliwiają wykonywanie zapytań do różnych źródeł danych, takich jak kolekcje, bazy danych, XML itp.
    //LINQ pozwala na pisanie zapytań w sposób deklaratywny, co oznacza, że opisujemy, co chcemy osiągnąć, a nie jak to zrobić.
    //LINQ jest zintegrowany z językiem C#, co pozwala na korzystanie z jego funkcji bez konieczności używania dodatkowych bibliotek czy składni.
    //LINQ bazuje na zestawie metod rozszerzających, które są dostępne dla różnych typów kolekcji, takich jak IEnumerable<T> i IQueryable<T>.
    //Te metody rozszerzające umożliwiają wykonywanie różnych operacji na kolekcjach, takich jak filtrowanie, sortowanie, grupowanie, agregowanie itp.
    //LINQ jest bardzo potężnym narzędziem do pracy z danymi i pozwala na pisanie czytelnych i efektywnych zapytań.
    internal class LinqExamples
    {

        int[] randomNumbers = new int[] { 1, 2, 6, 9, 3, 4, 5, 7, 8, 10 };

        IEnumerable<Product> products = [
            new Product { Id = 1, Name = "kasza", Price = 10.32f },
            new Product { Id = 2, Name = "mleko", Price = 5.99f },
            new Product { Id = 3, Name = "chleb", Price = 3.49f },
            new Product { Id = 4, Name = "jajka", Price = 12.99f },
            new Product { Id = 5, Name = "ser", Price = 15.49f },
            new Product { Id = 6, Name = "masło", Price = 8.99f },
            new Product { Id = 7, Name = "woda", Price = 2.99f },
            new Product { Id = 8, Name = "sok", Price = 6.49f },
            new Product { Id = 9, Name = "cukier", Price = 4.99f },
            new Product { Id = 10, Name = "sól", Price = 1.99f }
            ];

        IEnumerable<string> strings = "ala ma kota i dwa psy".Split();


        public void Test()
        {
            //where - metoda rozszerzająca, która filtruje elementy kolekcji na podstawie określonego warunku.
            //Przyjmuje jako argument predykat, czyli funkcję, która zwraca wartość boolowską, określającą czy dany element spełnia warunek.
            //Metoda Where zwraca nową kolekcję zawierającą tylko te elementy, które spełniają warunek określony przez predykat.
            var result1 = randomNumbers.Where(number => number > 4).ToArray(); //ToArray - zapytanie kończące - wykonuje zapytanie i zwraca wynik w postaci tablicy.
            var count1 = result1.Count();// zapytanie kończące - wykonuje zapytanie i zwraca wynik, w tym przypadku liczbę elementów spełniających warunek określony przez predykat.
            var result2 = randomNumbers.Where(number => number > 4).OrderBy(x => x).ToArray(); //OrderBy - metoda rozszerzająca, która sortuje elementy kolekcji w kolejności rosnącej na podstawie określonego klucza.

            /*List<int> result = [];
            foreach (var number in randomNumbers)
            {
                if(number > 4)
                {
                    bool added = false;
                    for (int i = 0; i < result.Count; i++)
                    {
                        if (result[i] > number)
                        {
                            result.Insert(i, number);
                            added = true;
                            break;
                        }
                    }
                    if (!added)
                        result.Add(number);
                }
            }*/

            //czasem lepiej nie kończyć zapytania od razu, ponieważ możemy chcieć wykonać dodatkowe operacje na kolekcji, takie jak sortowanie, grupowanie czy agregowanie.
            //W takim przypadku, możemy pozostawić zapytanie otwarte i wykonać je dopiero wtedy, gdy jest potrzebne.
            //Na przykład, jeśli chcemy posortować elementy spełniające warunek określony przez predykat, możemy użyć metody OrderBy() bezpośrednio po metodzie Where(), a następnie wykonać zapytanie dopiero wtedy, gdy jest potrzebne, np. podczas iteracji po kolekcji lub wywołania metody agregującej.
            foreach (var i in randomNumbers.Where(x => { Console.WriteLine("!"); return x % 2 == 0; }))
                Console.WriteLine(i);

            //to zapytanie będzie iterować dwa razy i dodatkowo zarezerwuje pamięć na kolekcję zawierającą tylko elementy spełniające warunek określony przez predykat, co może być nieefektywne, zwłaszcza jeśli kolekcja jest duża.
            //Aby uniknąć tego problemu, możemy użyć metody ToArray() lub ToList() bezpośrednio po metodzie Where(), co spowoduje wykonanie zapytania i utworzenie nowej kolekcji zawierającej tylko elementy spełniające warunek określony przez predykat.
            //W ten sposób, zapytanie będzie iterować tylko raz, a dodatkowo zarezerwuje pamięć tylko na kolekcję zawierającą elementy spełniające warunek określony przez predykat.
            foreach (var i in randomNumbers.Where(x => { Console.WriteLine("#"); return x % 2 == 0; }).ToArray())
                Console.WriteLine(i);

            //to zapytanie będzie iterować tylko raz, a dodatkowo zarezerwuje pamięć tylko na kolekcję zawierającą elementy spełniające warunek określony przez predykat.
            //jeśli pominiemy ToArray(), to zapytanie będzie iterować za każdym użyciem query
            var query = randomNumbers.Where(x => { Console.WriteLine("@"); return x % 2 == 0; }).ToArray();
            foreach (var i in query)
                Console.WriteLine(i);
            foreach (var i in query)
                Console.WriteLine(i);
            foreach (var i in query)
                Console.WriteLine(i);

            //możemy łączyć wiele metod rozszerzających, takich jak Where(), OrderBy(), GroupBy() itp., aby tworzyć bardziej złożone zapytania. Na przykład, możemy użyć metody Where() do filtrowania elementów kolekcji na podstawie określonego warunku, a następnie użyć metody OrderBy() do sortowania tych elementów według określonej właściwości. Możemy również użyć metody GroupBy() do grupowania elementów kolekcji na podstawie określonej właściwości, a następnie użyć metody Select() do projekcji tych grup na nowy typ danych. Możliwości są niemal nieograniczone, a LINQ pozwala na tworzenie bardzo złożonych zapytań w sposób deklaratywny i czytelny.
            var result3 = randomNumbers.Where(x => x > 2).Where(x => x <= 6).ToArray();
            //łączenie Where działa jak AND
            var result4 = randomNumbers.Where(x => x > 2 && x <= 6).ToArray(); //to samo co wyżej, ale w jednej metodzie Where
            //OR musi być w jednym Where, ponieważ jeśli rozdzielimy je na dwa Where, to będzie działać jak AND, a nie OR
            var result5 = randomNumbers.Where(x => x <= 2 || x > 6).ToArray();

            //możemy tworzyć tak zwane method chains, czyli łańcuchy metod, które pozwalają na tworzenie bardziej złożonych zapytań w sposób deklaratywny i czytelny. Method chains polegają na łączeniu wielu metod rozszerzających, takich jak Where(), OrderBy(), GroupBy() itp., w jednym wyrażeniu, co pozwala na tworzenie bardzo złożonych zapytań w sposób deklaratywny i czytelny. Na przykład, możemy użyć metody Where() do filtrowania elementów kolekcji na podstawie określonego warunku, a następnie użyć metody OrderBy() do sortowania tych elementów według określonej właściwości, a następnie użyć metody GroupBy() do grupowania tych elementów na podstawie określonej właściwości, a następnie użyć metody Select() do projekcji tych grup na nowy typ danych. Możliwości są niemal nieograniczone, a LINQ pozwala na tworzenie bardzo złożonych zapytań w sposób deklaratywny i czytelny.
            var result6 = randomNumbers.Where(x => x <= 2 || x > 6)
                                        .OrderBy(x => x) //sortowanie rosnące
                                        .ToArray();
            var result7 = randomNumbers.Where(x => x <= 2 || x > 6)
                                        .OrderByDescending(x => x) //sortowanie malejące
                                        .ToArray();

            //zapytania agregujące - to zapytania, które wykonują operacje agregujące na kolekcji, takie jak sumowanie, średnia, min, max itp. Metody agregujące są metodami rozszerzającymi, które są dostępne dla różnych typów kolekcji, takich jak IEnumerable<T> i IQueryable<T>. Te metody umożliwiają wykonywanie różnych operacji agregujących na kolekcjach, takich jak sumowanie, średnia, min, max itp. Na przykład, możemy użyć metody Sum() do sumowania wartości w kolekcji, metody Average() do obliczania średniej wartości w kolekcji, metody Min() do znajdowania minimalnej wartości w kolekcji, metody Max() do znajdowania maksymalnej wartości w kolekcji itp. Zapytania agregujące są bardzo przydatne do wykonywania różnych operacji na danych i pozwalają na pisanie czytelnych i efektywnych zapytań.
            var averagePrice = products.Average(p => p.Price);
            var sumPrice = products.Where(x => x.Name.Length == 3).Sum(p => p.Price);

            //grupowanie - to zapytania, które grupują elementy kolekcji na podstawie określonej właściwości. Metoda GroupBy() jest metodą rozszerzającą, która jest dostępna dla różnych typów kolekcji, takich jak IEnumerable<T> i IQueryable<T>. Ta metoda umożliwia grupowanie elementów kolekcji na podstawie określonej właściwości, a następnie pozwala na wykonywanie różnych operacji na tych grupach, takich jak sortowanie, agregowanie itp. Na przykład, możemy użyć metody GroupBy() do grupowania elementów kolekcji na podstawie określonej właściwości, a następnie użyć metody Select() do projekcji tych grup na nowy typ danych. Możliwości są niemal nieograniczone, a LINQ pozwala na tworzenie bardzo złożonych zapytań w sposób deklaratywny i czytelny.
            var productGroups = products.GroupBy(x => x.Price > 10).ToArray();

            //zapytania kończące
            //first - metoda rozszerzająca, która zwraca pierwszy element kolekcji, który spełnia określony warunek. Przyjmuje jako argument predykat, czyli funkcję, która zwraca wartość boolowską, określającą, czy dany element spełnia warunek. Metoda First() zwraca pierwszy element kolekcji, który spełnia warunek określony przez predykat. Jeśli żaden element nie spełnia warunku, metoda First() zgłasza wyjątek InvalidOperationException.
            var first = products.First(x => x.Price > 10);
            //firstOrDefault - metoda rozszerzająca, która zwraca pierwszy element kolekcji, który spełnia określony warunek, lub domyślną wartość typu, jeśli żaden element nie spełnia warunku. Przyjmuje jako argument predykat, czyli funkcję, która zwraca wartość boolowską, określającą, czy dany element spełnia warunek. Metoda FirstOrDefault() zwraca pierwszy element kolekcji, który spełnia warunek określony przez predykat. Jeśli żaden element nie spełnia warunku, metoda FirstOrDefault() zwraca domyślną wartość typu, czyli null dla typów referencyjnych i 0 dla typów wartościowych.
            var firstOrDefault = products.FirstOrDefault(x => x.Price > 20);
            //single - metoda rozszerzająca, która zwraca jedyny element kolekcji, który spełnia określony warunek. Przyjmuje jako argument predykat, czyli funkcję, która zwraca wartość boolowską, określającą, czy dany element spełnia warunek. Metoda Single() zwraca jedyny element kolekcji, który spełnia warunek określony przez predykat. Jeśli żaden element nie spełnia warunku lub jeśli więcej niż jeden element spełnia warunek, metoda Single() zgłasza wyjątek InvalidOperationException.
            var single = products.Single(x => x.Id == 1);
            //singleOrDefault - metoda rozszerzająca, która zwraca jedyny element kolekcji, który spełnia określony warunek, lub domyślną wartość typu, jeśli żaden element nie spełnia warunku. Przyjmuje jako argument predykat, czyli funkcję, która zwraca wartość boolowską, określającą, czy dany element spełnia warunek. Metoda SingleOrDefault() zwraca jedyny element kolekcji, który spełnia warunek określony przez predykat. Jeśli żaden element nie spełnia warunku, metoda SingleOrDefault() zwraca domyślną wartość typu, czyli null dla typów referencyjnych i 0 dla typów wartościowych. Jeśli więcej niż jeden element spełnia warunek, metoda SingleOrDefault() zgłasza wyjątek InvalidOperationException.
            var singleOrDefault = products.SingleOrDefault(x => x.Id == 100);
            //last - metoda rozszerzająca, która zwraca ostatni element kolekcji, który spełnia określony warunek. Przyjmuje jako argument predykat, czyli funkcję, która zwraca wartość boolowską, określającą, czy dany element spełnia warunek. Metoda Last() zwraca ostatni element kolekcji, który spełnia warunek określony przez predykat. Jeśli żaden element nie spełnia warunku, metoda Last() zgłasza wyjątek InvalidOperationException.
            var last = products.Last(x => x.Price > 10);
            //lastOrDefault - metoda rozszerzająca, która zwraca ostatni element kolekcji, który spełnia określony warunek, lub domyślną wartość typu, jeśli żaden element nie spełnia warunku. Przyjmuje jako argument predykat, czyli funkcję, która zwraca wartość boolowską, określającą, czy dany element spełnia warunek. Metoda LastOrDefault() zwraca ostatni element kolekcji, który spełnia warunek określony przez predykat. Jeśli żaden element nie spełnia warunku, metoda LastOrDefault() zwraca domyślną wartość typu, czyli null dla typów referencyjnych i 0 dla typów wartościowych.
            var lastOrDefault = products.LastOrDefault(x => x.Price > 20);

            //budowa złożonego zapytania - to zapytanie, które łączy wiele metod rozszerzających, takich jak Where(), Skip(), Take(), Select(), Aggregate() itp., aby tworzyć bardziej złożone zapytania. Na przykład, możemy użyć metody Where() do filtrowania elementów kolekcji na podstawie określonego warunku, a następnie użyć metody Skip() do pominięcia określonej liczby elementów, a następnie użyć metody Take() do pobrania określonej liczby elementów, a następnie użyć metody Select() do projekcji tych elementów na nowy typ danych, a następnie użyć metody Aggregate() do agregowania tych elementów w jeden wynik. Możliwości są niemal nieograniczone, a LINQ pozwala na tworzenie bardzo złożonych zapytań w sposób deklaratywny i czytelny.
            var result8 = products.Where(x => x.Price > products.Average(xx => xx.Price) / 2)
                .Skip(2) //pomiń pierwsze 2 elementy spełniające warunek określony przez predykat
                .Take(3) //ogranicz do 3 elementów spełniających warunek określony przez predykat
                //.ToArray();
                //.Aggregate("", (acc, item) => $"{acc}, {item.Name}");
                //Select - zmiana kontekstu z Product na string, dzięki czemu w Aggregate mamy już do dyspozycji tylko nazwy produktów, a nie całe obiekty Product
                .Select(x => x.Name) //zmiana kontekstu z Product na string, dzięki czemu w Aggregate mamy już do dyspozycji tylko nazwy produktów, a nie całe obiekty Product
                .Aggregate((acc, item) => $"{acc}, {item}");

            Console.ReadLine();
        }
    }
}
