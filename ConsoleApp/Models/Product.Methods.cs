
namespace ConsoleApp.Models;

internal partial class Product
{
    //metoda konstrukcyjna (konstruktor) - bezparametrowy
    //konstruktor ustawia wszystkie pola na wartości domyślne (null dla typów referencyjnych, 0 dla typów numerycznych, false dla bool itp.) lub wartości wskazane przez programistę
    //konstuktory głównie wykorzystywane są w celu wstępnej konfiguracji obiektu
    //budowa: <modyfikator dostępu> <nazwa klasy>(<parametry>)
    //jeśli klasa nie ma żadnego konstruktora, kompilator automatycznie generuje konstruktor bezparametrowy, który ustawia wszystkie pola na wartości domyślne.
    //Jeśli klasa ma zdefiniowany konstruktor, kompilator nie generuje już konstruktora bezparametrowego, więc jeśli chcemy mieć możliwość tworzenia obiektów bez podawania argumentów, musimy jawnie zdefiniować konstruktor bezparametrowy.
    public Product()
    {
        _productionDate = DateTime.Now; //ustawienie wartości domyślnej dla pola _productionDate
    }

    //konstruktor parametrowy - pozwala na ustawienie wartości pól podczas tworzenia obiektu, co może być wygodne i czytelne, zwłaszcza gdy klasa ma wiele pól, które muszą być zainicjalizowane.
    //Konstruktor parametrowy umożliwia przekazanie wartości bezpośrednio do konstruktora, co może poprawić czytelność kodu i ułatwić tworzenie obiektów z określonymi wartościami.
    //przeciążenie metody konstrukcyjnej - możliwość zdefiniowania wielu konstruktorów, ale różniących się listą parametrów. Dzięki temu można tworzyć obiekty na różne sposoby, w zależności od potrzeb, co zwiększa elastyczność i użyteczność klasy.
    //: this() - odwołanie się do innego konstruktora tej samej klasy. W tym przypadku, konstruktor parametrowy wywołuje konstruktor bezparametrowy, co pozwala na wykonanie wspólnej logiki inicjalizacji (ustawienie daty produkcji) przed ustawieniem wartości pola Name.
    //  Dzięki temu można uniknąć duplikowania kodu i zapewnić spójność inicjalizacji obiektów. Tak zwany konstruktor teleskopowy
    public Product(string name) : this() //wywołanie konstruktora bezparametrowego, który ustawia wartość pola _productionDate
    {
        Name = name;
    }

    //jeśli w klasie występuje jakiś konstruktor parametrowy, to konstuktor bezparametrowy nie zostanie automatycznie wygenerowany
    //jeśli chcemy mieć dalej możliwość tworzenia obiektów bez podawania argumentów, musimy jawnie zdefiniować konstruktor bezparametrowy
    public Product(string name, DateTime expirationDate) : this(name)
    {
        ExpirationDate = expirationDate;
    }

    //getter - do pobierania wartości - metoda zwraca wartość pola lub "przetwarza" ją przed zwróceniem
    //budowa metody: <modyfikator dostępu> <typ zwracany> <nazwa>(<parametry>)
    public DateTime GetProductionDate()
    { 
        if(_productionDate == default) //przyrównanie do default a nie null, bo DateTime jest typem wartościowym i nie może być null
        {
            return DateTime.MinValue; //przykład "obróbki" danych przed zwróceniem - jeśli pole nie zostało ustawione, zwracamy minimalną wartość daty
        }
        //return - słowo kluczowe, które zwraca wartość z metody i kończy jej wykonywanie
        return _productionDate;
    }

    //setter - do ustawiania wartości - metoda przyjmuje parametr, który możemy przypisać do pola lub "obrobić"
    //void - metoda nic nie zwaraca
    internal void SetProductionDate(DateTime value)
    {
        _productionDate = value.Date; //przykład "obróbki" danych przed przypisaniem do pola - zapisujemy tylko datę, bez czasu
    }
}
