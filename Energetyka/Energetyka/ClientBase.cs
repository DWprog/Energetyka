using System;

namespace Energetyka
{
    public abstract class ClientBase : IClient
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public float Declaration { get; set; }
        public float Limit { get; set; }

        public ClientBase(string name,string surname)
        {
            Name = name;
            Surname = surname;
        }

        public ClientBase(string name,string surname,float declaration=0,float limit=0)
        {
            Name = name;
            Surname = surname;
            Declaration = declaration;
            Limit = limit;
        }

        public abstract void AddUnits(float units);
        public abstract void AddUnits(double units);
        public abstract void AddUnits(int units);
        public abstract void AddUnits(string units);
    }
}
