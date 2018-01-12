using AntSimulator.Comportement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator.Personnage
{
    [XmlRoot("Oeuf")]
    public class Oeuf : Fourmi
    {
        public int timer { get; set; }
        public int type { get; set; }
        public Oeuf() : base()
        {
            timer = 3;
            this.pointDeVie = 20;
            this.type = (int)FourmiliereConstante.typeFourmie.fourmiOuvriere;
            this.comportement = new ComportementEclore();
        }
        public Oeuf(string nom, ZoneAbstraite position, int id, int type) : base(nom, position,id)
        {
            timer = 3;
            this.pointDeVie = 10;
            this.type = type;
            this.comportement = new ComportementEclore();
        }

    }
}
