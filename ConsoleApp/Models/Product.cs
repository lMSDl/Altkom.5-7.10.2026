
//namespace - przestrzeń nazw, czyli "adres" pod którym "mieszka" klasa
//namespace zaciągamy używając "using"
namespace ConsoleApp.Models;


//klasa Product - klasa, która reprezentuje produkt
//class - szablon opisujący zachowania i cechy obiektu (instancji klasy), które są tworzone na jej podstawie
//pełna nazwa klasy to <namespace>.<nazwa>
//internal - modyfikator dostępu - oznacza, że z klasy można korzystać tylko w obrębie tego samego zestawu (assembly), czyli w tym samym projekcie.
//  Klasa oznaczona jako internal nie będzie dostępna dla innych projektów, nawet jeśli są one częścią tej samej solucji.
//  Jest to przydatne, gdy chcemy ukryć implementację klasy przed innymi projektami, ale nadal chcemy mieć możliwość korzystania z niej wewnątrz naszego projektu.
//public - modyfikator dostępu - oznacza, że z klasy można korzystać z dowolnego miejsca w kodzie, zarówno wewnątrz tego samego projektu, jak i w innych projektach, które odwołują się do tego projektu.
//  Klasa oznaczona jako public jest dostępna dla wszystkich innych klas i projektów, co pozwala na szerokie udostępnianie jej funkcjonalności.
//  Jest to przydatne, gdy chcemy, aby klasa była dostępna dla innych części naszego kodu lub dla innych projektów, które mogą korzystać z jej funkcji.
//brak modyfikatora = najniższy dostępny - w przypadku class to internal
internal class Product
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

    //pole - zmienna, która przechowuje wartość
    //private - modyfikator dostępu - oznacza, że z pola można korzystać tylko wewnątrz tej samej klasy.
    //  Pole oznaczone jako private nie będzie dostępne dla innych klas, nawet jeśli są one częścią tego samego projektu.
    //  Jest to przydatne, gdy chcemy ukryć implementację pola przed innymi klasami, ale nadal chcemy mieć możliwość korzystania z niego wewnątrz naszej klasy.
    //inne możliwe modyfikatory: public, internal, protected
    //pola zazwyczaj są prywatne ze względu na hermetyzację, a dostęp realizowany jest przez metody getter i setter
    //nazwa pola zaczyna się od podkreślnika, żeby zaznaczyć, że jest to pole prywatne (konwencja c#)
    private DateTime _productionDate;

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

    //Property - właściwości

    //auto-property
    //integruje w sobie pole + metody dostępowe
    public string Name { get; set; }
    //jest możliwoć zmiany modyfikatora dla getter i setter
    public int Id { get; internal set; }

    //full-property
    private DateTime _expirationDate; //backing field - pole, które przechowuje wartość właściwości
    public DateTime ExpirationDate
    {
        //getter dla property
        get => _expirationDate; //zapis skrócony dla: get { return _expirationDate; }
        //setter dla property - nie ma jawnego parametru. Wartość, którą chcemy przypisać do property, jest dostępna przez słowo kluczowe value
        set
        {
            _expirationDate = value.Date;
        }
    }

    //od .net 10 można używać skróconej składni dla full-property, która pozwala na zdefiniowanie property bez konieczności tworzenia osobnego pola.
    //W takim przypadku kompilator automatycznie generuje pole, które jest używane do przechowywania wartości property.
    //Dzięki temu kod staje się bardziej zwięzły i czytelny, zwłaszcza gdy nie potrzebujemy dodatkowej logiki w getterze lub setterze.
    public string Description { get => field; set => field = value; }

    //read-only property - property, które ma tylko getter, co oznacza, że jego wartość można ustawić tylko w konstruktorze lub podczas deklaracji
    //albo gdy chcemy generować wartość na podstawie innych pól lub właściwości w runtime.
    public string FullInfo
    {
        get
        {
            //return "Id: " + Id + ", Name: " + Name + ", Production Date: " + _productionDate + ", Expiration Date: " + _expirationDate + ", Description: " + Description;
            //return string.Format("Id: {0}, Name: {1}, Production Date: {3}, Expiration Date: {2}, Description: {4}", Id, Name, _expirationDate, _productionDate, Description);
            //interpolacja stringów - pozwala na wstawianie wartości zmiennych bezpośrednio do stringa, co poprawia czytelność kodu i ułatwia jego pisanie. Aby użyć interpolacji stringów, należy poprzedzić string literą 'f' lub '$', a następnie umieścić zmienne wewnątrz nawiasów klamrowych {} w miejscu, gdzie chcemy je wstawić do stringa.
            return $"Id: {Id}, Name: \"{Name}\", {{Production Date: {_productionDate}, Expiration Date: {_expirationDate}}}, Description: {Description}";
        }
    }
    //skrócona wersja gettera: =>
    public string FullInfo2 => $"Id: {Id}, Name: \"{Name}\", Price: {Price}, {{Production Date: {_productionDate}, Expiration Date: {_expirationDate}}}, Description: {Description}";

    public float Price { get; set; }

    //przeciążenie operatora + - pozwala na dodawanie dwóch obiektów klasy Product - w tym przypadku robiony jest zestaw z 2 produków
    //przeciążenie wymaga zdefiniowania metody statycznej, która przyjmuje dwa parametry (lewa i prawa strona operatora) oraz słowa kluczowego "operator"
    //możemy przeciążać operatory, które są zdefiniowane w C# (np. +, -, *, /, ==, !=, <, >, <=, >=)
    public static Product operator +(Product left, Product right)
    {
        Product result = new Product();
        result.Name = left.Name + " & " + right.Name;
        result.ExpirationDate = left.ExpirationDate < right.ExpirationDate ? left.ExpirationDate : right.ExpirationDate;

        return result;
    }

    public static Product operator +(Product left, float right)
    {
        left.Price += right;
        return left;
    }
    public static Product operator -(Product left, float right)
    {
        left.Price += right;
        return left;
    }

    //indexer - pozwala na dostęp do obiektu klasy jak do tablicy lub słownika
    //możemy dodać też setter, żeby móc ustawiać wartości w klasie
    public string this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return Id.ToString();
                case 1: return Name;
                case 2: return Price.ToString();
                case 3: return _productionDate.ToString();
                case 4: return _expirationDate.ToString();
                case 5: return Description;
                default: throw new IndexOutOfRangeException();
            }
        }

        set
        {
            switch (index)
            {
                case 0: Id = int.Parse(value); break;
                case 1: Name = value; break;
                case 2: Price = float.Parse(value); break;
                case 3: _productionDate = DateTime.Parse(value); break;
                case 4: _expirationDate = DateTime.Parse(value); break;
                case 5: Description = value; break;
                default: throw new IndexOutOfRangeException();
            }
        }
    }

    public string this[string index]
    {
        get
        {
            //switch expression - pozwala na bardziej zwięzłe zapisywanie switcha
            return index.ToLower() switch //przyrównanie do małych liter, żeby nie było problemu z wielkością liter w nazwach indeksów
            {
                "id" => Id.ToString(),
                "name" => Name,
                "price" => Price.ToString(),
                "productiondate" => _productionDate.ToString(),
                "expirationdate" => _expirationDate.ToString(),
                "description" => Description,
                _ => throw new IndexOutOfRangeException(),
            };
        }
    }
}
