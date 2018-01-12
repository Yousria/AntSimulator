using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{
    public class PaireDirection
    {
        [XmlElement("directionAcces")]
        public int direction { get; set; }
        [XmlElement("acces")]
        public AccesAbstrait accesAbstrait { get; set; }

        public PaireDirection(int direction, AccesAbstrait accesAbstrait)
        {
            this.direction = direction;
            this.accesAbstrait = accesAbstrait;

        }
        public PaireDirection()
        {

        }
    }
}
