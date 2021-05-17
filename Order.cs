using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArtCommsOrderer
{
    class Order
    {
        //attribute, field, variables
        public string Name;
        public string Desc;

        //methods
        public void CreateNewOrder()
        {

            Console.WriteLine("\nSo, you're a client that wants to order an artwork from the artist. Alright!");
            Console.WriteLine("\nFirst, what's your name?");
            Name = Console.ReadLine();
            Console.WriteLine("\nDescribe your order. Include: character desc, scenario, mood, background desc, etc.");
            Desc = Console.ReadLine();


            using (StreamWriter writer = File.AppendText("orders.txt"))
            {
                writer.WriteLine(Name + "\n" + Desc + "\n");
            }
        }

        public virtual void ViewOrders()
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
    }
}
