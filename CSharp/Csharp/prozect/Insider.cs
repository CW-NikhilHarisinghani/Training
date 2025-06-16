
namespace Testinig
{
    class Insider
    {
        public static void Maid()
        {
            Console.WriteLine("Hello from Insider!");
            // Example of boxing and unboxing
            object boxedValue = 42; // Boxing
            int unboxedValue = (int)boxedValue; // Unboxing
            Console.WriteLine($"Boxed value: {boxedValue}, Unboxed value: {unboxedValue}");

            // Example of using a custom type with implicit conversion
            MyInt myInt = 123;
            int convertedValue = myInt; // Implicit conversion
            Console.WriteLine($"MyInt value: {myInt.Value}, Converted value: {convertedValue}");
        }


        public void ratata()
        {
            Console.WriteLine("This is a private method in Insider class.");
        }
    }
    
}
// how to export this class??
// In C#, classes are typically defined in their own files, and you can use namespaces to organize them.
// To export the `Insider` class, you can simply place it in a separate file named `Insider.cs` and ensure it is part of the same project or solution.
// Here's how you can structure the `Insider` class in a separate file:
