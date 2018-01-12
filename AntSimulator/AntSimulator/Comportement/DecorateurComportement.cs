using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Comportement
{
    public abstract class DecorateurComportement : ComportementAbstrait
    {
        public ComportementAbstrait comportement;
        public DecorateurComportement() : base()
        {

        }
        public void ajouterComportement(ComportementAbstrait c)
        {
            this.comportement = c;
        }
        public override List<Evenement> executer(PersonnageAbstrait personnage,EnvironnementAbstrait env)
        {
            List<Evenement> evenements = comportement.executer(personnage,env);
            return evenements;

        }
    }
}
