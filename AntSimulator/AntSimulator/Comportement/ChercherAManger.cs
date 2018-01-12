using AntSimulator.Objet;
using AntSimulator.Objet.Pheromone;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Comportement
{
    public class ChercherAManger : ComportementAbstrait
    {
        public ChercherAManger() : base()
        {

        }   
        public override List<Evenement> executer(PersonnageAbstrait personnage,EnvironnementAbstrait env)
        {
            List<Evenement> evenements = new List<Evenement>();
            ZoneAbstraite zoneOuAller = ((Fourmi)personnage).AnalyserSituation(env);
            if (zoneOuAller == null)
            {
                personnage.comportement = new DeplacementAleatoire();
                evenements.AddRange(personnage.executerComportement(env));
            }
            else
            {
                
                    int diffX = personnage.position.coordonnes.x - zoneOuAller.coordonnes.x;
                    int diffY = personnage.position.coordonnes.y - zoneOuAller.coordonnes.y;
                    if (diffX < 0)
                    {
                        //droite
                        ZoneAbstraite pos = env.ZoneAbstraiteList[personnage.position.coordonnes.x].zoneAbstraiteList[personnage.position.coordonnes.y].AccesAbstraitList[(int)FourmiliereConstante.direction.droite].accesAbstrait.getFin(env);
                        if (!pos.ZoneBloquee())
                        {
                            personnage.Bouger(pos);
                            evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementDroit));
                        }
                        else
                        {
                            personnage.comportement = new DeplacementAleatoire();
                            evenements.AddRange(personnage.executerComportement(env));
                        }
                    }
                    else if (diffX > 0)
                    {
                        ZoneAbstraite pos = env.ZoneAbstraiteList[personnage.position.coordonnes.x].zoneAbstraiteList[personnage.position.coordonnes.y].AccesAbstraitList[(int)FourmiliereConstante.direction.gauche].accesAbstrait.getFin(env);
                        if (!pos.ZoneBloquee())
                        {
                            personnage.Bouger(pos);
                            evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementGauche));
                        }
                        else
                        {
                            personnage.comportement = new DeplacementAleatoire();
                            evenements.AddRange(personnage.executerComportement(env));
                        };
                    }
                    else if (diffY < 0)
                    {
                        ZoneAbstraite pos = env.ZoneAbstraiteList[personnage.position.coordonnes.x].zoneAbstraiteList[personnage.position.coordonnes.y].AccesAbstraitList[(int)FourmiliereConstante.direction.haut].accesAbstrait.getFin(env);
                        if (!pos.ZoneBloquee())
                        {
                            personnage.Bouger(pos);
                            evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementHaut));
                        }
                        else
                        {
                            personnage.comportement = new DeplacementAleatoire();
                            evenements.AddRange(personnage.executerComportement(env));
                        }
                    }
                    else if (diffY > 0)
                    {
                        ZoneAbstraite pos = env.ZoneAbstraiteList[personnage.position.coordonnes.x].zoneAbstraiteList[personnage.position.coordonnes.y].AccesAbstraitList[(int)FourmiliereConstante.direction.bas].accesAbstrait.getFin(env);
                        if (!pos.ZoneBloquee())
                        {
                            personnage.Bouger(pos);
                            evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementBas));
                        }
                        else
                        {
                            personnage.comportement = new DeplacementAleatoire();
                            evenements.AddRange(personnage.executerComportement(env));
                        }
                    }


                }
            
            return evenements;

        }

        
        
       

    }
}
