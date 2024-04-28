using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web5.Models
{
    public class Human
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public ICollection<Agency> Agencys { get; set; }

        public ICollection<Country> Countrys { get; set; }
    }

}
