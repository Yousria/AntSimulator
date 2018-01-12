using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Objet.Pheromone
{
   public class PheromoneInactive : PheromoneAbstraite
    {
        public PheromoneInactive()
        {
            this.activePheromone = false;
        }
        public PheromoneInactive(string nom, ZoneAbstraite position, int id) : base(nom, position, id)
        {
            this.activePheromone = false;
        }
    }
}
