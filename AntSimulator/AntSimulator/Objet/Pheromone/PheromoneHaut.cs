using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Objet.Pheromone
{
    public class PheromoneHaut : PheromoneActive
    {
        public PheromoneHaut()
        {
            this.direction = (int)FourmiliereConstante.direction.haut;
        }
        public PheromoneHaut(string nom, ZoneAbstraite position, int id) : base(nom, position,id)
        {
            AccesAbstrait acces = null;
            foreach (PaireDirection p in position.AccesAbstraitList)
            {
                if (p.direction == (int)FourmiliereConstante.direction.haut)
                {
                    acces = p.accesAbstrait;
                }
            }
            this.direction = (int)FourmiliereConstante.direction.haut;
        }
    }
}
