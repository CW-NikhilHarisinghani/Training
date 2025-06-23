using System;
using System.Collections;

// i want to acess class at ./prozect/INsider.cs
// To access the `Insider` class from another file, you need to ensure that both files are part of the same project and that the namespace is correctly referenced.
using System.Collections.Generic;
using System.Linq;
using Testinig; // Ensure this namespace matches the one in Insider.cs
using Csharp.linQ.Employee; // Ensure this namespace matches the one in Employee.cs
using CSharp.limQ.Department; // Ensure this namespace matches the one in Department.cs
using Charp.DependencyInjection;
using CSharp.Async;
using System.Threading.Tasks;
using CSharp.Dapper;
namespace HelloWorld
{
    public class StringOps
    {
        //     {
        //         string a = "hello";
        // string b = null;
        // Console.WriteLine(a == b);      // false (safe, handles nulls)
        // Console.WriteLine(a.Equals(b)); // ❌ throws NullReferenceException if a is null
    }
}
    public class MyInt
    {
        public int Value { get; } // explain what get means 
        // The 'get' keyword indicates that this property is read-only.
        // It can be accessed but not modified outside of the class.

    public MyInt(int value)
    {
            Value = value;
        }

    public static implicit operator MyInt(int value)
    {
        return new MyInt(value);
    }

    public static implicit operator int(MyInt myInt)
    {
        return myInt.Value;
    }
}

sealed class ab
{
    public ab()
    {
        Console.WriteLine("Constructor called");
    }
}

// class bc : ab
// {
//     int k = 2;
//     public bc()
//     {
//         // ab(1);
//         Console.WriteLine("Derived constructor called");
//     }
// }

interface IClass
{
    static int x=0;
    static IClass()
    {
        Console.WriteLine("Static constructor in interface called.");
    }
    static void ok()
    {
        Console.WriteLine("Static method in interface called.");
    }
    // {
    //     Console.WriteLine("Hello");
    // }
}

    public delegate void delegateCaller();

class TCPData
{
    public int Id { get; set; }
    public String Name { get; set; }
}
// This is called an Extension Method.
// satcic methods in a static class can be used to extend the functionality of existing types without modifying them.
// Extension methods are a way to add new methods to existing types without creating a new derived type
public static class MyExtensions
{
    public static void Print<T>(this List<T> list)
    {
        foreach (var item in list)
            Console.WriteLine(item);
    }
}
class Program
{
    static void grandParent()
    {
        Console.WriteLine("Hello from grandParent!");
        throw new Exception("An error occurred in grandParent.");
    }
    static void parent()
    {
        try
        {
            Console.WriteLine("Hello from parent!");
            grandParent();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Caught an exception in parent: {e.Message}");
            // throw new Exception("wubba lubba dub dub" ); // Re-throwing the exception to be caught in Main
            // throw; // This re-throws the caught exception without losing the stack trace
            throw new ArgumentException("An error occurred in parent.", e); // Wrapping the exception in a new one
        }
    }
    static void delegateMethod()
    {
        Console.WriteLine("Delegate method called.");
    }
    delegate void Logger();
    static async Task Main(string[] args)
    {
        DapperExample.Run().Wait(); // Call the Dapper example method
        // await AsyncProgramming.SimulateCpuWork(); // Call the async method runner
        //  await AsyncProgramming.Runner(); // Call the async method runner
        // await AsyncProgramming.Runne();
        // Grah g = new Grah();
        // Grah.Mmm();
        // Console.WriteLine("Hello from Main!");

        // List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        // var query = numbers.Where(x => x > 2);  // ⚠️ Nothing executed here

        // numbers.Add(6); // 😯 Modifies the original list

        // foreach (var item in query) // ✅ Execution happens NOW
        // {
        //     Console.WriteLine(item);
        // }

        // List<int> n = new List<int> { 1, 2, 3 };

        // var q = numbers.Where(x =>
        // {
        //     Console.WriteLine($"Checking {x}");
        //     return x > 1;
        // });

        // // Deferred: No output yet!

        // Console.WriteLine("Iterating now:");
        // int cnt = 0;
        // foreach (var x in q)
        // {
        //     cnt++;
        //     Console.WriteLine($"Got: {x}");
        //     if (cnt > 0) break;
        // }

        // List<Func<int>> funcs = new List<Func<int>>();

        // for (int i = 0; i < 3; i++)
        // {
        //     int k = i;
        //     funcs.Add(() => k);
        // }

        // foreach (var f in funcs)
        //     Console.WriteLine(f());











        // List<Employee> employees = new List<Employee>
        // {
        //     new Employee(1, "Alice", "HR", 50000),
        //     new Employee(2, "Bob", "IT", 60000),
        //     new Employee(3, "Charlie", "Finance", 70000)
        // };

        // List<Department> departments = new List<Department>
        // {
        //     new Department(1, "HR"),
        //     new Department(2, "IT"),
        //     new Department(3, "Finance")
        // };

        // var highEarners = employees
        //     .Where(e => e.Salary > 55000)
        //     .Select(e => new { e.Name, e.Salary });

        // Console.WriteLine("High Earners:");
        // foreach (var employee in highEarners)
        // {
        //     Console.WriteLine($"Name: {employee.Name}, Salary: {employee.Salary}");
        // }

        // var departmentNames = departments
        //     .Join(
        //         employees,
        //         d => d.Name,
        //         e => e.Department,
        //         (d, e) => new { d.Id, d.Name, e.Salary }
        //     );

        // foreach (var grah in departmentNames) {
        //     Console.WriteLine($"Department ID: {grah.Id}, Name: {grah.Name}, Salary: {grah.Salary}");
        // }

        // var adj = from e in employees
        //           where e.Salary > 55000
        //           select new { e.Name, e.Salary };

















        // List<int> hehe = new List<int> { 1, 2, 3, 4, 5 };
        // hehe.Print();

        // // anony mous class
        // var navra = new
        // {
        //     Name = "Nikhil",
        //     Age = 25,
        //     IsStudent = true
        // };














        // // Example of using a delegate
        // delegateCaller caller = delegateMethod;
        // MyClass myClass = new MyClass();
        // caller += () => Console.WriteLine("Hello from lambda in Main!"); // Adding a lambda expression to the delegate  
        // myClass.delega(caller); // Invoking the delegate




        // void LogToFile() => Console.WriteLine("File");
        // void LogToConsole() => Console.WriteLine("Console");

        // Logger log = LogToFile;
        // log += LogToConsole;

        // log(); // Logs to both file and console

        // EmailNotifier emailNotifier = new EmailNotifier();
        // emailNotifier.Notify();
        // bc a = new bc();
        // Oops oops = new Oops();
        // oops.Age = 25; // Setting a valid age
        // Console.WriteLine($"Age is set to: {oops.Age}");

        // ArrayList a = new ArrayList();
        // a.Add(1);
        // a.Add(null);
        // a.Add(true);
        // a.Add("me nigalo");
        // foreach (var i in a)
        // {
        //     Console.WriteLine(i);
        // }
        // Console.WriteLine(a.Count);
        // Console.WriteLine("Hello from Main!");
        // IClass.ok(); // Calling the static method from the interface

        //         Console.WriteLine("Hello again from Main!");
        //         int a = Convert.ToInt32("123");
        //         Console.WriteLine($"Converted value: {a}");
        //         if (a.GetType() == typeof(int))
        //         {
        //             Console.WriteLine("Variable 'a' is of type int.");
        //         }
        //         else
        //         {
        //             Console.WriteLine("Variable 'a' is not of type int.");
        //         }
        //         Console.WriteLine("Conversion successful!");
        //         MyInt myInt = 456;
        //         int b = myInt;

        //         const string m = "abc";
        //         const string n = "abc";
        //         // n[0] = 'd';
        //         // how to achieve .intern() like java here
        //         // In C#, string interning is handled automatically by the runtime.
        //         // When you create a string literal, the runtime checks if an identical string already exists in memory.
        //         // give a code that achieves it
        //         string internedM = string.Intern(m);
        //         Console.WriteLine(object.ReferenceEquals(m, n));


        //         foreach (char c in m)
        //         {
        //             Console.WriteLine(c);
        //         }
        //         for (int i = 0; i < m.Length; i++)
        //         {
        //             Console.WriteLine(m[i]);
        //         }
        //         Console.WriteLine($"MyInt value: {myInt.Value}");
        //         Console.WriteLine($"Converted MyInt to int: {b}");
        //         // 6. Boxing with object[]

        //         object[] mixed = new object[] { 1, "hello", true };
        //         List<object> list = new List<object>();
        //         list.Add(5);

        //         List<int> nums = new List<int>();
        //         nums.Add(5);
        //         Testinig.Insider.Maid(); // Accessing the Maid method from the Insider class

        //         Testinig.Insider l = new Testinig.Insider();
        //         l.ratata(); // Accessing the Maid method from the Insider class
        //         try
        //         {
        //             throw new Exception("specific condition");
        //         }
        //         catch (Exception e) when (e.Message.Contains("specific condition"))
        //         {
        //             Console.WriteLine("Caught an exception with a specific condition.");
        //         }
        //         catch (Exception e)
        //         {
        //             Console.WriteLine($"Caught an exception: {e.Message}");
        //         }


        //         // throw new exception('message', );
        //         try
        //         {
        //             parent();
        //         }
        //         catch (Exception e)
        //         {
        //             Console.WriteLine($"Caught an exception in Main: {e.Message}");
        //             Console.WriteLine(e.StackTrace);
        // //             while (inner != null)
        // //             {
        // //              Console.WriteLine(inner.StackTrace);
        // //                 inner = inner.InnerException;
        // // }

        // }
    }
}

// class MyClass
// {
//     public void delega(delegateCaller caller)
//     {
//         caller();
//     }
// }

// namespace DelegateDemo
// {
//     class Program
//     {
//         // // 🔷 1. Regular Delegate (custom)
//         // public delegate int MathOperation(int x, int y);

//         // // 🔷 2. Predicate Delegate (built-in)
//         // static bool IsEven(int x) => x % 2 == 0;

//         // // 🔷 3. Multicast Delegate Example
//         // public delegate void Logger(string message);

//         // static void Main(string[] args)
//         // {
//         //     Console.WriteLine("🔹 REGULAR DELEGATE");
//         //     MathOperation add = (a, b) => a + b;
//         //     Console.WriteLine($"Add(3, 5) = {add(3, 5)}");

//         //     Console.WriteLine("\n🔹 FUNC DELEGATES");
//         //     Func<int, int, int> multiply = (a, b) => a * b;
//         //     Console.WriteLine($"Multiply(4, 6) = {multiply(4, 6)}");

//         //     Func<string, int> getLength = s => s.Length;
//         //     Console.WriteLine($"Length of 'hello' = {getLength("hello")}");

//         //     Console.WriteLine("\n🔹 ACTION DELEGATES");
//         //     Action<string> greet = name => Console.WriteLine($"Hello, {name}!");
//         //     greet("Nikhil");

//         //     Action<int, int> displaySum = (x, y) => Console.WriteLine($"Sum: {x + y}");
//         //     displaySum(10, 20);

//         //     Console.WriteLine("\n🔹 PREDICATE");
//         //     Predicate<int> isEven = IsEven;
//         //     Console.WriteLine($"Is 4 even? {isEven(4)}");

//         //     List<int> nums = new() { 1, 2, 3, 4, 5, 6 };
//         //     List<int> evens = nums.FindAll(isEven);
//         //     Console.WriteLine("Evens: " + string.Join(", ", evens));

//         //     Console.WriteLine("\n🔹 MULTICAST DELEGATE");
//         //     Logger logger = Console.WriteLine;
//         //     logger += msg => Console.WriteLine($"[LOGGED]: {msg}");
//         //     logger("This is a multicast delegate!");

//         //     Console.WriteLine("\n🔹 COMBINING FUNC AND ACTION IN PRACTICE");

//         //     List<string> names = new() { "Anna", "Bob", "Christopher", "Tom" };

//         //     Process(
//         //         names,
//         //         name => name.Length <= 4,               // Func<string, bool>
//         //         name => Console.WriteLine($"Short name: {name}") // Action<string>
//         //     );
//         // }

//         // static void Process<T>(List<T> items, Func<T, bool> filter, Action<T> processor)
//         // {
//         //     foreach (var item in items)
//         //     {
//         //         if (filter(item))
//         //             processor(item);
//         //     }
//         // }

        
//     }
// }
