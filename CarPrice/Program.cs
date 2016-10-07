using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPrize
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car() { 
            Liter = 6.0f,
            OriginalPrice = 217900,
            Region = "Europe"
            };


            Car car2 = new Car()
            {
                Liter = 1.5f,
                OriginalPrice = 19490,
                Region = "Japan"
            };

            Car car3 = new Car()
            {
                Liter = 3.6f,
                OriginalPrice = 36995,
                Region = "USA"
            };

            Car car4 = new Car()
            {
                Liter = 1.0f,
                OriginalPrice = 6000,
                Region = "China"
            };

            Console.WriteLine(car1.GetPrice());
            Console.WriteLine(car2.GetPrice());
            Console.WriteLine(car3.GetPrice());
            Console.WriteLine(car4.GetPrice());
            Console.Read();
        }
    }
}
