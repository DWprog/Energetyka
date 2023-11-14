using static Energetyka.ClientBase;

namespace Energetyka
{
    public interface IClient
    {
        string Name { get; }
        string Surname { get; }

        void AddUse(float use);
        void AddUse(string use);

        event UnitsAddedDelegate UnitsAdded;

        bool IsStats();

        Statistics GetStatistics();
        void ShowStatistics();
    }
}
