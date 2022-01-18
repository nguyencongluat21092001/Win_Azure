using ConsoleApp1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceClient client = new ServiceClient();
            Console.WriteLine("Result: " + client.GetData(10));

            // Use the 'client' variable to call operations on the service.

            // Always close the client.
            client.Close();
        }
    }
}
