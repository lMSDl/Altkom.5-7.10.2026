using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates
{
    //Delegaty to typy referencyjne, które reprezentują metody o określonym sygnaturze.
    //Delegaty pozwalają na przypisywanie metod do zmiennych i wywoływanie ich w sposób dynamiczny lub przekazywanie ich jako argumentów do innych metod.
    //Potocznie to wskaźniki na metody
    internal class DelegatesExample
    {
        delegate void VoidDelegateWithoutParameters();
        delegate void VoidDelegateWithParameters(string param);
        delegate bool BoolDelegateWithParameters(int int1, int int2);

        public void Func1()
        {
            Console.WriteLine("Func1");
        }
        public void Func2(string param)
        {
            Console.WriteLine(param);
        }

        public bool Func3(int int1, int int2)
        {
            return int1 == int2;
        }

        BoolDelegateWithParameters? Delegate3 { get; set; }

        public void Test()
        {
            VoidDelegateWithoutParameters? delegate1 = Func1;
            delegate1.Invoke(); // wywołanie metody Func1 za pomocą delegata
            delegate1(); // wywołanie metody Func1 za pomocą delegata (skrócona forma)

            delegate1 = null;

            if(delegate1 != null)
                delegate1();
            delegate1?.Invoke(); // ? - wywołanie warunkowe, jeśli delegate1 jest null to nie wywoła metody

            VoidDelegateWithParameters delegate2 = new VoidDelegateWithParameters(Func2);
            delegate2.Invoke("Func2"); // wywołanie metody Func2 za pomocą delegata

            Delegate3 = Func3;

            for(int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    bool result = Delegate3(i, j);
                    Console.WriteLine($"i: {i}, j: {j}, result: {result}");
                }
            }

            for (int i = 0; i < 5; i++)
            {
                Run(Func1);
                Console.ReadLine();
            }
        }

        //funkcja przyjmująca jako parametr delegat VoidWithoutParams, który reprezentuje metodę bez parametrów i bez wartości zwracanej
        private void Run(VoidDelegateWithoutParameters someFunction)
        {
            if(DateTime.Now.Second % 2 == 0)
            {
                someFunction();
            }
        }

    }
}
