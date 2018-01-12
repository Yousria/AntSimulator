using AntSimulator.Objet;
using AntSimulator.Comportement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AntSimulator.Objet.Pheromone;

namespace AntSimulator.Personnage
{


    public class Fourmi : PersonnageAbstrait, Objet.EstObstacle
    {
        [XmlElement("nourriturePortee")]
        public bool nourriturePortee { get; set; }
        public Fourmi(string nom, ZoneAbstraite c, int id, EnvironnementAbstrait env) : base(nom, id, env)
        {

            this.position = c;
        }
        public Fourmi() : base()
        {
        }

        public Fourmi(string nom, ZoneAbstraite position, int id)
        {
            this.nom = nom;
            this.position = position;
            this.id = id;
        }

        public override void actualiser(bool etatPluie, EnvironnementAbstrait env)
        {
            if (etatPluie == true)
            {
                if (this.GetType() == typeof(FourmiGuerriere) || this.GetType() == typeof(FourmiGuerriere) || this.GetType() == typeof(FourmiChaman))
                {
                    this.comportement = new RentrerFourmiliere();
                    this.executerComportement(env);
                }
            }
            else
            {
                if (this.GetType() == typeof(FourmiGuerriere) || this.GetType() == typeof(FourmiGuerriere))
                {
                    this.comportement = new ChercherAManger();
                    this.executerComportement(env);
                }else if(this.GetType() == typeof(FourmiChaman))
                {
                    this.comportement = new ComportementChaman();
                    this.executerComportement(env);
                }
            }

        }


        public override List<Evenement> executerComportement(EnvironnementAbstrait env)
        {
            return this.comportement.executer(this, env);
        }

        public override ZoneAbstraite AnalyserSituation(EnvironnementAbstrait env)
        {
            
            if (this.position.containsObjet(typeof(Nourriture), env))
            {
                if (this.GetType().BaseType == typeof(Fourmi))
                {
                    Fourmi f = this;

                    f.nourriturePortee = true;
                    this.position.getNourriture(env).valeurNutritive--;


                }
                if (this.position.containsObjet(typeof(Nourriture), env))
                    this.comportement = new RentrerFourmiliere();
                else
                {
                    DecorateurSupprimerPheromone deco = new DecorateurSupprimerPheromone();
                    deco.ajouterComportement(new RentrerFourmiliere());
                    this.comportement = deco;
                }
                return null;
            }
            else
            {

                ZoneAbstraite zoneOuAller = this.repererZone(this, typeof(PheromoneDroite), env);
                if (zoneOuAller == null)
                    zoneOuAller = this.repererZone(this, typeof(PheromoneGauche), env);
                if (zoneOuAller == null)
                    zoneOuAller = this.repererZone(this, typeof(PheromoneHaut), env);
                if (zoneOuAller == null)
                    zoneOuAller = this.repererZone(this, typeof(PheromoneBas), env);
                if (zoneOuAller == null)
                    zoneOuAller = this.repererZone(this, typeof(Nourriture), env);
                else
                {
                    this.comportement = new SuivrePheromone();
                    this.executerComportement(env);
                }
                return zoneOuAller;
            }



        }
        public ZoneAbstraite repererZone(PersonnageAbstrait personnage, Type type, EnvironnementAbstrait env)
        {
            //champs de vision
            int champsVision = personnage.champDeVision;
            
            ZoneAbstraite pos = env.ZoneAbstraiteList[personnage.position.coordonnes.x].zoneAbstraiteList[personnage.position.coordonnes.y];
            ZoneAbstraite zoneTrouvee = null;
            if (pos.containsObjet(type, env))
            {
                zoneTrouvee = pos;
            }
            for (int i = -1 * champsVision; i <= champsVision && i >= -1 * champsVision && zoneTrouvee == null; i++)
            {
                bool iOk = false;
                if (i < 0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.gauche] != null)
                {
                    pos = pos.AccesAbstraitList[(int)FourmiliereConstante.direction.gauche].accesAbstrait.getFin(env);
                    iOk = true;
                }
                else if (i > 0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.droite] != null)
                {
                    pos = pos.AccesAbstraitList[(int)FourmiliereConstante.direction.droite].accesAbstrait.getFin(env);
                    iOk = true;
                }
                else if (i == 0)
                {
                    iOk = true;
                }
                if (pos.containsObjet(type, env) || pos.containsObjet(type.BaseType, env))
                    zoneTrouvee = pos;
                if (iOk)
                {
                    for (int j = -1 * champsVision; j <= champsVision && j >= -1 * champsVision && zoneTrouvee == null; j++)
                    {
                        if (j < 0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.bas] != null)
                        {
                            pos = pos.AccesAbstraitList[(int)FourmiliereConstante.direction.bas].accesAbstrait.getFin(env);
                        }
                        else if (j > 0 && pos.AccesAbstraitList[(int)FourmiliereConstante.direction.haut] != null)
                        {
                            pos = pos.AccesAbstraitList[(int)FourmiliereConstante.direction.haut].accesAbstrait.getFin(env);
                        }
                        if (pos.containsObjet(type, env))
                            zoneTrouvee = pos;

                    }
                }
            }
            /*if(zoneNourriture!=null)
                personnage.position = zoneNourriture;*/

            return zoneTrouvee;
        }
    }
}
