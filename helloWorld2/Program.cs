using System;
using helloWorld2.Models;

namespace helloWorld2
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Instance of Model
            Computer myComputer = new Computer() {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "RTX 2060"
            };

            Console.WriteLine(myComputer.Motherboard);
            Console.WriteLine(myComputer.HasWifi);
            Console.WriteLine(myComputer.HasLTE);
            Console.WriteLine(myComputer.VideoCard);
        }
    }
}
