using System;
using System.Collections.Generic;
using System.Linq;

namespace Energetyka
{
    public class ClientInMemory : ClientBase
    {
        public override event UnitsAddedDelegate UnitsAdded;

        private readonly List<float> uses = new();

        public ClientInMemory(string name, string surname)
            : base(name, surname)
        {
        }

        public override void AddUse(float use)
        {
            if (use >= 0)
            {
                uses.Add(use);
                UnitsAdded?.Invoke(this, new EventArgs());
            }
            else
            {
                throw new Exception("Invalid use value");
            }
        }
        public override void ShowUses()
        {
            foreach (var use in uses)
            {
                MenuService.WriteTextColor($"{use}  ", ConsoleColor.Green);
            }
            Console.WriteLine();
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var use in uses)
            {
                statistics.AddValue(use);
            }

            if (statistics.Count == 0)
            {
                throw new Exception($"There is no consumption for this client yet");
            }

            return statistics;
        }

        public bool IsStats()
        {
            if (uses.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
