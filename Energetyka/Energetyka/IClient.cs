﻿using static Energetyka.ClientBase;

namespace Energetyka
{
    public interface IClient
    {
        event UnitsAddedDelegate UnitsAdded;
        event ClientAddedDelegate ClientAdded;
        
        string Name { get; }
        string Surname { get; }

        void AddUse(float use);
        void AddUse(string use);

        void ShowUses();

        Statistics GetStatistics();
        void ShowStatistics();
    }
}
