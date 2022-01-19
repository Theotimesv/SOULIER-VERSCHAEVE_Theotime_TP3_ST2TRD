using System;
using System.Data;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading;
using TP3;

namespace TP3Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise 1
            Console.WriteLine("\n-------Exercise 1-------");
            Exercise1 ex1 = new Exercise1();
            ex1.launch();
            
            //Exercise 2
            Console.WriteLine("\n-------Exercise 2-------");
            Exercise2 ex2 = new Exercise2();
            ex2.launch();
        }
    }
}