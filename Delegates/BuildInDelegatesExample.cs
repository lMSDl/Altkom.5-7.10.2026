using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Delegates
{
    internal class BuildInDelegatesExample
    {
        void Add(int a, float b)
        {
            Console.WriteLine(a + b);
        }

        bool SubstractAndCompare(int a, float b)
        {
            var result = a - b;
            Console.WriteLine(result);
            return a == b;
        }

        //delegate void Method1Delegate(int a, float b);
        //delegate bool Method2Delegate(int a, float b);
        //void Method(Method1Delegate method1, Method2Delegate method2)

        //Action - wbudowany delegat, który nie zwraca wartości i przyjmuje parametry generyczne
        //Func - wbudowany delegat, który zwraca wartość i przyjmuje parametry generyczne (ostatni parametr to typ zwracany)
        void Method(Action<int, float> method1, Func<int, float, bool> method2)
        {
            for(int i = 0; i < 5; i++)
            {
                for(float j = 0; j < 5; j++)
                {
                    method1(i, j);
                    if (method2(i, j))
                    {
                        Console.WriteLine("Equal");
                    }
                }
            }
        }

        public void Test()
        {
            Method(Add, SubstractAndCompare);
        }
    }
}
