using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates
{
    internal class EventsExample
    {
        public Action OddNumberDelegate { get; set; }
        public event Action OddNumberEvent;

        public EventsExample()
        {
            OddNumberDelegate = IncreaseCounter;
            OddNumberEvent += IncreaseCounter;
        }

        private int _counter;
        public void IncreaseCounter()
        {
            _counter++;
        }

        public void Add(int a, int b)
        {
            int result = a + b;
            Console.WriteLine(result);
            if (result % 2 != 0)
            {
                OddNumberDelegate?.Invoke();
                OddNumberEvent?.Invoke();
            }
        }

        public void Test()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Add(i, j);
                }
                //OddNumberDelegate = null;
                //OddNumberEvent = null;
            }

            Console.WriteLine("Counter: " + _counter);
        }
    }
}
