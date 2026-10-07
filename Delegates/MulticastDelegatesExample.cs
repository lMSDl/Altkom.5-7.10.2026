using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Delegates
{
    internal class MulticastDelegatesExample
    {
        delegate void MulticastDelegate(string @string);

        void Message1(string @string) { Console.WriteLine("Message1: " + @string); }
        void Message2(string @string) { Console.WriteLine("Message2: " + @string); }
        void Message3(string @string) { Console.WriteLine("Message3: " + @string); }


        public void Test()
        {
            MulticastDelegate multicastDelegate = null;

            multicastDelegate = Message1;
            multicastDelegate.Invoke("Hello!");

            //= - przypisuje metodę do delegata (jeśli jest więcej niż jedna metoda, to zostaną zastąpione tą jedną)
            multicastDelegate = Message2;
            multicastDelegate.Invoke("Hello!");

            //+= - dodaje metodę do listy wywołań delegata
            multicastDelegate += Message3;
            multicastDelegate.Invoke("Hello again!");


            multicastDelegate += Message1;
            multicastDelegate.Invoke("Hello again again!");

            //przypisanie delegata do null - usunięcie wszystkich metod z listy wywołań delegata
            multicastDelegate = null;
            //mimo, że delegat jest null to możemy dodać przez += kolejne metody do listy wywołań delegata
            multicastDelegate += Message2;
            multicastDelegate += Message3;
            multicastDelegate.Invoke("Hello!");

            multicastDelegate -= Message2;
            multicastDelegate?.Invoke("Hello again!");

            multicastDelegate -= Message3;
            multicastDelegate?.Invoke("Hello again again!");

            multicastDelegate += Message1;
            multicastDelegate += Message2;
            multicastDelegate += Message3;
            multicastDelegate += Console.WriteLine;

            multicastDelegate?.Invoke("Hello again again again!");
        }
    }
}
