using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntSimulator.Personnage;
using AntSimulator.Fabrique;

namespace AntSimulator.Comportement
{
    public class PondreOeufs : ComportementAbstrait
    {
        public PondreOeufs() : base()
        {

        }

        public override List<Evenement> executer(PersonnageAbstrait personnage, EnvironnementAbstrait env)
        {
            FabriqueAbstraite fabriqueFourmiliere = new FabriqueFourmiliere();
            List<Evenement> evenements = new List<Evenement>();
            if (env.fourmiliere.valeurNutritiveTotalFourmiliere >= 2)
            {
                Console.Write("Ponte oeuf/n");
                Random r = new Random((int)DateTime.Now.Ticks);
                int rnd = r.Next((int)FourmiliereConstante.typeFourmie.oeufFourmiOuvriere,(int)FourmiliereConstante.typeFourmie.oeufFourmiChaman);
               
                env.AjouterPersonnage(fabriqueFourmiliere.creerPersonnage("oeuf" + FabriqueFourmiliere.id, rnd, env.fourmiliere.position, env));
                evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.pondreOeuf));
                env.fourmiliere.valeurNutritiveTotalFourmiliere -= 2;
            }
            return evenements;
        }
    }
}
