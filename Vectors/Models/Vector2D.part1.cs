namespace Vectors.Models
{
    internal partial class Vector2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2D()
        {
            X = 0;
            Y = 0;
        }
        public Vector2D(int x, int y)
        {
            X = x;
            Y = y;
        }


        public string Show()
        {
            return $"X: {X}, Y: {Y}";
        }
    }
}
