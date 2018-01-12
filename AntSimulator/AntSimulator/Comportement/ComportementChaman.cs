using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Comportement
{
    public class ComportementChaman : DecorateurComportement
    {
        public ComportementChaman() : base()
        {
            this.ajouterComportement(new DeplacementAleatoire());
        }

        public override List<Evenement> executer(PersonnageAbstrait personnage, EnvironnementAbstrait env)
        {
            List<Evenement> evenements = comportement.executer(personnage, env);
            ZoneAbstraite newPosition = personnage.position;
            List<PersonnageAbstrait> listeFourmi = newPosition.ListeFourmiAlentours(env);
            foreach(PersonnageAbstrait f in listeFourmi)
            {
                Fourmi fourmi = (Fourmi)f;
                f.pointDeVie++;
            }
            return evenements;

        }



    }
}
