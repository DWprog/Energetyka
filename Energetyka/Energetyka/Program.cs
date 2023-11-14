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


            var userChoice = "";// = Console.ReadLine().ToUpper();

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
                            break;
                        }
                        else
                        {
                            MenuService.WriteTextColor("\nImię i nazwisko klienta nie może być puste!", ConsoleColor.Red);
                            Console.ReadKey();
                            userChoice = "1";
                            break;
                        }
                    //pokaż menu
                    //break;

                    case "2":
                        break;

                    case "3":
                        //reset ekranu części dolnej
                        //nowe menu ?
                        //if ()
                        //{

                        //}


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
