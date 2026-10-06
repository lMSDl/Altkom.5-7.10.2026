namespace Inheritance
{
    internal abstract class Shape2D : Shape1D
    {
        public int Height { get; set; }

        public Shape2D(string name, int width, int height) : base(name, width)
        {
            Height = height;
        }

        override public string GetName()
        {
            return _name.ToUpper();
        }

        override public string ToString()
        {
            //base - odnosi się do klasy bazowej, pozwala na dostęp do jej metod i właściwości.
            //W tym przypadku wywołujemy metodę ToString() z klasy Shape1D, która zwraca nazwę kształtu i jego szerokość.
            //Następnie modyfikujemy ten string, aby dodać informację o wysokości.
            return $"{base.ToString()} i wysokości {Height}";
        }

        //metoda abstrakcyjna, która musi być zaimplementowana w klasach pochodnych, ponieważ nie można obliczyć pola powierzchni bez znajomości konkretnego kształtu
        //może występować tylko w klasie abstrakcyjnej, ponieważ klasa abstrakcyjna nie może być instancjonowana, więc nie ma ryzyka, że ktoś zapomni zaimplementować tę metodę
        public abstract double GetArea();
    }
}
