namespace Inheritance
{
    internal class Circle : Shape2D
    {
        public int Radius { get; }
        public Circle(int radius) : base("Circle", 2*radius, 2*radius)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        override public string ToString()
        {
            return $"{GetName()} o promieniu {Radius}";
        }
    }
}
