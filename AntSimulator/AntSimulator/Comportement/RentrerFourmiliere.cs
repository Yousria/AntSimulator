using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntSimulator.Personnage;
using AntSimulator.Objet.Pheromone;

namespace AntSimulator.Comportement
{
    public class RentrerFourmiliere : ComportementAbstrait
    {
        public RentrerFourmiliere() : base()
        {

        }
        public override List<Evenement> executer(PersonnageAbstrait personnage, EnvironnementAbstrait env)
        {
            List<Evenement> evenements = new List<Evenement>();
                     
            if (personnage.position.coordonnes.x < FourmiliereConstante.fourmiliere.x)
            {
                ZoneAbstraite pos = env.ZoneAbstraiteList[personnage.position.coordonnes.x].zoneAbstraiteList[personnage.position.coordonnes.y].AccesAbstraitList[(int)FourmiliereConstante.direction.droite].accesAbstrait.getFin(env);
                if (!pos.ZoneBloquee())
                {
                    personnage.Bouger(pos);
                    env.ZoneAbstraiteList[pos.coordonnes.x].zoneAbstraiteList[pos.coordonnes.y].AjouteObjet(new PheromoneGauche());
                    evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementDroit));
                }
                
            }
            else if (personnage.position.coordonnes.x > FourmiliereConstante.fourmiliere.x)
            {
                ZoneAbstraite pos = env.ZoneAbstraiteList[personnage.position.coordonnes.x].zoneAbstraiteList[personnage.position.coordonnes.y].AccesAbstraitList[(int)FourmiliereConstante.direction.gauche].accesAbstrait.getFin(env);
                if (!pos.ZoneBloquee())
                {
                    personnage.Bouger(pos);
                    env.ZoneAbstraiteList[pos.coordonnes.x].zoneAbstraiteList[pos.coordonnes.y].AjouteObjet(new PheromoneDroite());
                    evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementGauche));
                }
                
            }
            else if (personnage.position.coordonnes.y < FourmiliereConstante.fourmiliere.y)
            {
                //haut
                ZoneAbstraite pos = env.ZoneAbstraiteList[personnage.position.coordonnes.x].zoneAbstraiteList[personnage.position.coordonnes.y].AccesAbstraitList[(int)FourmiliereConstante.direction.haut].accesAbstrait.getFin(env);
                if (!pos.ZoneBloquee())
                {
                    personnage.Bouger(pos);
                    env.ZoneAbstraiteList[pos.coordonnes.x].zoneAbstraiteList[pos.coordonnes.y].AjouteObjet(new PheromoneBas());
                    evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementHaut));
                }
                
            }
            else if (personnage.position.coordonnes.y > FourmiliereConstante.fourmiliere.y)
            {
                ZoneAbstraite pos = env.ZoneAbstraiteList[personnage.position.coordonnes.x].zoneAbstraiteList[personnage.position.coordonnes.y].AccesAbstraitList[(int)FourmiliereConstante.direction.bas].accesAbstrait.getFin(env);
                if (!pos.ZoneBloquee())
                {
                    personnage.Bouger(pos);
                    env.ZoneAbstraiteList[pos.coordonnes.x].zoneAbstraiteList[pos.coordonnes.y].AjouteObjet(new PheromoneHaut());
                    evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementBas));
                }
              
            }

            if (personnage.position.coordonnes.equals(FourmiliereConstante.fourmiliere)&&((Fourmi)personnage).nourriturePortee==true)
            {
                evenements.Add(depotNourriture(personnage,env));
                ((Fourmi)personnage).nourriturePortee = false;
                personnage.comportement = new ChercherAManger();
                env.fourmiliere.valeurNutritiveTotalFourmiliere++;

            }
            return evenements;

        }

        public Evenement depotNourriture(PersonnageAbstrait personnage,EnvironnementAbstrait env)
        {
            
            if (personnage.GetType() == typeof(Fourmi))
            {
                ((Fourmi)personnage).nourriturePortee = false;
                personnage.comportement = new ChercherAManger();
                //env.fourmiliere.valeurNutritiveTotalFourmiliere++;
              
            }
            return new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.passeLeTour);

        }
    }
}
