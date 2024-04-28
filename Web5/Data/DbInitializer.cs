using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web5.Models;

namespace Web5.Data
{
    public class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Humans.Any())
            {
                return;   // DB has been seeded
            }

            var humans = new Human[]
            {
            new Human{Name="Carson", Age=18},
            new Human{Name="Anderson", Age=19},
            new Human{Name="Odinson", Age=20},
            new Human{Name="Smith", Age=15},
            new Human{Name="Derreck", Age=27}
            };
            foreach (Human s in humans)
            {
                context.Humans.Add(s);
            }
            context.SaveChanges();

            var countries = new Country[]
            {
            new Country{Name="Austria",Population=30000000},
            new Country{Name="Australia",Population=0},
            new Country{Name="Russia",Population=146000000},
            new Country{Name="Ghana",Population=7800},
            new Country{Name="SaudArabia",Population=6545165}

            };
            foreach (Country c in countries)
            {
                context.Countries.Add(c);
            }
            context.SaveChanges();

            var agencies = new Agency[]
            {
            new Agency{Name="1050",Rating=0},
            new Agency{Name="Pegas",Rating=10},
            new Agency{Name="Feres",Rating=7},
            new Agency{Name="t0ur.com",Rating=8},
            new Agency{Name="Turk",Rating=2},
            new Agency{Name="Derek",Rating=3},

            };
            foreach (Agency e in agencies)
            {
                context.Agencies.Add(e);
            }
            context.SaveChanges();
        }
    }
}
