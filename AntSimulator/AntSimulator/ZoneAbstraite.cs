using AntSimulator.Objet;
using AntSimulator.Objet.Pheromone;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace AntSimulator
{
    [XmlInclude(typeof(BoutDeTerrain))]
    public abstract class ZoneAbstraite
    {
        [XmlElement("coordonneesZone")]
        public Coordonnees coordonnes { get; set; }
        [XmlElement("nomZone")]
        public string nom { get; set; }
        [XmlIgnore]
        public List<ObjetAbstrait> ObjetsList { get; set; }
        [XmlIgnore]
        public PaireDirection[] AccesAbstraitList { get; set; }
        [XmlIgnore]
        public List<PersonnageAbstrait> PersonnagesList { get; set; }

        public ZoneAbstraite(string unNom)
        {
            nom = unNom;
            coordonnes = new Coordonnees();
            PersonnagesList = new List<PersonnageAbstrait>();
            AccesAbstraitList = new PaireDirection[4];
            ObjetsList = new List<ObjetAbstrait>();
        }
        public ZoneAbstraite(string unNom, Coordonnees coordonnees)
        {
            nom = unNom;
            this.coordonnes = coordonnees;
            PersonnagesList = new List<PersonnageAbstrait>();
            AccesAbstraitList = new PaireDirection[4];
            ObjetsList = new List<ObjetAbstrait>();
        }
        public ZoneAbstraite()
        {
            nom = "nom par defaut";
            coordonnes = new Coordonnees();
            PersonnagesList = new List<PersonnageAbstrait>();
            AccesAbstraitList = new PaireDirection[4];
            ObjetsList = new List<ObjetAbstrait>();
        }

        public void AjouteAcces(int direction, AccesAbstrait acces)
        {
            PaireDirection pair = new PaireDirection(direction, acces);
            AccesAbstraitList[direction] = pair;
        }
        public void AjouteObjet(ObjetAbstrait objet)
        {
            ObjetsList.Add(objet);
        }
        public void AjoutePersonnage(PersonnageAbstrait unPersonnage)
        {
            PersonnagesList.Add(unPersonnage);
        }
        public void RetirePersonnage(PersonnageAbstrait unPersonnage)
        {
            if (!PersonnagesList.Contains(unPersonnage))
            {
                Console.WriteLine("Ce Personnage n'existe pas dans la liste");
            }
            PersonnagesList.Remove(unPersonnage);
        }


        public Boolean containsObjet(Type type, EnvironnementAbstrait env)
        {
            ZoneAbstraite z = env.ZoneAbstraiteList[coordonnes.x].zoneAbstraiteList[coordonnes.y];
            for (int i = 0; i < z.ObjetsList.Count; i++)
            {
                if (z.ObjetsList[i].GetType() == type)
                {
                    return true;
                }
            }
            for (int i = 0; i < z.PersonnagesList.Count; i++)
            {
                if (z.PersonnagesList[i].GetType() == type)
                {
                    return true;
                }
            }
            
            return false;
        }

        public Nourriture getNourriture(EnvironnementAbstrait env)
        {
            if (this.containsObjet(typeof(Nourriture),env))
            {
                for (int i = 0; i < ObjetsList.Count; i++)
                {
                    if (ObjetsList[i].GetType() == typeof(Nourriture))
                    {
                        return (Nourriture)ObjetsList[i];
                    }
                }
            }
            return null;
        }
        public PheromoneActive getPheromone()
        {
           
                for(int i=0;i<ObjetsList.Count;i++)
                {
                ObjetAbstrait ph = ObjetsList[i];
                
                if(ph.GetType() is PheromoneActive ||ph.GetType() == typeof(PheromoneBas) || ph.GetType() == typeof(PheromoneHaut) || ph.GetType() == typeof(PheromoneGauche) || ph.GetType() == typeof(PheromoneDroite))
                        return (PheromoneActive)ph;
                }
            
            return null;
        }
        public void SupprimerPheromone()
        {

            foreach (ObjetAbstrait ph in this.ObjetsList)
            {
                if (ph.GetType() is PheromoneActive || ph.GetType() == typeof(PheromoneBas) || ph.GetType() == typeof(PheromoneHaut) || ph.GetType() == typeof(PheromoneGauche) || ph.GetType() == typeof(PheromoneDroite))
                {
                    this.ObjetsList.Remove(ph);
                }
            }
            
        }
        public bool ZoneBloquee()
        {
            if(this.coordonnes.x== FourmiliereConstante.fourmiliere.x && this.coordonnes.y == FourmiliereConstante.fourmiliere.y)
            {
                return false;
            }
            foreach (ObjetAbstrait o in this.ObjetsList)
            {
                if (o.GetType().GetInterfaces().Contains(typeof(EstObstacle)))
                    return true;
            }
            foreach (PersonnageAbstrait p in this.PersonnagesList)
            {
                if (p.GetType().GetInterfaces().Contains(typeof(EstObstacle)))
                    return true;
            }
            return false;
        }
        public bool TousAccesBloque(EnvironnementAbstrait env)
        {
            bool zonesBloquees = true;
            foreach(PaireDirection p in this.AccesAbstraitList)
            {
                if(p!=null)
                if (!p.accesAbstrait.getFin(env).ZoneBloquee())
                    zonesBloquees = false;
            }
            return zonesBloquees;
        }

        public List<PersonnageAbstrait> ListeFourmiAlentours(EnvironnementAbstrait env)
        {
            ZoneAbstraite z = env.ZoneAbstraiteList[coordonnes.x].zoneAbstraiteList[coordonnes.y];
            List<PersonnageAbstrait> listeFourmi = new List<PersonnageAbstrait>();
            if (this.AccesAbstraitList[(int)FourmiliereConstante.direction.droite]!= null && 
                this.AccesAbstraitList[(int)FourmiliereConstante.direction.droite].accesAbstrait.getFin(env).containsFourmi(env))
            {
                listeFourmi.Add(this.AccesAbstraitList[(int)FourmiliereConstante.direction.droite].accesAbstrait.getFin(env).getFourmi(env));
            }
            if (this.AccesAbstraitList[(int) FourmiliereConstante.direction.gauche]!=null && 
                this.AccesAbstraitList[(int)FourmiliereConstante.direction.gauche].accesAbstrait.getFin(env).containsFourmi(env))
            {
                listeFourmi.Add(this.AccesAbstraitList[(int)FourmiliereConstante.direction.gauche].accesAbstrait.getFin(env).getFourmi(env));
            }
            if (this.AccesAbstraitList[(int)FourmiliereConstante.direction.haut]!= null && 
                this.AccesAbstraitList[(int)FourmiliereConstante.direction.haut].accesAbstrait.getFin(env).containsFourmi(env))
            {
                listeFourmi.Add(this.AccesAbstraitList[(int)FourmiliereConstante.direction.haut].accesAbstrait.getFin(env).getFourmi(env));
            }
            if (this.AccesAbstraitList[(int)FourmiliereConstante.direction.bas]!= null && 
                this.AccesAbstraitList[(int)FourmiliereConstante.direction.bas].accesAbstrait.getFin(env).containsFourmi(env))
            {
                listeFourmi.Add(this.AccesAbstraitList[(int)FourmiliereConstante.direction.bas].accesAbstrait.getFin(env).getFourmi(env));
            }
            Console.WriteLine("NOMBRE FOURMI AUTOUR DU CHAMAN : " + listeFourmi.Count);
            return listeFourmi;

        }

        public bool containsFourmi(EnvironnementAbstrait env)
        {
            ZoneAbstraite z = env.ZoneAbstraiteList[coordonnes.x].zoneAbstraiteList[coordonnes.y];
            if (!z.ZoneBloquee() && z != null)
            {
                if (z.PersonnagesList.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public PersonnageAbstrait getFourmi(EnvironnementAbstrait env)
        {
            ZoneAbstraite z = env.ZoneAbstraiteList[coordonnes.x].zoneAbstraiteList[coordonnes.y];
            if (z.containsFourmi(env))
            {
                return z.PersonnagesList[0];
            }
            return null;
        }

    }

    
}