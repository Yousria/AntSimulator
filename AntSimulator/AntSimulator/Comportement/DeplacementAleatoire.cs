using AntSimulator.Objet;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Comportement
{
    public class DeplacementAleatoire : ComportementAbstrait
    {
        public DeplacementAleatoire() : base()
        {

        }
        public override List<Evenement> executer(PersonnageAbstrait personnage, EnvironnementAbstrait env)
        {
            List<Evenement> evenements = new List<Evenement>();
            ZoneAbstraite position = env.ZoneAbstraiteList[personnage.position.coordonnes.x].zoneAbstraiteList[personnage.position.coordonnes.y];
            if (!position.TousAccesBloque(env))
            {
                
                bool zoneTrouvee = false;
                int rnd = 0;
                Random r = new Random((int)DateTime.Now.Ticks);
                int cpt = 0;
                while (!zoneTrouvee )
                {
                    if(cpt<5)
                        rnd = r.Next(0, 3);
                    if (cpt == 6)
                        rnd = 0;
                    if(cpt == 7)
                        rnd = 1;
                    if(cpt == 8)
                        rnd = 2;
                    if(cpt == 9)
                        rnd = 3;
                    if (position.AccesAbstraitList[rnd] != null && !position.AccesAbstraitList[rnd].accesAbstrait.getFin(env).ZoneBloquee())
                    {
                        zoneTrouvee = true;

                    }
                    cpt++;
                }
                
                personnage.Bouger(position.AccesAbstraitList[rnd].accesAbstrait.getFin(env));
                switch (rnd)
                {
                    case (int)FourmiliereConstante.direction.bas:
                        evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementBas));
                        break;
                    case (int)FourmiliereConstante.direction.haut:
                        evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementHaut));
                        break;
                    case (int)FourmiliereConstante.direction.gauche:
                        evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementGauche));
                        break;
                    case (int)FourmiliereConstante.direction.droite:
                        evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.mouvementDroit));
                        break;
                }
            }
            else
                evenements.Add(new Evenement(personnage, (int)FourmiliereConstante.typeEvenement.passeLeTour));
            if (personnage.GetType().BaseType == typeof(Fourmi))
            {
                if(((Fourmi)personnage).nourriturePortee==false && personnage.GetType() != typeof(FourmiChaman))
                    personnage.comportement = new ChercherAManger();
                else if(personnage.GetType() == typeof(FourmiChaman))
                {
                    personnage.comportement = new ComportementChaman();
                }
                else
                {
                    personnage.comportement = new RentrerFourmiliere();
                }
            }
            return evenements;
        }
    }
}
