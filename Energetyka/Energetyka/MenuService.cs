using System;

namespace Energetyka
{
    public class MenuService
    {
        public static void ViewWelcome()
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
            Console.WriteLine($"|             Witaj w programie EL-Stat            |");
            Console.WriteLine($"|          Oblicz statystykę zużycia prądu         |");
            Console.WriteLine($"+--------------------------------------------------+");
            Console.WriteLine("");
            Console.ResetColor();
        }

        public static void ViewMainMenu()
        {
            Console.WriteLine("Wybież jedną z opcji menu:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("1 - Zapisz zużycie prądu klienta do pamięci i pokaż statystyki");
            Console.WriteLine("2 - Zapisz zużycie prądu klienta do pliku");
            Console.WriteLine("3 - Odczytaj statystyki zapisanych klientów");
            Console.WriteLine("X - Zakończ program");
            Console.WriteLine();
            Console.ResetColor();
        }

        public static void EnterUse(IClient client)
        {
            WriteTextColor("Aby zakończyć wpisz Q\n\n", ConsoleColor.Cyan);
            while (true)
            {
                var input = GetText("Podaj zużycie [kWh]: ");
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
                    WriteTextColor($"Wystąpił wyjątek: {e.Message}\n",ConsoleColor.Red);
                }
            }
        }

        public static string GetText(string info, ConsoleColor color = ConsoleColor.Gray)
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
    }
}