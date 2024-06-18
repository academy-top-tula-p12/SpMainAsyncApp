using System;

namespace SpMainAsyncApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var task1 = PrintMessageAsync("");
            var task2 = PrintMessageAsync("ab");

            var tasks = Task.WhenAll(task2, task1);
            try
            {
                //await PrintMessageAsync("Hello world");
                //await task;
                //await Task.Delay(0);

                await tasks;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(tasks.Exception?.InnerException?.Message);
                //Console.WriteLine(task.Exception?.InnerException?.Message);
                //Console.WriteLine(task.IsFaulted);
                //Console.WriteLine(task.Status);
                if (tasks.Exception is not null)
                {
                    foreach(var e in tasks.Exception.InnerExceptions)
                        Console.WriteLine($"\t{e.Message}");
                }

            }
        }

        static async Task PrintMessageAsync(string message)
        {
            Random rnd = new Random();

            if (message.Length == 0)
                throw new Exception($"Empty message!");
            if(message.Length < 3)
                throw new Exception($"Length message is small!");
            await Task.Delay(rnd.Next(1000, 3000));
            Console.WriteLine(message);
        }

    }
}
