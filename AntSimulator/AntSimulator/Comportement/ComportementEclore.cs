using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntSimulator.Personnage;
using AntSimulator.Fabrique;

namespace AntSimulator.Comportement
{
    public class ComportementEclore : ComportementAbstrait
    {
        public ComportementEclore() : base()
        {

        }
        public override List<Evenement> executer(PersonnageAbstrait personnage, EnvironnementAbstrait env)
        {
            FabriqueAbstraite fabriqueFourmiliere = new FabriqueFourmiliere();
            List<Evenement> evenements = new List<Evenement>();
            if (personnage.GetType() == typeof(Oeuf))
            {
                Oeuf oeuf = (Oeuf)personnage;
                oeuf.timer--;
                if (oeuf.timer == 0)
                {
                    evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.eclore));
                    oeuf.pointDeVie = 0;
                }
            }
            return evenements;
        }
    }
}
