using System;
using System.IO;

namespace ArtCommsOrderer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Art Commissioner!");
            Console.WriteLine("\nThis console application simulates the process of ordering an artwork from an artist.");

            Console.WriteLine("How shall you start conducting your business?");
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Consolefunctions.startMenu();
            }
        }
    }
}
