using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArtCommsOrderer
{
    class Client : Order
    {
        //attribute, field, variables
        private string Name;
        private string Desc;

        public string Name1 { get => Name; set => Name = value; }
        public string Desc1 { get => Desc; set => Desc = value; }


        public void ClientLogIn()
        {

            Console.WriteLine("\nSo, you're a client that wants to order an artwork from the artist. Alright!");
            Console.WriteLine("\nFirst, what's your name?");
            Name1 = Console.ReadLine();

            if (File.Exists("clientInvoices.txt"))
            {
                Console.WriteLine("\n" + Name1 + ", you have an invoice!");
            }
            
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = clientMenu();
            }

        }

        public bool clientMenu()
        {
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("\n 1. Create an order \n 2. View your invoices \n 3. Clear invoices \n 4. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    CreateNewOrder();
                    return true;
                case "2":
                    Invoice.ViewInvoices();
                    return true;
                case "3":
                    Console.WriteLine("are you sure you want to clear your invoices? This means you have paid all of them.");
                    bool input = Consolefunctions.Confirm(" ");
                    if (input == true)
                    {
                        Invoice.ClearInvoice();
                        Console.WriteLine("Invoice cleared.");
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                case "4":
                    Console.WriteLine("are you sure you want to exit the client menu?");
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

            Console.WriteLine("\nDescribe your order. Include: character desc, scenario, mood, background desc, etc.");
            Desc1 = Console.ReadLine();


            using (StreamWriter writer = File.AppendText("orders.txt"))
            {
                writer.WriteLine(Name1 + "\n" + Desc1 + "\n");
            }

            Console.WriteLine("\nOrder sucessfully sent to the artist.");
        }

        public override void ViewOrders()
        {

            throw new NotImplementedException();
        }

        public override void ClearFile()
        {
            throw new NotImplementedException();
        }

    }
}
