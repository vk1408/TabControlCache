using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabControlCache.Model
{
    public class Device
    {
        public Device(int number, string name, string description)
        {
            Number = number;
            Name = name;
            Description = description;
        }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
    }
}
