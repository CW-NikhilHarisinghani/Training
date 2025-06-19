    var builder = WebApplication.CreateBuilder(args);
    // explain what is args and WebApplication how does it work without importing namespaces
    /*

    The `args` parameter in the `WebApplication.CreateBuilder(args)` method is an array of command-line arguments that are passed to the application when it starts. 
    This allows you to configure the application based on command-line inputs, 
    such as specifying environment variables or configuration settings.

    The `WebApplication` class is part of the ASP.NET Core framework and 
    provides a simplified way to build web applications.
    It encapsulates the application's configuration, services, and middleware pipeline.
    When you call `WebApplication.CreateBuilder(args)`, it initializes a new instance of the
    `WebApplicationBuilder` class,
    which is used to configure services, middleware, and other settings for the application.

    how can i access without importing namespaces?
    The `WebApplication` and `WebApplicationBuilder` classes are part of the `Microsoft.AspNetCore.Builder` namespace,
    which is included in the ASP.NET Core framework.

    the middleware are set as callbacks in the actual low level code?
    // Yes, middleware in ASP.NET Core is set up as a pipeline of callbacks that are executed in order for each HTTP request.
    give a demo code of above happeninng
    */
    // Add services to the container.
    builder.Services.AddControllersWithViews();
    // explain what is AddControllersWithViews and how does it work without importing namespaces
    /*
    `AddControllersWithViews` is an extension method provided by the ASP.NET Core framework that registers
    the necessary services for using controllers and views in an ASP.NET Core application.
    It sets up the MVC (Model-View-Controller) pattern, allowing you to create web
    give example of necessary services
    */
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    // if this is added why can i only acces the only via http?
    // -> extra config required
    // `UseHttpsRedirection` is middleware that redirects HTTP requests to HTTPS, enhancing security by ensuring that all traffic is encrypted.
    // `UseHsts` is middleware that adds HTTP Strict Transport Security (HSTS) headers
    app.UseStaticFiles();
    // `UseStaticFiles` is middleware that serves static files (like CSS, JavaScript, images) from the wwwroot folder of the application.
    app.UseRouting();
    // `UseRouting` is middleware that enables routing capabilities in the application, allowing it to match incoming requests to the appropriate endpoints (controllers/actions).
    app.UseAuthorization();
    // `UseAuthorization` is middleware that enables authorization checks for incoming requests, ensuring that users have the necessary permissions to access certain resources.
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    // app.MapControllers();
    // app.MapGet("/grah",()=> "Hello World from Grah!");
// `MapControllerRoute` is used to define the routing pattern for the application, specifying how URLs map to controllers and actions.
/*
What Kestrel Does:
Kestrel:

Listens for TCP connections

Parses HTTP requests

Manages request/response pipelines

Handles headers, status codes, and encodings

Supports HTTP/1.1, HTTP/2, HTTPS, WebSockets, etc.

Handles request routing (via middleware in ASP.NET Core)

Without Kestrel, you would write all of that yourself, or use lower-level libraries.
*/
app.Run();
    /*
        difference between appsettings.json and projectFolder.csproj
    `appsettings.json` is a configuration file used in ASP.NET Core applications to store application settings
    and configuration data in a structured format (JSON). It allows developers to define settings such as connection strings, logging levels, and other application-specific configurations that can be 
    easily modified without changing the code.
    projectFolder.csproj is the project file for an ASP.NET Core application, written in XML format.
    It contains metadata about the project, such as its name, version, dependencies, and build settings.
    It is used by the .NET build system to compile the application, manage dependencies, and define
    */