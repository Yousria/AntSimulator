using AntSimulator.Comportement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Personnage
{
    public class FourmiChaman : Fourmi
    {
        public FourmiChaman() : base()
        {

        }

        public FourmiChaman(String nom, ZoneAbstraite c, int id, EnvironnementAbstrait env) : base(nom, c, id, env)
        {
            this.comportement = new ComportementChaman();
            this.pointDeVie = 200;
        }
    }
}
