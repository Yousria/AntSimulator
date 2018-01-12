using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Objet.Pheromone
{
    public abstract class PheromoneActive : PheromoneAbstraite
    {
        public int direction;
        
        public PheromoneActive()
        {
            this.activePheromone = true;
        }
        public PheromoneActive(string nom, ZoneAbstraite position, int id) : base(nom, position,id)
        {
            this.activePheromone = true;
        }

    }
}
