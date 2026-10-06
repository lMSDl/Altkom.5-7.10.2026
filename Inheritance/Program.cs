

using Inheritance;

//nie możemy tworzyć obiektów klasy abstrakcyjnej, ponieważ mogą być one niekompletne.
//Shape shape = new Shape("MyShape");
//Shape1D shape1D = new Shape1D("MyShape1D", 10);
//Shape2D shape2D = new Shape2D("MyShape2D", 10, 20);


//Console.WriteLine(shape.ToString());
//Console.WriteLine(shape1D.ToString());
//Console.WriteLine(shape2D.ToString());


Line line = new Line(10);
Console.WriteLine(line.ToString());

Rectangle rectangle = new Rectangle(10, 20);
Console.WriteLine(rectangle.ToString());

Circle circle = new Circle(10);
Console.WriteLine(circle.ToString());
Console.WriteLine($"Radius: {circle.Radius}");

Shape shape = line;
Console.WriteLine(shape.ToString());

shape = rectangle;
Console.WriteLine(shape.ToString());

Shape1D shape1D = circle;
Console.WriteLine(shape1D.ToString());


IEnumerable<Shape> shapes = [line, rectangle, circle];

foreach (var s in shapes)
{
    Console.WriteLine(s.ToString());
}
