using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDA_Cyber_Security_Simulator_V1
{
    public class Language
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Language(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
