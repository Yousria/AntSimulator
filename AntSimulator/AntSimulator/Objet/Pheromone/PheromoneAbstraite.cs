using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator.Objet
{
    [XmlRoot("Pheromone")]
    public abstract class PheromoneAbstraite : ObjetAbstrait
    {
        public bool activePheromone;

        public PheromoneAbstraite()
        {

        }
        public PheromoneAbstraite(string nom,ZoneAbstraite position, int id) : base(nom, position,id)
        {
            
        }

    }
}
