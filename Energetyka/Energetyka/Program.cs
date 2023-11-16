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
                        WriteTextColor("Obliczanie bieżącej statystyki dla klienta\n\n", ConsoleColor.Magenta);

                        name = GetText("Proszę podać imię klienta: ");
                        surname = GetText("Proszę podać nazwisko klienta: ");
                        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
                        {
                            var clientInMemory = new ClientInMemory(name, surname);
                            clientInMemory.UnitsAdded += ClientUseAdded;
                            Console.WriteLine();

                            EnterUse(clientInMemory);
                            if (clientInMemory.IsStats())
                            {
                                clientInMemory.ShowStatistics();
                            }
                            else
                            {
                                WriteTextColor($"Nie ma żadnych danych o zużyciu dla tego klienta", ConsoleColor.Red);
                            }

                            WriteTextColor("\nNaciśnij dowolny klawisz aby wrócić do głównego menu...", ConsoleColor.DarkYellow);
                            Console.ReadKey();
                            userChoice = "";
                        }
                        else
                        {
                            WriteTextColor("\nImię i nazwisko klienta nie może być puste!", ConsoleColor.Red);
                            Console.ReadKey();
                            userChoice = "1";
                        }
                        break;

                    case "2":
                        ViewWelcome();
                        WriteTextColor("Zapisywanie statystyki dla klienta do pliku\n\n", ConsoleColor.Magenta);

                        name = GetText("Proszę podać imię klienta: ");
                        surname = GetText("Proszę podać nazwisko klienta: ");
                        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
                        {
                            var clientInFile = new ClientInFile(name, surname);
                            clientInFile.ClientAdded += ClientAdded;
                            clientInFile.UnitsAdded += ClientUseAdded;
                            clientInFile.SaveClientToList();
                            Console.WriteLine();

                            EnterUse(clientInFile);

                            WriteTextColor("\nNaciśnij dowolny klawisz aby wrócić do głównego menu...", ConsoleColor.DarkYellow);
                            Console.ReadKey();
                            userChoice = "";
                        }
                        else
                        {
                            WriteTextColor("\nImię i nazwisko klienta nie może być puste!", ConsoleColor.Red);
                            Console.ReadKey();
                            userChoice = "2";
                        }
                        break;

                    case "3":
                        ViewWelcome();
                        WriteTextColor("Odczyt statystyk z pliku\n\n", ConsoleColor.Magenta);

                        WriteTextColor("Lista zapisanych klientów alfabetycznie:\n", ConsoleColor.DarkGreen);

                        if (ClientInFile.GetClientList())
                        {
                            WriteTextColor("Podaj dane klienta do wyświetlenia statystyki\n", ConsoleColor.Cyan);
                            name = GetText("Proszę podać imię klienta: ");
                            surname = GetText("Proszę podać nazwisko klienta: ");

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
                                    WriteTextColor($"Nastąpił wyjątek: {e.Message}\n", ConsoleColor.Red);
                                }
                                WriteTextColor("\nNaciśnij dowolny klawisz aby wrócić do głównego menu...", ConsoleColor.DarkYellow);
                                Console.ReadKey();
                                userChoice = "";
                            }
                            else
                            {
                                WriteTextColor("\nImię i nazwisko klienta nie może być puste!", ConsoleColor.Red);
                                Console.ReadKey();
                                userChoice = "3";
                            }
                        }
                        break;

                    case "X":
                        WriteTextColor("Dziękuję za użytkowanie\n", ConsoleColor.DarkYellow);
                        Console.WriteLine("Aby zakończyć naciśnij dowolny klawisz...");
                        Console.ReadKey();
                        isClose = true;
                        break;

                    default:
                        WriteTextColor("Operacja niedozwolona!\n\n", ConsoleColor.Red);
                        Console.ReadKey();
                        userChoice = "";
                        continue;
                }
            }
        }
    }
}
