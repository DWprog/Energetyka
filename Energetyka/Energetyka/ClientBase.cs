using System;

namespace Energetyka
{
    public abstract class ClientBase : IClient
    {
        public delegate void UnitsAddedDelegate(object sender, EventArgs args);
        public delegate void ClientAddedDelegate(object sender, EventArgs args);

        public abstract event UnitsAddedDelegate UnitsAdded;
        public abstract event ClientAddedDelegate ClientAdded;

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

        public abstract void ShowUses();

        public abstract Statistics GetStatistics();

        public void ShowStatistics()
        {
            var stat = GetStatistics();
            Console.WriteLine($"Statistics for client: {Name} {Surname}");
            Console.WriteLine();
            Console.Write("Uses [kWh]: ");
            ShowUses();
            Console.WriteLine();
            Console.WriteLine($"Numbe of uses:       {stat.Count}");
            Console.WriteLine($"Total [kWh]:         {stat.Sum}");
            Console.WriteLine();
            Console.WriteLine($"Highest use [kWh]:   {stat.Max}");
            Console.WriteLine($"Lowest use [kWh]:    {stat.Min}");
            Console.WriteLine($"Average use [kWh]:   {stat.Average:F2}");
        }
    }
}
