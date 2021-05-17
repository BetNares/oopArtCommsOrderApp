using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArtCommsOrderer
{
    class Artist : Order
    {
        //attribute, field, variables
        public string ArtistName;

        public void ArtistLogIn()
        {

            Console.WriteLine("\nSo, you're an artist that recieves the client's orders. Alright!");
            Console.WriteLine("\nFirst, what's your name?");
            ArtistName = Console.ReadLine();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = artistMenu();
            }

        }

        public bool artistMenu()
        {
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("\n 1. View your orders \n 2. Clear your orders \n 3. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    Artist newArtist = new Artist();
                    Console.WriteLine("\n {0}'s Current Orders \n", ArtistName);
                    newArtist.ViewOrders();
                    return true;
                case "2":
                    Console.WriteLine("are you sure you want to delete all current orders?");
                    bool input = Consolefunctions.Confirm(" ");
                    if (input == true)
                    {
                        ClearFile();
                        Console.WriteLine("Orders cleared.");
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                case "3":
                    Console.WriteLine("are you sure you want to exit the artist menu?");
                    bool input2 = Consolefunctions.Confirm(" ");
                    if (input2 == true)
                    {
                        Console.WriteLine("");
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

        private void ClearFile()
        {
            if (!File.Exists("orders.txt"))
                File.Create("orders.txt");

            TextWriter tw = new StreamWriter("orders.txt", false);
            tw.Write(string.Empty);
            tw.Close();
        }
    }
}
