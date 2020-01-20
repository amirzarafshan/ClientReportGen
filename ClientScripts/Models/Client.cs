using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            return File.ReadAllLines(file).Select(unit => new Client(unit.Trim())).ToList();
        }
    }

}
