using System;
using System.Runtime.CompilerServices;
using BChat.API.Providers;
using BChat.Data.Model;

namespace BChat.Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            while (option!=3)
            {
                Console.WriteLine("Welcome to BChat Bot");
                Console.WriteLine("Select one of the options and press enter");
                Console.WriteLine("1. Print messages");
                Console.WriteLine("2. Add Default message");
                Console.WriteLine("3. exit");

                var line = Console.ReadLine();

                if (Int32.TryParse(line, out option))
                {
                    switch (option)
                    {
                        case 1:
                        {
                            PrintMessages();
                        } break;
                        case 2:
                        {
                            SendDefaultMessage();
                        } break;
                        case 3:
                        {
                            Console.WriteLine("Finishing app");
                        } break;
                        default:
                        {
                            Console.WriteLine("invalid option");
                        } break;
                            
                    }
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("invalid option");
                }
            }
        }

        public static void PrintMessages()
        {
            var proxy = DefaultProvider.GetDefaultRepository();
            var csvText = proxy.GetCsvMessages();
            Console.WriteLine("CSV response");
            Console.WriteLine(csvText);
        }


        public static void SendDefaultMessage()
        {
            var proxy = DefaultProvider.GetDefaultRepository();
            var csvText = proxy.GetCsvMessages();

            Console.WriteLine(csvText);
            var command = "/stock=APPL.US quote is $93.42 per share";
            var result = proxy.AddMessage(command);
            if (result.Status)
            {
                Console.WriteLine("Message sent successfully!");
            }
            else
            {
                Console.WriteLine("Message sent with errors: " + result.OutputMessage);
            }
        }
    }
}
