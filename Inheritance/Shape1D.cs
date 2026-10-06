namespace Inheritance
{
    internal abstract class Shape1D : Shape
    {
        public int Width { get; set; }

        //base(..) - pozwala na wywołanie konstruktora klasy bazowej z określonymi argumentami. W tym przypadku przekazujemy nazwę kształtu do konstruktora klasy Shape, który przypisuje ją do pola _name.
        public Shape1D(string name, int width) : base(name)
        {
            Width = width;
        }

        override public string ToString()
        {
            return $"{base.ToString()} o długości {Width}";
        }
    }
}
