

//klasyczny szablon aplikacji konsolowej w C#
/*namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}*/

//nowy szablon aplikacji konsolowej w C#
//instrukcje najwyższego poziomu - top-level statements
//są to instrukcje, które można umieścić bezpośrednio w pliku, bez konieczności definiowania klasy i metody Main.
//Kompilator automatycznie generuje klasę i metodę Main, która jest punktem wejścia do programu.
//Dzięki temu kod staje się bardziej zwięzły i czytelny, zwłaszcza dla prostych programów.
//Wszystko co znajduje się w pliku z top-level statements jest otoczone metodą Main
using ConsoleApp.Models;

Console.WriteLine("Hello, World!");
alamakota();

void alamakota(){
    int a = 3;
    int b = 4;
}

//Nullable - typy wartościowe, które mogą przyjmować wartość null.
//Tworzy w pamięci parę: wartość i flagę, która informuje czy wartość jest ustawiona.
//Wartość null oznacza brak wartości. Nullable jest przydatny w sytuacjach, gdy chcemy reprezentować brak wartości dla typów wartościowych, takich jak int, double, bool itp.
//W C# można użyć Nullable<T> lub skróconej wersji T?, gdzie T jest typem wartościowym.
Nullable<int> a = null;
int? b = null; //skrócona wersja Nullable<int>

Product product1 = new Product
{
    Id = 1,
    Name = "Laptop"
};

a = 5;
ChangeInt(a.Value);
Console.WriteLine(a);

ChangeProduct(product1);



Product? product2 = null;
ChangeProduct(product2);


string str1 = "ala ma kota";
string str2 = null;

void ChangeProduct(Product? product)
{
    if (product != null)
    {
        product.Name = "Komputer";
    }
}

void ChangeInt(int number)
{
    number = 10;
}