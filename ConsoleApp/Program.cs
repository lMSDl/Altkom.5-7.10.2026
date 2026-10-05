

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
using ConsoleApp;
using ConsoleApp.Models;

Console.WriteLine(typeof(Product).Name);
Console.WriteLine(typeof(Product).Namespace);
Console.WriteLine(typeof(Product).FullName);

/*Introduction introduction = new Introduction();
introduction.Run();*/
Introduction.Run();

//wytworzenie obiektu klasy Product - instancja klasy Product
Product product = new Product();

product.Name = "Laptop";
product.Description = "Laptop popsuty z procesorem Intel i7";
product.SetProductionDate(new DateTime(2023, 1, 1));
product.ExpirationDate = new DateTime(2025, 1, 1);

Console.WriteLine(product.FullInfo);

product.Description = "Laptop naprawiony z procesorem Intel i9";

Console.WriteLine(product.FullInfo);

Product product1 = new Product();
Product product2 = new Product("Smartphone");

Console.WriteLine(product1.FullInfo);
Console.WriteLine(product2.FullInfo);

Product product3 = new Product("Tablet", new DateTime(2030, 1, 1));


//inicjalizator obiektów - pozwala na przypisanie wartości do właściwości obiektu w momencie jego tworzenia, bez konieczności wywoływania konstruktora z parametrami.
//Inicjalizator obiektów jest szczególnie przydatny, gdy chcemy szybko utworzyć obiekt i przypisać mu wartości właściwości, co poprawia czytelność kodu i zmniejsza ilość kodu potrzebnego do inicjalizacji obiektu.
//Inicjalizator obiektów ""uruchamiamy" za pomocą nawiasów klamrowych {} po wywołaniu konstruktora.
Product prodcut4 = new Product() { Id = 4, Name = "Monitor", Description = "Monitor 4K" };
Product product5 = new Product("Tablet", new DateTime(2030, 1, 1)) { Description = "Tablet 4K" };
