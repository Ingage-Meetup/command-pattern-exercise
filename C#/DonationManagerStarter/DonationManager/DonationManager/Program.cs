using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DonationManager;

namespace DonationManager
{
    public  class Program
    {
        private static DonationManager _donationManager { get; set; }
        public static void Main(string[] args)
        {
            InitializeDataStore();
            PrintStartMessage();
            RunCommandLoop();
            HoldConsoleWindowOpen();
        }

        private static void HoldConsoleWindowOpen()
        {
            Thread.Sleep(5000);
        }

        private static void PrintStartMessage()
        {
            Console.WriteLine("***********************************************************");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("*                   Donation Manager                      *");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("***********************************************************");
            Console.WriteLine("***********************************************************");
        }

        private static void RunCommandLoop()
        {
            string input = null;
            Console.WriteLine();
            bool notDone = true;
            do
            {
                Console.Clear();
                DisplayMenu();
                input = Console.ReadLine();
                if (InputIsValid(input))
                {
                    notDone = DispatchCommand(input);
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                    Thread.Sleep(1000);
                }
            } while (notDone);
            Console.WriteLine("Bye-bye!");
        }

        private static bool DispatchCommand(string input)
        {
            if (input == "9")
            {
                return false;
            }
            else
            {
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Add a donor");
                        break;
                    case "2":
                        Console.WriteLine("Add a donation");
                        break;
                    case "3":
                        Console.WriteLine("Reverse a donor");
                        break;
                    case "4":
                        Console.WriteLine("Print donors");
                        break;
                    case "5":
                        Console.WriteLine("Print total donated");
                        break;
                    case "6":
                        Console.WriteLine("Stage donations");
                        break;
                    case "7":
                        Console.WriteLine("Process staged donations");
                        break;
                    case "8":
                        Console.WriteLine("Reverse staged donations");
                        break;
                }
                Thread.Sleep(5000);
                return true;
            }
        }

        private static bool InputIsValid(string input)
        {
            try
            {
                int num;
                var command = int.TryParse(input, out num);
                if (command && num >= 1 && num <= 9)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t1. Add a donor");
            Console.WriteLine("\t2. Add a donation.Adding a donation will update the amount given in that person's donor record");
            Console.WriteLine("\t3. Reverse a donation.This command removes the last donation for a donor and updates that donor's total");
            Console.WriteLine("\t4. Print donors");
            Console.WriteLine("\t5. Print total amount donated");
            Console.WriteLine("\t6. Stage donations");
            Console.WriteLine("\t7. Process staged donations");
            Console.WriteLine("\t8. Reverse staged donations");
            Console.WriteLine("\t9. Exit the application");
            Console.WriteLine();
            Console.Write("\tPlease enter a digit (1-9): ");
        }

        private static void InitializeDataStore()
        {
            _donationManager = new DonationManager();
        }
    }
}
