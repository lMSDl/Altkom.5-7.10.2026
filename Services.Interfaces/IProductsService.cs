using Models;

namespace Services.Interfaces
{
    //interface - umowa, którą musi spełnić każda klasa, która ją implementuje.
    //Określa zestaw metod i/lub właściwości, które muszą być zaimplementowane przez klasę, ale nie zawiera implementacji tych metod.
    //Interfejsy są używane do definiowania kontraktów, które klasy muszą spełniać, co pozwala na tworzenie elastycznych i modularnych aplikacji.
    //konwencja nazewnictwa - nazwy interfejsów zaczynają się od litery "I", co pozwala na łatwe rozróżnienie ich od klas.
    public interface IProductsService
    {
        void Create(Product entity);
        Product? Read(int id);
        //IEnumerable - interfejs reprezentujący kolekcję, która może być enumerowana, czyli można ją przeglądać element po elemencie.
        //  Jest to bardziej ogólny typ niż List<T>, który jest konkretną implementacją kolekcji.
        //  IEnumerable<T> pozwala na implementowanie różnych typów kolekcji, takich jak listy, tablice, zbiory itp., które mogą być przeglądane w sposób sekwencyjny.
        //IEnumerable<T> - interfejs generyczny, który reprezentuje kolekcję elementów typu T, które można przeglądać w sposób sekwencyjny.
        //  Oznacza to, że można używać pętli foreach do iterowania po elementach tej kolekcji.
        //  IEnumerable<T> jest często używany jako typ zwracany przez metody, które zwracają kolekcje danych, ponieważ pozwala na elastyczność w wyborze konkretnej implementacji kolekcji.
        IEnumerable<Product> ReadAll();
        bool Update(int id, Product entity);
        bool Delete(int id);
    }
}
