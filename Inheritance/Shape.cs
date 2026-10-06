namespace Inheritance
{
    //dziedziczenie to mechanizm pozwalający na tworzenie nowych klas na podstawie już istniejących.
    //Nowa klasa (nazywana klasą pochodną) dziedziczy wszystkie (poza prywatnymi) właściwości i metody klasy bazowej, a także może dodawać nowe właściwości i metody lub nadpisywać istniejące.
    //: - oznacza dziedziczenie po wskazanej klasie (tylko jednej). Po niej może następować lista interfejsów, które klasa pochodna implementuje.
    //każda klasa w C# dziedziczy po klasie Object, która jest klasą bazową dla wszystkich klas w C#.
    //  Oznacza to, że każda klasa ma dostęp do metod zdefiniowanych w klasie Object, takich jak ToString(), Equals(), GetHashCode() i GetType().
    //abstract - oznacza, że klasa jest abstrakcyjna, co oznacza, że nie można tworzyć instancji tej klasy bezpośrednio.
    //  Klasa abstrakcyjna może zawierać zarówno metody abstrakcyjne (bez implementacji), jak i metody z implementacją.
    //  Klasy pochodne muszą nadpisać wszystkie metody abstrakcyjne z klasy bazowej, ale mogą również nadpisać metody z implementacją (virtual), jeśli chcą zmienić ich zachowanie.
    internal abstract class Shape /*: Object*/
    {
        //protected - oznacza, że pole jest dostępne tylko w klasie bazowej i klasach pochodnych, ale nie jest dostępne z zewnątrz tych klas.
        protected string _name;

        public Shape(string name)
        {
            _name = name;
        }

        //virtual - oznacza, że metoda może być nadpisana w klasach pochodnych. Klasa pochodna może użyć słowa kluczowego override, aby nadpisać implementację tej metody.
        public virtual string GetName()
        {
            return _name;
        }

        //override - oznacza, że metoda nadpisuje implementację metody z klasy bazowej.
        //Metoda w klasie pochodnej musi mieć tę samą sygnaturę (nazwa, typ zwracany i parametry) co metoda w klasie bazowej, którą nadpisuje.
        override public string ToString()
        {
            return GetName();
        }
    }
}
