class Hmm
{
    
}

// class Base
// {
//     public static void SayHello()
//     {
//         Console.WriteLine("Hello from Base");
//     }
// }

// class Derived : Base
// {
//     // public override static void SayHello() // ❌ This is a compiler error!
//     // {
//     //     Console.WriteLine("Hello from Derived");
//     // }
// }

// /*
//     Over riding static methods is not allowed in C#.
//     Static methods are not polymorphic, and they cannot be overridden.
// */
// class Notifier
// {
//     public virtual void Send()
//     {
//         Console.WriteLine("Sending generic notification...");
//     }

//     internal void Notify()
//     {
//         Console.WriteLine("This is a private method in Notifier class.");
//     }
// }

// class EmailNotifier : Notifier
// {
//     public override void Send()
//     {
//         Console.WriteLine("Sending Email...");
//     }
//     internal new void Notify()
//     {
//         Console.WriteLine("This is a private method in EmailNotifier class.");
//     }
// }

// class SMSNotifier : Notifier
// {
//     public override void Send()
//     {
//         Console.WriteLine("Sending SMS...");
//     }
// }
// /*

//     method hiding 
//     Notifier 

// */

// abstract class Animal
// {
//     // ✅ 1. Instance field (not static)
//     static Animal()
//     {
//         Console.WriteLine("Static constructor called.");
//         animalCount = 100;
//     }
//     public int age;

//     // ✅ 2. Static field
//     public static int animalCount = 0;

//     // ✅ 3. Constructor (allowed in abstract class)
//     public Animal(int age)
//     {
//         this.age = age;
//         animalCount++; // track how many animals created
//     }

//     // ✅ 4. Abstract method (must be overridden)
//     public abstract void MakeSound();

//     // ✅ 5. Virtual method (optional override)
//     public virtual void Eat()
//     {
//         Console.WriteLine("Animal is eating something.");
//     }

//     // ✅ 6. Concrete method
//     public void Sleep()
//     {
//         Console.WriteLine("Animal is sleeping.");
//     }

//     // ✅ 7. Static method
//     public static void ShowAnimalCount()
//     {
//         Console.WriteLine($"Total animals: {animalCount}");
//     }
// }

// // ✅ Derived class
// class Dog : Animal
// {
//     public Dog(int age) : base(age) {}

//     // Must override abstract method
//     public override void MakeSound()
//     {
//         Console.WriteLine("Woof!");
//     }

//     // Optional: override virtual method
//     public override void Eat()
//     {
//         Console.WriteLine("Dog is eating bones.");
//     }
// }

// // class Tp
// // {
//     // public void GJKMC()
//     // {
//     //     Dog dog1 = new Dog(3);
//     //     dog1.MakeSound();       // Output: Woof!
//     //     dog1.Eat();             // Output: Dog is eating bones.
//     //     dog1.Sleep();           // Output: Animal is sleeping.
//     //     Console.WriteLine($"Dog's age: {dog1.age}");

//     //     Animal.ShowAnimalCount(); // Output: Total animals: 1

//     //     Dog dog2 = new Dog(5);
//     //     Animal.ShowAnimalCount(); // Output: Total animals: 2
//     // }
// // };


// class Base2
// {
//     public int value = 10;
// }

// class Derived2 : Base2
// {
//     public new int value = 20;
// }

// class pp2
// {
//     static void Main()
//     {
//         Derived2 d = new Derived2();
//         Console.WriteLine(d.value);     // 🔹 20

//         Base2 b = d;
//         Console.WriteLine(b.value);     // 🔹 10
//     }
// }

// class MathConstants
// {
//     public const double Pi = 3.14159;
// }
// // Console.WriteLine(MathConstants.Pi); // ✅ 3.14159 -> const is implicitly static
// interface ILogger
// {
//     static int Count = 0;
//     static void Log(string message)
//     {
//         Console.WriteLine($"[LOG] {message}");
//     }

//     void memo();
// }