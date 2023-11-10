using static Energetyka.ClientBase;

namespace Energetyka
{
    public interface IClient
    {
        string Name { get; }
        string Surname { get; }
        float Declaration { get; set; }
        float Limit { get; set; }

        void AddUnits(float units);
        void AddUnits(double units);
        void AddUnits(int units);
        void AddUnits(string units);
    }
}
