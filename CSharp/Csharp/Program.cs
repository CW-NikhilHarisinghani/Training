using System;
// i want to acess class at ./prozect/INsider.cs
// To access the `Insider` class from another file, you need to ensure that both files are part of the same project and that the namespace is correctly referenced.
using System.Collections.Generic;
using System.Linq;
using Testinig; // Ensure this namespace matches the one in Insider.cs
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
    static void Main(string[] args)
    {
        Console.WriteLine("Hello again from Main!");
        int a = Convert.ToInt32("123");
        Console.WriteLine($"Converted value: {a}");
        if (a.GetType() == typeof(int))
        {
            Console.WriteLine("Variable 'a' is of type int.");
        }
        else
        {
            Console.WriteLine("Variable 'a' is not of type int.");
        }
        Console.WriteLine("Conversion successful!");
        MyInt myInt = 456;
        int b = myInt;

        const string m = "abc";
        const string n = "abc";
        // n[0] = 'd';
        // how to achieve .intern() like java here
        // In C#, string interning is handled automatically by the runtime.
        // When you create a string literal, the runtime checks if an identical string already exists in memory.
        // give a code that achieves it
        string internedM = string.Intern(m);
        Console.WriteLine(object.ReferenceEquals(m, n));


        foreach (char c in m)
        {
            Console.WriteLine(c);
        }
        for (int i = 0; i < m.Length; i++)
        {
            Console.WriteLine(m[i]);
        }
        Console.WriteLine($"MyInt value: {myInt.Value}");
        Console.WriteLine($"Converted MyInt to int: {b}");
        // 6. Boxing with object[]

        object[] mixed = new object[] { 1, "hello", true };
        List<object> list = new List<object>();
        list.Add(5);

        List<int> nums = new List<int>();
        nums.Add(5);
        Testinig.Insider.Maid(); // Accessing the Maid method from the Insider class

        Testinig.Insider l = new Testinig.Insider();
        l.ratata(); // Accessing the Maid method from the Insider class
        try
        {
            throw new Exception("specific condition");
        }
        catch (Exception e) when (e.Message.Contains("specific condition"))
        {
            Console.WriteLine("Caught an exception with a specific condition.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Caught an exception: {e.Message}");
        }


        throw new exception('message', );
        try
        {
            parent();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Caught an exception in Main: {e.Message}");
            Console.WriteLine(e.StackTrace);
//             while (inner != null)
//             {
//              Console.WriteLine(inner.StackTrace);
//                 inner = inner.InnerException;
// }

        }
    }
}