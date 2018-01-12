using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{
    [XmlRoot("Chemin")]
    public class Chemin : AccesAbstrait
    {
        public Chemin(Coordonnees debut, Coordonnees fin) : base(debut, fin)
        {

        }
        public Chemin() : base()
        {

        }
    }
}
