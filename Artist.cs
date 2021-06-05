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
        private string ArtistName;

        public string ArtistName1 { get => ArtistName; set => ArtistName = value; }

        public void ArtistLogIn()
        {

            Console.WriteLine("\nSo, you're an artist that recieves the client's orders. Alright!");
            Console.WriteLine("\nFirst, what's your name?");
            ArtistName1 = Console.ReadLine();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = artistMenu();
            }

        }

        public bool artistMenu()
        {
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("\n 1. View your orders \n 2. Clear your orders \n 3. Send invoice \n 4. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("\n {0}'s Current Orders \n", ArtistName1);
                    ViewOrders();
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
                    Invoice.billClient();
                    return true;
                case "4":
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

        //Order methods 

        public override void CreateNewOrder()
        {
            throw new NotImplementedException();
        }

        public override void ViewOrders()
        {
            if (File.Exists("orders.txt"))
            {
                // Reads file line by line
                StreamReader Textfile = new StreamReader("orders.txt");
                string line;

                while ((line = Textfile.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

                Textfile.Close();

                Console.ReadKey();
            }
        }

        public override void ClearFile()
        {
            if (!File.Exists("orders.txt"))
                File.Create("orders.txt");

            TextWriter tw = new StreamWriter("orders.txt", false);
            tw.Write(string.Empty);
            tw.Close();
        }
    }
}
