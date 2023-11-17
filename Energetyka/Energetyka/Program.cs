using System;

namespace Energetyka
{
    class Program : MenuService
    {
        static void Main(string[] args)
        {
            string name;
            string surname;
            bool isClose = false;

            ViewMainMenu();
            ViewWelcome();

            var userChoice = "";

            while (!isClose)
            {
                ViewWelcome();
                ViewMainMenu();

                if (string.IsNullOrEmpty(userChoice))
                {
                    userChoice = Console.ReadLine().ToUpper();
                }

                switch (userChoice)
                {
                    case "1":
                        ViewWelcome();
                        WriteTextColor("Calculating current statistics for the client\n\n", ConsoleColor.Magenta);

                        name = GetText("Please enter client's first name: ");
                        surname = GetText("Please enter client's last name: ");
                        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
                        {
                            var clientInMemory = new ClientInMemory(name, surname);
                            clientInMemory.UnitsAdded += ClientUseAdded;
                            Console.WriteLine();

                            EnterUse(clientInMemory);
                            if (clientInMemory.IsStat())
                            {
                                clientInMemory.ShowStatistics();
                            }
                            else
                            {
                                WriteTextColor($"Brak danych o użytkowaniu dla tego klienta", ConsoleColor.Red);
                            }

                            WriteTextColor("\nPress any key to return to the main menu...", ConsoleColor.DarkYellow);
                            Console.ReadKey();
                            userChoice = "";
                        }
                        else
                        {
                            WriteTextColor("\nThe client's name and surname cannot be empty!", ConsoleColor.Red);
                            Console.ReadKey();
                            userChoice = "1";
                        }
                        break;

                    case "2":
                        ViewWelcome();
                        WriteTextColor("Saving client electricity consumption to a file\n\n", ConsoleColor.Magenta);

                        name = GetText("Please enter client's first name: ");
                        surname = GetText("Please enter client's last name: ");
                        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
                        {
                            var clientInFile = new ClientInFile(name, surname);
                            clientInFile.ClientAdded += ClientAdded;
                            clientInFile.UnitsAdded += ClientUseAdded;
                            clientInFile.SaveClientToList();
                            Console.WriteLine();

                            EnterUse(clientInFile);

                            WriteTextColor("\nPress any key to return to the main menu...", ConsoleColor.DarkYellow);
                            Console.ReadKey();
                            userChoice = "";
                        }
                        else
                        {
                            WriteTextColor("\nThe client's name and surname cannot be empty!", ConsoleColor.Red);
                            Console.ReadKey();
                            userChoice = "2";
                        }
                        break;

                    case "3":
                        ViewWelcome();
                        WriteTextColor("Reading client statistics from a file\n\n", ConsoleColor.Magenta);

                        WriteTextColor("List of clients alphabetically:\n", ConsoleColor.DarkGreen);

                        if (ClientInFile.GetClientList())
                        {
                            WriteTextColor("Provide client details to display statistics\n", ConsoleColor.Cyan);
                            name = GetText("Please enter client's first name: ");
                            surname = GetText("Please enter client's last name: ");
                            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
                            {
                                var clientInFile = new ClientInFile(name, surname);
                                Console.WriteLine();
                                try
                                {
                                    clientInFile.ShowStatistics();
                                }
                                catch (Exception e)
                                {
                                    WriteTextColor($"Error: {e.Message}\n", ConsoleColor.Red);
                                }
                                WriteTextColor("\nPress any key to return to the main menu...", ConsoleColor.DarkYellow);
                                Console.ReadKey();
                                userChoice = "";
                            }
                            else
                            {
                                WriteTextColor("\nThe client's name and surname cannot be empty!", ConsoleColor.Red);
                                Console.ReadKey();
                                userChoice = "3";
                            }
                        }
                        break;

                    case "X":
                        WriteTextColor("Thank you for using\n", ConsoleColor.DarkYellow);
                        Console.WriteLine("To finish, press any key...");
                        Console.ReadKey();
                        isClose = true;
                        break;

                    default:
                        WriteTextColor("Operation not allowed!\n\n", ConsoleColor.Red);
                        Console.ReadKey();
                        userChoice = "";
                        continue;
                }
            }
        }
    }
}
