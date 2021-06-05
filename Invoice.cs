using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ArtCommsOrderer
{
    public class Invoice
    {
        private string billTo;
        private string total;
        private int invoiceNum = 0;

        public string BillTo { get => billTo; set => billTo = value; }
        public string Total { get => total; set => total = value; }
        public int InvoiceNum { get => invoiceNum; set => invoiceNum = value; }

        public static void billClient()
        {

            Invoice newInvoice = new Invoice();

            newInvoice.invoiceNum++;

            Console.WriteLine("Which client do you want to bill?");
            Console.WriteLine("Enter client name: ");
            newInvoice.BillTo = Console.ReadLine();

            Console.WriteLine("Bill in: \n1. Rupiah \n2. Dollar");
            newInvoice.Total = currencyFormat();

            DateTime billDate = DateTime.Now;
            DateTime billDue = billDate.AddDays(7);

            using (StreamWriter writer = File.AppendText("clientInvoices.txt"))
            {

                writer.WriteLine("\nINVOICE #" + newInvoice.InvoiceNum);
                writer.WriteLine("BILL TO: " + newInvoice.BillTo);
                writer.WriteLine("DATE:" + billDate);
                writer.WriteLine("DUE DATE:" + billDue);
                writer.WriteLine("TOTAL \t" + newInvoice.Total);
            }

            Console.WriteLine("Invoice sucessuflly sent to the client.");
        }

        private static string currencyFormat()
        {
            string totalPrice;

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Enter total price:");
                    totalPrice = "Rp " + Console.ReadLine();
                    return totalPrice;
                case "2":
                    Console.WriteLine("Enter total price:");
                    totalPrice = "$" + Console.ReadLine();
                    return totalPrice;
                default:
                    Console.WriteLine("Enter total price:");
                    totalPrice = "Rp " + Console.ReadLine();
                    return totalPrice;
            }
        }

        public static void ViewInvoices()
        {
            if (File.Exists("clientInvoices.txt"))
            {
                // Reads file line by line
                StreamReader Textfile = new StreamReader("clientInvoices.txt");
                string line;

                while ((line = Textfile.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

                Textfile.Close();

                Console.ReadKey();
            }
        }

        public static void ClearInvoice()
        {
            if (File.Exists("clientInvoices.txt"))
                File.Delete("clientInvoices.txt");
        }
    }
}
