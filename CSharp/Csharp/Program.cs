using System;

namespace HelloWorld.Csharp.HelloWorld
{
    public class HelloWorld
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World! me nigalo!");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        HelloWorld.Csharp.HelloWorld.HelloWorld.Main(args);
        Console.WriteLine("Hello, World! me nigalo!");
    }
}