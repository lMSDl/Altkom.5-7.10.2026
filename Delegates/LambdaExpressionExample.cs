namespace Delegates
{
    internal class LambdaExpressionExample
    {
        Func<int, int, int> Calculator { get; set; }
        Func<string> SomeFunc { get; set; }
        Action<int> SomeAction { get; set; }
        Action AnotherAction { get; set; }

        //wyrażenie lambda - to skrót do delegata, który pozwala na tworzenie anonimowych funkcji, które mogą być przypisane do delegatów lub wywoływane bezpośrednio.
        //Składnia wyrażenia lambda jest następująca: (parametry) => { ciało funkcji }.
        //Wyrażenia lambda są często używane w LINQ i innych kontekstach, gdzie potrzebujemy przekazać funkcję jako argument do innej metody.
        //<opcjonalny parametr> <operator> <ciało>
        //(a, b) => {}
        public void Test()
        {
            Calculator = Calc;

            Console.WriteLine(Calculator(3, 4));

            //przypisanie metody anonimej do delegata - metoda anonimowa to funkcja, która nie ma nazwy i jest definiowana bezpośrednio w miejscu, gdzie jest używana.
            //Można ją przypisać do delegata lub wywołać bezpośrednio.
            //Składnia metody anonimowej jest następująca: delegate (parametry) { ciało funkcji }.
            //Metody anonimowe są często używane w kontekstach, gdzie potrzebujemy przekazać funkcję jako argument do innej metody, ale nie chcemy definiować osobnej metody o nazwie.
            Calculator = delegate (int a, int b) { return a - b; };
            Calculator = (int a, int b) => { return a - b; };
            Calculator = (a, b) => { return a - b; };
            //najprostsza forma - jeśli ciało funkcji składa się z jednej instrukcji:
            //  typ parametru można pominąć, a kompilator sam go wywnioskuje z kontekstu (z deklaracji delegata).
            //  nawiasy klamrowe i słowo kluczowe return można pominąć gdy ciało funkcji składa się z jednej instrukcji - wynik tej instrukcji zostanie automatycznie zwrócony jako wynik wyrażenia lambda.
            Calculator = (a, b) => a - b;
            Console.WriteLine(Calculator(3, 4));

            SomeFunc = delegate () { return "Hello from anonymous method"; };
            SomeFunc = () => { return "Hello from lambda expression"; };
            SomeFunc = () => "Hello from lambda expression";

            SomeAction = delegate (int a) { Console.WriteLine($"Hello from anonymous method with parameter {a}"); };
            SomeAction = (int a) => { Console.WriteLine($"Hello from lambda expression with parameter {a}"); };
            SomeAction = (a) => { Console.WriteLine($"Hello from lambda expression with parameter {a}"); };
            //jeśli jest jeden parametr, można pominąć nawiasy wokół parametru
            SomeAction = a => Console.WriteLine($"Hello from lambda expression with parameter {a}");

            AnotherAction = delegate () { Console.WriteLine("Hello from anonymous method without parameters"); };
            AnotherAction = () => { Console.WriteLine("Hello from lambda expression without parameters"); };
            AnotherAction = () => Console.WriteLine("Hello from lambda expression without parameters");
        }



        int Calc(int a, int b)
        {
            return a + b;
        }
    }
}
