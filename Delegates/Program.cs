using Delegates;

//new DelegatesExample().Test();
//new MulticastDelegatesExample().Test();
//new BuildInDelegatesExample().Test();
EventsExample eventsExample = new EventsExample();

eventsExample.OddNumberDelegate = null;
eventsExample.OddNumberEvent += Console.WriteLine;

eventsExample.OddNumberEvent -= Console.WriteLine;

//event jest "nakładką" na delegata, który pozwala na dodawanie (+=) i usuwanie (-=) metod z listy wywołań delegata,
//ale nie pozwala na przypisanie (=) nowej metody do delegata (przypisanie do null jest też niedozwolone)
//eventsExample.OddNumberEvent = Console.WriteLine;

//eventsExample.Test();
new LambdaExpressionExample().Test();
