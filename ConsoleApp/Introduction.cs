using ConsoleApp.Models;

namespace ConsoleApp
{
    //klasa statyczna - klasa, która nie może zostać zainicjalizowana, czyli nie można tworzyć obiektów tej klasy.
    //Wszystkie członkowie klasy statycznej muszą być również statyczni (metody, pola, właściwości itp.).
    //Klasy statyczne są często używane do grupowania metod pomocniczych lub funkcji, które nie wymagają stanu (danych instancji) i mogą być wywoływane bez konieczności tworzenia obiektu.
    //Aby zdefiniować klasę statyczną, należy użyć słowa kluczowego sta tic przed deklaracją klasy (np. public static class ClassName).
    internal static class Introduction
    {
        //metoda statyczna - metoda, która może być wywołana bez tworzania instancji klasy.
        //Metody statyczne są związane z klasą, a nie z konkretnym obiektem, co oznacza, że można je wywołać bez konieczności tworzenia obiektu tej klasy.
        //Metody statyczne są często używane do definiowania funkcji pomocniczych lub operacji, które nie wymagają dostępu do danych instancji klasy.
        //Aby wywołać metodę statyczną, należy użyć nazwy klasy, a następnie operatora kropki i nazwy metody (np. ClassName.MethodName()).
        //Metoda statyczna może występować w klasie niestatycznej.
        static public void Run()
        {
            Console.WriteLine("Hello, World!");

            //flaga Nullable w pliku csproj - pozwala na włączenie lub wyłączenie obsługi typów nullable w całym projekcie. Gdy flaga Nullable jest ustawiona na enable, kompilator traktuje wszystkie typy referencyjne jako nullable, co oznacza, że mogą one przyjmować wartość null. W takim przypadku, jeśli próbujemy przypisać null do typu referencyjnego, kompilator wygeneruje ostrzeżenie lub błąd, w zależności od ustawień projektu. Flaga Nullable jest szczególnie przydatna w celu poprawy bezpieczeństwa kodu i unikania błędów związanych z null reference exceptions.

            int a = 5;
            int? b = null; //nullable type używając shorthand syntax
                           //Nullable - opakowanie typów wartościowych, które pozwala na przypisanie im wartości null. Dzięki temu można reprezentować brak wartości lub nieznaną wartość dla typów takich jak int, double, bool itp. Nullable jest szczególnie przydatny w sytuacjach, gdy chcemy mieć możliwość oznaczenia, że dana wartość jest nieokreślona lub nieistniejąca, co jest niemożliwe do osiągnięcia za pomocą zwykłych typów wartościowych, które zawsze muszą mieć przypisaną wartość.
                           //Nullable jest implementowany jako struktura generyczna System.Nullable<T>, gdzie T jest typem wartościowym.
            Nullable<int> c = null;

            Product product1 = new Product
            {
                //Id = 1,
                Name = "Laptop"
            };
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
        }
    }
}
