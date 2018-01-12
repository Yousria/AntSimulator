using AntSimulator.Comportement;
using AntSimulator.Objet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator.Personnage
{
    public class FourmiOuvriere : Fourmi
    {
        
        
        public FourmiOuvriere(string nom, ZoneAbstraite b,int id,EnvironnementAbstrait env) : base(nom, b,id,env)
        {
            nourriturePortee = false;
            this.champDeVision = 10;
            this.pointDeVie = 20;
            this.comportement = new ChercherAManger();

        }
        public FourmiOuvriere() : base()
        {
            nourriturePortee = false;
            this.champDeVision = 10;
            this.pointDeVie = 20;
            this.comportement = new ChercherAManger();
        }
            
    }
}
