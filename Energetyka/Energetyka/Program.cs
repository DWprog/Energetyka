using System;

namespace Energetyka
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string surname;
            bool isClose = false;

            MenuService.ViewMainMenu();
            MenuService.ViewWelcome();

            var userChoice = "";

            while (!isClose)
            {
                MenuService.ViewWelcome();
                MenuService.ViewMainMenu();

                if (string.IsNullOrEmpty(userChoice))
                {
                    userChoice = Console.ReadLine().ToUpper();
                }

                switch (userChoice)
                {
                    case "1":
                        MenuService.ViewWelcome();
                        MenuService.WriteTextColor("Obliczanie bieżącej statystyki dla klienta\n\n", ConsoleColor.Magenta);

                        name = MenuService.GetText("Proszę podać imię klienta: ");
                        surname = MenuService.GetText("Proszę podać nazwisko klienta: ");
                        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
                        {
                            var clientInMemory = new ClientInMemory(name, surname);
                            Console.WriteLine();

                            MenuService.EnterUse(clientInMemory);
                            if (clientInMemory.IsStats())
                            {
                                clientInMemory.ShowStatistics();
                            }
                            else
                            {
                                MenuService.WriteTextColor($"Nie ma żadnych danych o zużyciu dla tego klienta", ConsoleColor.Red);
                            }

                            MenuService.WriteTextColor("\nNaciśnij dowolny klawisz aby wrócić do głównego menu...", ConsoleColor.DarkYellow);
                            Console.ReadKey();
                            userChoice = "";
                        }
                        else
                        {
                            MenuService.WriteTextColor("\nImię i nazwisko klienta nie może być puste!", ConsoleColor.Red);
                            Console.ReadKey();
                            userChoice = "1";
                        }
                        break;

                    case "2":
                        MenuService.ViewWelcome();
                        MenuService.WriteTextColor("Zapisywanie statystyki dla klienta do pliku\n\n", ConsoleColor.Magenta);

                        name = MenuService.GetText("Proszę podać imię klienta: ");
                        surname = MenuService.GetText("Proszę podać nazwisko klienta: ");
                        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
                        {
                            var clientInFile = new ClientInFile(name, surname);
                            clientInFile.SaveClientToList();
                            Console.WriteLine();

                            MenuService.EnterUse(clientInFile);

                            MenuService.WriteTextColor("\nNaciśnij dowolny klawisz aby wrócić do głównego menu...", ConsoleColor.DarkYellow);
                            Console.ReadKey();
                            userChoice = "";
                        }
                        else
                        {
                            MenuService.WriteTextColor("\nImię i nazwisko klienta nie może być puste!", ConsoleColor.Red);
                            Console.ReadKey();
                            userChoice = "2";
                        }
                        break;

                    case "3":
                        MenuService.ViewWelcome();
                        MenuService.WriteTextColor("Odczyt statystyk z pliku\n\n", ConsoleColor.Magenta);

                        MenuService.WriteTextColor("Lista zapisanych klientów:\n", ConsoleColor.DarkGreen);

                        if (ClientInFile.GetClientList())
                        {
                            MenuService.WriteTextColor("Podaj dane klienta do wyświetlenia statystyki\n", ConsoleColor.Cyan);
                            name = MenuService.GetText("Proszę podać imię klienta: ");
                            surname = MenuService.GetText("Proszę podać nazwisko klienta: ");

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
                                    MenuService.WriteTextColor($"Nastąpił wyjątek: {e.Message}\n", ConsoleColor.Red);
                                }
                                MenuService.WriteTextColor("\nNaciśnij dowolny klawisz aby wrócić do głównego menu...", ConsoleColor.DarkYellow);
                                Console.ReadKey();
                                userChoice = "";
                            }
                            else
                            {
                                MenuService.WriteTextColor("\nImię i nazwisko klienta nie może być puste!", ConsoleColor.Red);
                                Console.ReadKey();
                                userChoice = "3";
                            }
                        }
                        break;

                    case "X":
                        MenuService.WriteTextColor("Dziękuję za użytkowanie\n", ConsoleColor.DarkYellow);
                        Console.WriteLine("Aby zakończyć naciśnij dowolny klawisz...");
                        Console.ReadKey();
                        isClose = true;
                        break;

                    default:
                        MenuService.WriteTextColor("Operacja niedozwolona!\n\n", ConsoleColor.Red);
                        Console.ReadKey();
                        userChoice = "";
                        continue;
                }
            }
        }
    }
}
