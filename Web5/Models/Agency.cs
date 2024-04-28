using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web5.Models
{
    public class Agency
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public ICollection<Hotel> Hotels { get; set; }

        public ICollection<Transport> Transports { get; set; }
    }

}
