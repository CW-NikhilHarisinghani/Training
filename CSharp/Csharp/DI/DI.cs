// di library name in c# how to import
using System;
using Microsoft.Extensions.DependencyInjection;
// Namespace declaration


namespace Charp.DependencyInjection
{
    // Interface (Abstraction)
    public interface ILogger
    {
        void Log(string message);
    }

    // Concrete Implementation 1
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[Console] {message}");
        }
    }

    // Concrete Implementation 2 (just for comparison)
    public class FancyLogger : ILogger
    {
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"✨ {message} ✨");
            Console.ResetColor();
        }
    }

    // Class that depends on ILogger
    public class UserService
    {
        private readonly ILogger _logger;

        // Constructor Injection
        public UserService(ILogger logger)
        {
            _logger = logger;
        }

        public void Login(string username)
        {
            _logger.Log($"{username} has logged in!");
        }
    }

    // Entry Point
    class Grah
    {
        public static void Mmm()
        {
            var services = new ServiceCollection();
            // services.
            services.AddTransient<ILogger, ConsoleLogger>();
            // services.AddSingleton<ILogger, FancyLogger>(); // This replaces the transient
        
            services.AddSingleton<UserService>();
            var provider = services.BuildServiceProvider();

            var userService = provider.GetRequiredService<UserService>();
            var grah = provider.GetRequiredService<UserService>();
            Console.WriteLine(typeof(UserService).Name);
            Console.WriteLine(ReferenceEquals(userService, grah)); // Should print 'True' if both are the same instance
            userService.Login("nikhil");
            aaa a = new hein();
            // a.guid = 1; // This will cause an error because 'guid' is read-only in 'aaa'
        }
    }

    class aaa
    {
        public int guid { get; }
    }

    class hein : aaa
    {
        public int guid { get; set; } = 1;
    }
}

/*

DIP tells us that ReportGenerator shouldn't depend directly on FileManager. 
Instead, they both should depend on an abstraction (e.g., an interface).

*/

// 1. Abstraction (interface)
public interface IReportSaver
{
    void Save(string fileName, string content);
}

// 2. Low-level module depends on abstraction
public class FileManager : IReportSaver
{
    public void Save(string fileName, string content)
    {
        Console.WriteLine($"Saving '{content}' to '{fileName}' using FileManager.");
        // Logic to save to a file
    }
}

// Another low-level module depending on abstraction
public class DatabaseManager : IReportSaver
{
    public void Save(string fileName, string content)
    {
        Console.WriteLine($"Saving '{content}' to '{fileName}' using DatabaseManager.");
        // Logic to save to a database
    }
}

// 3. High-level module depends on abstraction
public class ReportGenerator
{
    private IReportSaver _reportSaver; // Depends on abstraction

    public ReportGenerator(IReportSaver reportSaver) // Dependency comes from outside
    {
        _reportSaver = reportSaver;
    }

    public void GenerateReport(string reportContent)
    {
        // ... generate report ...
        _reportSaver.Save("report.txt", reportContent);
    }
}
/* DIP Over*/
/*

 DIP ensures that high-level modules (like ReportGenerator) are not tightly coupled to low-level modules (like FileManager or DatabaseManager).
 where as IoC talks about instantiation and how dependencies are provided to a class, often through techniques like constructor injection, property injection, or method injection.

*/

// 1. Define an Abstraction (Interface) for the dependency
public interface IMessageSender
{
    void Send(string message);
}

// 2. Concrete Implementation of the dependency
public class EmailSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine($"EmailSender: Sending '{message}' via email.");
        // Logic to send an actual email
    }
}

// Another concrete implementation
/*
constructror injection is a design pattern where dependencies are provided to a class through its constructor. This allows for better separation of concerns, easier testing, and more flexible code.
public class SmsSender : IMessageSender
{
    public void Send(string message)
    {
        Console.WriteLine($"SmsSender: Sending '{message}' via SMS.");
        // Logic to send an actual SMS
    }
}

// 3. The Consumer Class (requires IMessageSender)
public class NotificationService
{
    private readonly IMessageSender _sender; // Dependency held as a private readonly field

    // Constructor Injection: IMessageSender is injected here
    public NotificationService(IMessageSender sender)
    {
        _sender = sender ?? throw new ArgumentNullException(nameof(sender));
    }

    public void SendNotification(string message)
    {
        Console.WriteLine("NotificationService: Preparing notification.");
        _sender.Send(message); // Uses the injected dependency
    }
}

// How to use it (manual DI - without an IoC Container)
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Constructor Injection ---");

        // Injecting EmailSender
        IMessageSender emailSender = new EmailSender();
        NotificationService emailService = new NotificationService(emailSender);
        emailService.SendNotification("Hello from email!");

        Console.WriteLine("\n---");

        // Injecting SmsSender
        IMessageSender smsSender = new SmsSender();
        NotificationService smsService = new NotificationService(smsSender);
        smsService.SendNotification("Hello from SMS!");

        Console.ReadLine();
    }
}
*/


/*
property injection is a design pattern where dependencies are provided to a class through its properties. This allows for more flexibility in configuring the class, but it can
// (IMessageSender, EmailSender, SmsSender interfaces/classes are the same as above)

// The Consumer Class (requires IMessageSender via property)
public class NotificationServiceProperty
{
    // Property Injection: IMessageSender is exposed as a public property
    public IMessageSender Sender { get; set; }

    public void SendNotification(string message)
    {
        if (Sender == null) // Check for null is often required as property is optional
        {
            Console.WriteLine("Warning: No message sender configured. Notification not sent.");
            return;
        }

        Console.WriteLine("NotificationServiceProperty: Preparing notification.");
        Sender.Send(message); // Uses the injected dependency
    }
}

// How to use it (manual DI)
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n--- Property Injection ---");

        NotificationServiceProperty serviceProp = new NotificationServiceProperty();

        // Injecting EmailSender
        serviceProp.Sender = new EmailSender();
        serviceProp.SendNotification("Property injected email!");

        Console.WriteLine("\n---");

        // Changing the dependency later
        serviceProp.Sender = new SmsSender();
        serviceProp.SendNotification("Property injected SMS!");

        Console.WriteLine("\n---");

        // What happens if no sender is set?
        NotificationServiceProperty serviceNoSender = new NotificationServiceProperty();
        serviceNoSender.SendNotification("This notification will not be sent.");

        Console.ReadLine();
    }
}


*/

/*
method injection is a design pattern where dependencies are provided to a class through method parameters. This allows for more flexibility in how dependencies are used, but it can lead to more complex method signatures.
// (IMessageSender, EmailSender, SmsSender interfaces/classes are the same as above)

// The Consumer Class (requires IMessageSender via method parameter)
public class NotificationServiceMethod
{
    // No class-level dependency on IMessageSender
    public void SendSpecificNotification(string message, IMessageSender sender) // Method Injection
    {
        // Null check on sender might still be good practice, though caller is responsible
        if (sender == null)
        {
            Console.WriteLine("Error: Sender cannot be null for method injection.");
            return;
        }

        Console.WriteLine("NotificationServiceMethod: Preparing specific notification.");
        sender.Send(message); // Uses the injected dependency for this method call
    }
}

// How to use it (manual DI)
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n--- Method Injection ---");

        NotificationServiceMethod serviceMethod = new NotificationServiceMethod();

        // Injecting EmailSender for this specific method call
        serviceMethod.SendSpecificNotification("Method injected email!", new EmailSender());

        Console.WriteLine("\n---");

        // Injecting SmsSender for another specific method call
        serviceMethod.SendSpecificNotification("Method injected SMS!", new SmsSender());

        Console.ReadLine();
    }
}


*/