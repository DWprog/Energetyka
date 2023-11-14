using System;
using System.IO;

namespace Energetyka
{
    public class ClientInFile : ClientBase
    {
        private const string fileSufix = "_uses.txt";

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
                throw new Exception($"The file {fileName} does not exist");
            }

            return stat;
        }

        public override bool IsStats()
        {
            throw new NotImplementedException();
        }
    }
}
