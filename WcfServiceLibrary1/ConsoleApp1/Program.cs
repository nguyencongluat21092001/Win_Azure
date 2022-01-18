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
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            //Console.WriteLine(client.GetData(10));

            Console.WriteLine("Deposit 1000");

            double amount = client.Deposit("a001", 1000);

            if (amount > 0)
            {
                Console.WriteLine("Deposit $" + amount);
            }


        }
    }
}
