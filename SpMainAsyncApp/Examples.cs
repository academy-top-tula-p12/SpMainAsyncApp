using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpMainAsyncApp
{
    public class Examples
    {
        public static async Task AsyncWelcomeExample()
        {
            var loop1 = LoopAsync;

            await loop1();

            async Task LoopAsync()
            {
                await Task.Delay(2000);
                await Task.Run(() => Loop());
            }

            void Loop()
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Task #{Task.CurrentId} - {i}");
                    //Thread.Sleep(500);
                }
            }
        }

        public static async Task AsyncRunsExample()
        {
            //await PrintName("Bobby");
            //await PrintName("Sammy");
            //await PrintName("Jimmy");

            Func<string, Task> printName = async (name) =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"{name} {i}");
                    await Task.Delay(300);
                }
            };

            var task1 = PrintName("Bobby");
            var task2 = PrintName("Sammy");
            var task3 = PrintName("Jimmy");
            var task4 = printName("Tommy");

            await task1;
            await task2;
            await task3;
            await task4;   
        }

        public static async Task AsyncResultExample()
        {
            var t1 = GaussSum(1000);
            var t2 = GaussSum(2000);
            var t3 = GaussSum(3000);

            Console.WriteLine(await t1);
            Console.WriteLine(await t2);
            Console.WriteLine(await t3);

        }

        public static async Task AsyncWaitExample()
        {
            //var task1 = PrintName("Bobby");
            //var task2 = PrintName("Sammy");
            //var task3 = PrintName("Jimmy");

            //await Task.WhenAny(task1, task2, task3);

            var t1 = GaussSum(1000);
            var t2 = GaussSum(2000);
            var t3 = GaussSum(3000);

            //int[] results = await Task.WhenAll(t1, t2, t3);

            //foreach(int i in results)
            //    Console.WriteLine(i);

            var result = await Task.WhenAny(t1, t2, t3);
            Console.WriteLine(result.Result);
        }

        static async Task<int> GaussSum(int number)
        {
            int result = 0;
            for (int i = 0; i <= number; i++)
                result += i;
            await Task.Delay(3000);

            return result;
        }

        static async Task PrintName(string name)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{name} {i}");
                await Task.Delay(300);
            }
        }
    }
}
