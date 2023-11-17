using System;

namespace Energetyka
{
    public class MenuService
    {
        protected static void ViewWelcome()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("    /       ####  #            #       #           / ");
            Console.WriteLine("   /        #     #            #       #          /  ");
            Console.WriteLine("  /         #     #        ###### ### ###        /   ");
            Console.WriteLine(" ////       ####  #       #    #     # #        //// ");
            Console.WriteLine("   /        #     #    ##  ##  #   ### #          /  ");
            Console.WriteLine("  /         #     #          # #  #  # #         /   ");
            Console.WriteLine(" /          ####  ####    ###  ##  ### ##       /    ");
            Console.WriteLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine($"+--------------------------------------------------+");
            Console.WriteLine($"|                Welcome to EL-Stat                |");
            Console.WriteLine($"|   Calculate electricity consumption statistics   |");
            Console.WriteLine($"+--------------------------------------------------+");
            Console.WriteLine("");
            Console.ResetColor();
        }

        protected static void ViewMainMenu()
        {
            Console.WriteLine("Select one of the menu options:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1 - Save the client's power consumption to memory and show statistics");
            Console.WriteLine("2 - Save the customer's power consumption to a file");
            Console.WriteLine("3 - Read statistics of saved customers");
            Console.WriteLine("X - End the program");
            Console.WriteLine();
            Console.ResetColor();
        }

        protected static void EnterUse(IClient client)
        {
            WriteTextColor("To finish, type Q\n\n", ConsoleColor.Cyan);
            while (true)
            {
                var input = GetText("Enter the client's electricity consumption [kWh]: ");
                if (input == "q" || input == "Q")
                {
                    Console.WriteLine();
                    break;
                }

                try
                {
                    client.AddUse(input);
                }
                catch (Exception e)
                {
                    WriteTextColor($"Error: {e.Message}\n",ConsoleColor.Red);
                }
            }
        }

        protected static string GetText(string info, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(info);
            Console.ResetColor();
            var input = Console.ReadLine();
            return input;
        }

        public static void WriteTextColor(string text, ConsoleColor color=ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        protected static void ClientUseAdded(object sender, EventArgs args)
        {
            WriteTextColor("Added consumption\n", ConsoleColor.DarkCyan);
            Console.Beep();
        }

        protected static void ClientAdded(object sender,EventArgs args)
        {
            WriteTextColor("A new client has been added\n", ConsoleColor.DarkRed);
            for (int i = 0; i < 5; i++)
            {
                Console.Beep();
            }
        }
    }
}