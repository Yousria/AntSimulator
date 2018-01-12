using AntSimulator.Objet;
using AntSimulator.Objet.Pheromone;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Fabrique
{
    public class FabriqueFourmiliere : FabriqueAbstraite
    {
        
        public override string Titre
        {
            get
            {
                return Titre;
            }
        }

        public override AccesAbstrait creerAcces(ZoneAbstraite debut, ZoneAbstraite fin)
        {
            throw new NotImplementedException();
        }

        public override EnvironnementAbstrait creerEnvironnement()
        {
            return this.env;
        }

        public override ObjetAbstrait creerObjet(string nom, int TypeObjet, ZoneAbstraite position, EnvironnementAbstrait env)
        {
            id++;
            switch (TypeObjet)
            {
                case (int)FourmiliereConstante.typeObjectAbstrait.nourriture:
                    {
                        Nourriture n =new Nourriture(nom, position, id);
                        env.ZoneAbstraiteList[position.coordonnes.x].zoneAbstraiteList[position.coordonnes.y].AjouteObjet(n);
                        return n;
                    }

                case (int)FourmiliereConstante.typeObjectAbstrait.fourmiliere:
                    {
                        Fourmiliere f= new Fourmiliere(nom,position,id);
                        env.ZoneAbstraiteList[position.coordonnes.x].zoneAbstraiteList[position.coordonnes.y].AjouteObjet(f);
                        return f;
                    }
                case (int)FourmiliereConstante.typeObjectAbstrait.pheromoneInactive:
                    {   
                    return new PheromoneInactive(nom, position, id);
                    }

                default:
                    return null;

            }
        }

        public override PersonnageAbstrait creerPersonnage(string nom, int typeFourmi, ZoneAbstraite zoneFourmiliere, EnvironnementAbstrait env)
        {
            id++;
            switch(typeFourmi)
            {
                case (int)FourmiliereConstante.typeFourmie.fourmiOuvriere:
                    {
                        FourmiOuvriere f= new FourmiOuvriere(nom, zoneFourmiliere, id,env);
                        env.ZoneAbstraiteList[zoneFourmiliere.coordonnes.x].zoneAbstraiteList[zoneFourmiliere.coordonnes.y].AjoutePersonnage(f);
                        return f;
                    }
                case (int)FourmiliereConstante.typeFourmie.fourmiGuerriere:
                    {
                        FourmiGuerriere f = new FourmiGuerriere(nom, zoneFourmiliere, id,env);
                        env.ZoneAbstraiteList[zoneFourmiliere.coordonnes.x].zoneAbstraiteList[zoneFourmiliere.coordonnes.y].AjoutePersonnage(f);
                        return f;
                    }
                case (int)FourmiliereConstante.typeFourmie.oeufFourmiOuvriere:
                    {
                        Oeuf f = new Oeuf(nom, zoneFourmiliere, id , (int)FourmiliereConstante.typeFourmie.fourmiOuvriere);
                        env.ZoneAbstraiteList[zoneFourmiliere.coordonnes.x].zoneAbstraiteList[zoneFourmiliere.coordonnes.y].AjoutePersonnage(f);
                        return f;
                    }
                case (int)FourmiliereConstante.typeFourmie.oeufFourmiGuerriere:
                    {
                        Oeuf f = new Oeuf(nom, zoneFourmiliere, id, (int)FourmiliereConstante.typeFourmie.fourmiGuerriere);
                        env.ZoneAbstraiteList[zoneFourmiliere.coordonnes.x].zoneAbstraiteList[zoneFourmiliere.coordonnes.y].AjoutePersonnage(f);
                        return f;
                    }
                case (int)FourmiliereConstante.typeFourmie.oeufFourmiChaman:
                    {
                        Oeuf f = new Oeuf(nom, zoneFourmiliere, id, (int)FourmiliereConstante.typeFourmie.fourmiChaman);
                        env.ZoneAbstraiteList[zoneFourmiliere.coordonnes.x].zoneAbstraiteList[zoneFourmiliere.coordonnes.y].AjoutePersonnage(f);
                        return f;
                    }
                case (int) FourmiliereConstante.typeFourmie.fourmiReine:
                    {
                        FourmiReine f = new FourmiReine(nom, zoneFourmiliere, id,env);
                        zoneFourmiliere.AjoutePersonnage(f);
                        env.ZoneAbstraiteList[zoneFourmiliere.coordonnes.x].zoneAbstraiteList[zoneFourmiliere.coordonnes.y].AjoutePersonnage(f);
                        return f;
                    }
                case (int)FourmiliereConstante.typeFourmie.fourmiChaman:
                    {
                        FourmiChaman f = new FourmiChaman(nom, zoneFourmiliere, id, env);
                        env.ZoneAbstraiteList[zoneFourmiliere.coordonnes.x].zoneAbstraiteList[zoneFourmiliere.coordonnes.y].AjoutePersonnage(f);
                        return f;
                    }
                default:
                    return null;
            }
        }
        
        public override ZoneAbstraite creerZone(string nom, Coordonnees coordonnees, EnvironnementAbstrait env)
        {
            ZoneAbstraite zone = new BoutDeTerrain(nom,  coordonnees);
            env.ZoneAbstraiteList[zone.coordonnes.x].zoneAbstraiteList[zone.coordonnes.y] = zone;
            return zone;
        }
    }
}
