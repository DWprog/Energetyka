﻿using System;
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

        public ClientInMemory(string name, string surname, float declaration, float limit)
            : base(name, surname, declaration, limit)
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

        public override bool IsStats()
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