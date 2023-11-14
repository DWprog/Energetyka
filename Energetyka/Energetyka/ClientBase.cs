using System;

namespace Energetyka
{
    public abstract class ClientBase : IClient
    {
        public delegate void UnitsAddedDelegate(object sender, EventArgs args);

        public abstract event UnitsAddedDelegate UnitsAdded;

        public string Name { get; private set; }
        public string Surname { get; private set; }

        public ClientBase(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public abstract void AddUse(float use);
        public void AddUse(string use)
        {
            if (float.TryParse(use, out float result))
            {
                AddUse(result);
            }
            else
            {
                throw new Exception("String is not float");
            }
        }

        public abstract bool IsStats();

        public abstract Statistics GetStatistics();

        public void ShowStatistics()
        {
            var stat = GetStatistics();
            //ShowGrades();
            Console.WriteLine($"Statystyki dla: {Name} {Surname}");
            Console.WriteLine();
            Console.WriteLine($"Ilość odczytów:             {stat.Count}");
            Console.WriteLine($"Najwyższe zużycie [kWh]:    {stat.Max}");
            Console.WriteLine($"Najniższe zużycie [kWh]:    {stat.Min}");
            Console.WriteLine($"Średnie zużycie [kWh]:      {stat.Average:N2}");
            Console.WriteLine();
            Console.WriteLine("Przekroczenia");
        }
    }
}
