using System;
using System.Collections.Generic;
using System.IO;

namespace Energetyka
{
    public class ClientInFile : ClientBase
    {
        private const string fileSufix = "_uses.txt";
        private const string fileClientList = "client_list.txt";

        private string fileName;

        public override event UnitsAddedDelegate UnitsAdded;

        public ClientInFile(string name, string surname)
             : base(name, surname)
        {
            fileName = $"{Surname.ToLower()}_{Name.ToLower()}_{fileSufix}";
        }

        public override void AddUse(float use)
        {
            if (use >= 0)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(use);
                }

                UnitsAdded?.Invoke(this, new EventArgs());
            }
            else
            {
                throw new Exception("Invalid use value");
            }
        }

        public override void ShowUses()
        {
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line is not null)
                    {
                        MenuService.WriteTextColor($"{line}  ", ConsoleColor.Green);
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                throw new Exception($"No data available for this client");
            }
        }

        public override Statistics GetStatistics()
        {
            var stat = new Statistics();

            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line is not null)
                    {
                        var number = float.Parse(line);
                        stat.AddValue(number);
                        line = reader.ReadLine();
                    }
                }
                if (stat.Count == 0)
                {
                    throw new Exception($"The file {fileName} does not contain any data");
                }
            }
            else
            {
                throw new Exception($"No data available for this client");
            }

            return stat;
        }

        public void SaveClientToList()
        {
            bool isExist = false;
            string nameInFile = $"{Surname.ToLower()}_{Name.ToLower()}";

            if (File.Exists(fileClientList))
            {
                using (var reader = File.OpenText(fileClientList))
                {
                    var line = reader.ReadLine();
                    while (line is not null)
                    {
                        if (line == nameInFile)
                        {
                            isExist = true;
                            break;
                        }
                        line = reader.ReadLine();
                    }
                }
            }

            if (!isExist || !File.Exists(fileClientList))
            {
                using (var writer = File.AppendText(fileClientList))
                {
                    writer.WriteLine(nameInFile);
                }
            }
        }

        public static bool GetClientList()
        {
            if (File.Exists(fileClientList))
            {
                using (var reader = File.OpenText(fileClientList))
                {
                    var line = reader.ReadLine();
                    int found = 0;
                    string lineSurname;
                    string lineName;
                    List<string> listOfClient = new();

                    while (line is not null)
                    {
                        found = line.IndexOf('_');
                        lineSurname = line.Substring(0, found);
                        lineSurname = $"{char.ToUpper(lineSurname[0])}{lineSurname.Substring(1, lineSurname.Length - 1)}";
                        lineName = line[(found + 1)..];
                        lineName = $"{char.ToUpper(lineName[0])}{lineName.Substring(1, lineName.Length - 1)}";
                        listOfClient.Add($"{lineSurname} {lineName}");
                        line = reader.ReadLine();
                    }

                    listOfClient.Sort();
                    int n = 1;
                    foreach (var client in listOfClient)
                    {
                        Console.WriteLine($"{n}. {client}");
                        n++;
                    }
                    Console.WriteLine();
                }
                return true;
            }
            else
            {
                MenuService.WriteTextColor("Nie zapisano jeszcze żadnych klientów!\n\n", ConsoleColor.Red);
                return false;
            }
        }
    }
}
