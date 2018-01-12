using AntSimulator.Comportement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Personnage
{
    public class FourmiGuerriere : Fourmi
    {
        public FourmiGuerriere(string nom, ZoneAbstraite b,int id,EnvironnementAbstrait env) : base(nom, b,id,env)
        {
            this.champDeVision = 4;
            this.pointDeVie = 100;
            this.comportement = new ChercherAManger();
        }
        public FourmiGuerriere() : base()
        {
            this.comportement = new ChercherAManger();
            this.champDeVision = 4;
            this.pointDeVie = 100;
        }
    }
}
