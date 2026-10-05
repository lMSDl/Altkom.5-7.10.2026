namespace Vectors.Models
{
    internal partial class Vector2D
    {
        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
        }

        public double GetLength()
        {
            return Math.Sqrt(X * X + Y * Y);
        }
    }
}
