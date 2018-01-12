using AntSimulator.Objet;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Comportement
{
    public class SuivrePheromone : ComportementAbstrait
    {
        public SuivrePheromone() : base()
        {

        }
        public override List<Evenement> executer(PersonnageAbstrait personnage, EnvironnementAbstrait env)
        {
            List<Evenement> evenements = new List<Evenement>();
            if (((Fourmi)personnage).nourriturePortee == true)
            {
                personnage.comportement = new RentrerFourmiliere();
                return evenements;
            }
            if (env.ZoneAbstraiteList[personnage.position.coordonnes.x].zoneAbstraiteList[personnage.position.coordonnes.y].containsObjet(typeof(Nourriture),env)) {
                Console.WriteLine("out");
                if (personnage.GetType().BaseType == typeof(Fourmi))
                {
                    Fourmi f = (Fourmi)personnage;

                    f.nourriturePortee = true;
                    env.ZoneAbstraiteList[personnage.position.coordonnes.x].zoneAbstraiteList[personnage.position.coordonnes.y].getNourriture(env).valeurNutritive--;
                    

                }
                if (env.ZoneAbstraiteList[personnage.position.coordonnes.x].zoneAbstraiteList[personnage.position.coordonnes.y].containsObjet(typeof(Nourriture),env))
                    personnage.comportement = new RentrerFourmiliere();
                else
                {
                    DecorateurSupprimerPheromone deco = new DecorateurSupprimerPheromone();
                    deco.ajouterComportement(new RentrerFourmiliere());
                    personnage.comportement = deco;
                }
                evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.passeLeTour));
            }

            else
            { 
                ZoneAbstraite zone = env.ZoneAbstraiteList[personnage.position.coordonnes.x].zoneAbstraiteList[personnage.position.coordonnes.y];
                
                if (zone.getPheromone()!=null && !zone.AccesAbstraitList[zone.getPheromone().direction]
                    .accesAbstrait.getFin(env).ZoneBloquee())
                    personnage.Bouger(
                     zone.AccesAbstraitList[zone.getPheromone().direction]
                         .accesAbstrait.getFin(env));
                else
                {
                    personnage.comportement = new DeplacementAleatoire();
                    personnage.comportement.executer(personnage,env);
                }
                if(zone.getPheromone() != null){
                    switch (zone.getPheromone().direction)
                    {
                        case ((int)FourmiliereConstante.direction.bas):
                            {
                                evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementBas));
                                break;
                            }

                        case ((int)FourmiliereConstante.direction.haut):
                            {
                                evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementHaut));
                                break;
                            }
                        case ((int)FourmiliereConstante.direction.gauche):
                            {
                                evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementGauche));
                                break;
                            }
                        case ((int)FourmiliereConstante.direction.droite):
                            {
                                evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementDroit));
                                break;
                            }

                    }
                }
            }


           return evenements;
        }
    }
}
