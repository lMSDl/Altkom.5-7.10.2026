


_ = DoWorkAsync(5); //fire and forget - wywołanie metody asynchronicznej bez oczekiwania na jej zakończenie


List<Task<string>> tasks = new List<Task<string>>();
Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}");
for (int i = 1; i <= 3; i++)
{
    var taskId = i;
    //Task.Run - uruchamia zadanie asynchroniczne w nowym wątku
    //Task<string> task = Task.Run(() => DoWork(taskId));

    Task<string> task = DoWorkAsync(taskId);
    tasks.Add(task);
}

//HandleTaskOneByOne(tasks);
HandleTasksAllAtOnce(tasks);


Console.ReadLine();


static void HandleTaskOneByOne(List<Task<string>> tasks)
{
    while (tasks.Any())
    {

        //czekamy na zakończenie jakiegokolwiek zadania
        int index = Task.WaitAny(tasks.ToArray());
        var completedTask = tasks[index];

        Console.WriteLine(completedTask.Result + $"  {Thread.CurrentThread.ManagedThreadId}");
        tasks.RemoveAt(index); // usuwamy zakończone zadanie z listy
    }
}

static void HandleTasksAllAtOnce(List<Task<string>> tasks)
{
    // czekamy na zakończenie wszystkich zadań
    Task.WaitAll(tasks);

    foreach (var item in tasks)
    {
        Console.WriteLine(item.Result + $" {Thread.CurrentThread.ManagedThreadId}");
    }
}


string DoWork(int taskId)
{
    Console.WriteLine($"Zadanie {taskId} rozpoczęte. {Thread.CurrentThread.ManagedThreadId}");
    Task.Delay(1000 * taskId).Wait(); // symulacja pracy synchronicznie
    Console.WriteLine($"Zadanie {taskId} zakończone. {Thread.CurrentThread.ManagedThreadId}");
    return $"Wynik zadania {taskId}.";
}

//async - słowo kluczowe, które oznacza, że metoda jest asynchroniczna
//jest ono wymamagane aby można było w metodzie użyć await
//Task - metody asynchroniczne zwracają obiekt Task, który reprezentuje operację asynchroniczną
async Task<string> DoWorkAsync(int taskId)
{
    Console.WriteLine($"Zadanie {taskId} rozpoczęte. {Thread.CurrentThread.ManagedThreadId}");
    //przez użycie await metoda automatycznie opakuje zwracany resultat w Task
    await Task.Delay(1000 * taskId);
    Console.WriteLine($"Zadanie {taskId} zakończone. {Thread.CurrentThread.ManagedThreadId}");
    return $"Wynik zadania {taskId}.";
}