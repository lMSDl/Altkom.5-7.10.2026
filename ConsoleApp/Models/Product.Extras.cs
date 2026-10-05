
namespace ConsoleApp.Models;

//partial - słowo kluczowe, które pozwala na podzielenie definicji klasy na wiele plików
//partial class - klasa, która jest podzielona na wiele plików
//wymagania: wszystkie pliki muszą być w tym samym projekcie, w tej samej przestrzeni nazw i mieć taką samą nazwę klasy
internal partial class Product
{

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
