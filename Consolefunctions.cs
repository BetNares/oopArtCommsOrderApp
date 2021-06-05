using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtCommsOrderer
{
    class Consolefunctions
    {
        public static bool startMenu()
        {

            Console.WriteLine("\n 1. I am a client \n 2. I am the artist \n 3. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    Client newClient = new Client();
                    newClient.ClientLogIn();
                    return true;
                case "2":
                    Artist newArtist = new Artist();
                    newArtist.ArtistLogIn();
                    return true;
                case "3":
                    Console.WriteLine("are you sure you want to exit?");
                    bool input = Consolefunctions.Confirm(" ");
                    if (input == true)
                    {
                        Console.WriteLine("Goodbye!");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                default:
                    return true;
            }
        }


        public static bool Confirm(string title)
        {
            ConsoleKey response;
            do
            {
                Console.Write($"{ title } [y/n] ");
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                {
                    Console.WriteLine();
                }
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            return (response == ConsoleKey.Y);
        }

    }
}
