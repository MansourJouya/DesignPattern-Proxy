using System;
using System.Collections.Generic;

/// <summary>
/// Interface for proxy that provides control over access to the real object.
/// </summary>
public interface IRealSubject
{
    void Request();
}

/// <summary>
/// Real subject class that performs the actual work.
/// </summary>
public class RealSubject : IRealSubject
{
    /// <summary>
    /// Implementation of the actual request.
    /// </summary>
    public void Request()
    {
        Console.WriteLine("RealSubject: Handling request.");
    }
}

/// <summary>
/// Proxy class that controls access to the real subject.
/// </summary>
public class Proxy : IRealSubject
{
    private RealSubject? _realSubject;

    /// <summary>
    /// Checks permissions and delegates the request to the real subject.
    /// </summary>
    public void Request()
    {
        if (CheckAccess())
        {
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }
            _realSubject.Request();
        }
        else
        {
            Console.WriteLine("Proxy: Access denied.");
        }
    }

    /// <summary>
    /// Simulates checking access permissions.
    /// </summary>
    /// <returns>True if access is granted; otherwise, false.</returns>
    private bool CheckAccess()
    {
        Console.WriteLine("Proxy: Checking access...");
        // Simulate access control logic here (e.g., authentication, authorization)
        return true; // Assuming access is granted for simplicity.
    }
}

/// <summary>
/// Client code that interacts with the proxy.
/// </summary>
public class Program
{
    /// <summary>
    /// Main entry point for the program.
    /// </summary>
    public static void Main()
    {
        IRealSubject proxy = new Proxy();

        // The client requests an operation through the proxy.
        proxy.Request();
    }
}
