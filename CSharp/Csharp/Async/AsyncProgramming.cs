using System.Threading.Tasks;

namespace CSharp.Async
{

    public class AsyncProgramming
    {
        public static async Task solve()
        {
            await Task.Delay(2000);
            Console.WriteLine("Async Task Completed!");
        }

        public static async Task Runner()
        {
            AsyncProgramming asyncProgramming = new AsyncProgramming();
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await solve();
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Main method continues while waiting for async task...");
        }

        public static async Task SimulateCpuWork()
        {
            Console.WriteLine($"Starting CPU-bound work on Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            // Task.Run pushes the provided lambda (the work) to the ThreadPool
            int result = await Task.Run(() =>
                {
                    Console.WriteLine($"Started CPU-bound work on Thread ID: {Thread.CurrentThread.ManagedThreadId}");
                    // This code runs on a ThreadPool thread
                    long sum = 0;
                    for (int i = 0; i < 1_000_000_000; i++) // A long-running loop
                    {
                        sum += i;
                    }
                    Console.WriteLine($"CPU-bound work completed on Thread ID: {Thread.CurrentThread.ManagedThreadId}");
                    return (int)(sum % 100); // Return some result
                });

            Console.WriteLine($"CPU-bound work finished awaiting. Result: {result} on Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }

        public async Task<string> FetchDataAsync(string url)
        {
            Console.WriteLine($"Fetching {url} on Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(new Random().Next(1000, 3000)); // Simulate network delay
            Console.WriteLine($"Finished fetching {url} on Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return $"Data from {url}";
        }

        public async Task GetAllData()
        {
            Console.WriteLine($"Starting all data fetch on Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            Task<string> task1 = FetchDataAsync("url1.com");
            Task<string> task2 = FetchDataAsync("url2.com");
            Task<string> task3 = FetchDataAsync("url3.com");

            // These tasks run concurrently
            string[] results = await Task.WhenAll(task1, task2, task3);

            Console.WriteLine($"All data fetched. Results: {string.Join(", ", results)} on Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        }

    public static async Task PerformWorkOnThreadPool()
    {
        Console.WriteLine($"PerformWorkOnThreadPool() started on Thread ID: {Thread.CurrentThread.ManagedThreadId}"); // (1)

        // Calling a CPU-bound operation using Task.Run
        int result = await Task.Run(() => // (2)
        {
            Console.WriteLine($"Task.Run() lambda started on Thread ID: {Thread.CurrentThread.ManagedThreadId}"); // (3)
            // Simulate CPU-intensive work
            long sum = 0;
            for (int i = 0; i < 500_000_000; i++) { sum += i; }
            Console.WriteLine($"Task.Run() lambda finished on Thread ID: {Thread.CurrentThread.ManagedThreadId}"); // (4)
            return (int)(sum % 100);
        });

        Console.WriteLine($"PerformWorkOnThreadPool() resumed after await. Result: {result} on Thread ID: {Thread.CurrentThread.ManagedThreadId}"); // (5)
    }

    public static async Task Runne()
    {
        Console.WriteLine($"Runner() started on Thread ID: {Thread.CurrentThread.ManagedThreadId}"); // (A)

        // Schedule PerformWorkOnThreadPool to run on a ThreadPool thread
        Task backgroundTask = Task.Run(async () => {
            Console.WriteLine($"Scheduling PerformWorkOnThreadPool() on Thread ID: {Thread.CurrentThread.ManagedThreadId}"); // (B)
            await PerformWorkOnThreadPool();
        }); // (B)

        Console.WriteLine($"Runner() continuing after scheduling background task on Thread ID: {Thread.CurrentThread.ManagedThreadId}"); // (C)

        // Keep Runner() alive to see the output from PerformWorkOnThreadPool
        backgroundTask.Wait(); // Blocking here for demonstration, usually you'd await in an async Main
        // Or if Main is not async: backgroundTask.GetAwaiter().GetResult();
        Console.WriteLine($"Runner() finished on Thread ID: {Thread.CurrentThread.ManagedThreadId}"); // (D)
    }

    }
}
/*

    learned about dispose and gc

*/