using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{

    public class Coordonnees
    {
        [XmlElement("coordonneeX")]
        public int x { get; set; }
        [XmlElement("coordonneeY")]
        public int y { get; set; }

        private static Random r;

        public Coordonnees(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Coordonnees()
        {
            if (r == null)
                r = new Random();
            this.x = r.Next(0, 100);
            this.y = r.Next(0, 100);
        }

        public Boolean equals(Coordonnees c)
        {
            if(this.x == c.x && this.y == c.y)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
