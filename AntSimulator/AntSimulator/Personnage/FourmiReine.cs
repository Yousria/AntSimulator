using AntSimulator.Comportement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Personnage
{
    public class FourmiReine : Fourmi
    {
        public FourmiReine(string nom, ZoneAbstraite b,int id, EnvironnementAbstrait env) : base(nom, b,id,env)
        {
            this.champDeVision = 0;
            this.pointDeVie = 400;
            this.comportement = new PondreOeufs();
        }
        public FourmiReine() : base()
        {
            this.champDeVision = 0;
            this.pointDeVie = 400;
            this.comportement = new PondreOeufs();
        }
    }
}
