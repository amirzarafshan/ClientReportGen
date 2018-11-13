using System.Collections.Generic;
using System.IO;

namespace ClientScripts.Models
{
    public class Client
    {
        public string Name { get; set; }

        public Client(string name)
        {
            Name = name;
        }

        public static List<Client> ReadClientsFromText(string file)
        {
            var units = new List<Client>();

            foreach(var unit in File.ReadAllLines(file))
                units.Add(new Client(unit.Trim()));

            return units;   
        }
    }

}
