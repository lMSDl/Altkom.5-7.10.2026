using Vectors.Models;

Vector2D vec1 = new Vector2D(3, 4);
Vector2D vec2 = new Vector2D() { X = 1, Y = 2 };

Vector2D sum = vec1 + vec2;
Console.WriteLine(vec1.Show());
Console.WriteLine(vec2.Show());
Console.WriteLine(sum.Show());

double length = sum.GetLength();
Console.WriteLine(length);