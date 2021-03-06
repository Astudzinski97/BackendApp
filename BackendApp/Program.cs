using Microsoft.Owin.Hosting;
using System;

namespace BackendApp
{
    class Program
    {
        static void Main(string[] args)
        {
            EntityFrameworkProfilerBootstrapper.PreStart();

            using (WebApp.Start<Startup>("http://localhost:8080"))
            {
                Console.WriteLine("Web Server is running");
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }
        }
    }
}

