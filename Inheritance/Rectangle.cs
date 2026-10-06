namespace Inheritance
{
    internal class Rectangle : Shape2D
    {
        public Rectangle(int width, int height) : base("Rectangle", width, height)
        {
        }

        public override double GetArea()
        {
            return Width * Height;
        }
    }
}
