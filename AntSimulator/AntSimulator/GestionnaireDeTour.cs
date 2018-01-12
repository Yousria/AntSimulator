using AntSimulator.Fabrique;
using AntSimulator.Objet;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.IO;

namespace AntSimulator
{

    public class GestionnaireDeTour
    {


        public EnvironnementAbstrait environnementFourmiliere;
        public FabriqueAbstraite fabriqueFourmiliere = new FabriqueFourmiliere();
        public List<Evenement> evenements = new List<Evenement>();
        public int nombreTour = 0;
        public bool pluie = false;

        public void ajouterFourmi(int type)
        {
            environnementFourmiliere.AjouterPersonnage((Fourmi)fabriqueFourmiliere.creerPersonnage("fourmi" + FabriqueFourmiliere.id, type, environnementFourmiliere.fourmiliere.position, environnementFourmiliere));
        }
        public void ajouterObjet(int type, int x, int y)
        {
            ZoneAbstraite zoneNourriture = new BoutDeTerrain("zoneNourriture", new Coordonnees(x, y));
            environnementFourmiliere.AjouteObjet(fabriqueFourmiliere.creerObjet("nourriture" + FabriqueFourmiliere.id, type, zoneNourriture, environnementFourmiliere));
        }
        public void init()
        {
            environnementFourmiliere = fabriqueFourmiliere.creerEnvironnement();
            ZoneAbstraite zoneFourmiliere = environnementFourmiliere.ZoneAbstraiteList[FourmiliereConstante.fourmiliere.x].zoneAbstraiteList[FourmiliereConstante.fourmiliere.y];
            environnementFourmiliere.fourmiliere = (Fourmiliere)fabriqueFourmiliere.creerObjet("Fourmiliere1", 3, zoneFourmiliere, environnementFourmiliere);
        }
        public void sauvegarde()
        {
            StreamWriter streamWriter = new StreamWriter("sauvegarde.xml");
            List<EnvironnementAbstrait> environnementList = new List<EnvironnementAbstrait>();
            environnementList.Add(environnementFourmiliere);
            XmlSave.saveEnvironnement(environnementList, streamWriter);
            streamWriter.Close();
        }
        public void charger()
        {
            StreamReader streamReader = new StreamReader("sauvegarde.xml");
            List<EnvironnementAbstrait> environnementList = new List<EnvironnementAbstrait>();
            environnementList.Add(environnementFourmiliere);
            environnementFourmiliere = XmlLoader.loadEnvironnement(streamReader)[0];
            streamReader.Close();
        }

        public void GererPersonnage()
        {
            int max = environnementFourmiliere.PersonnagesList.Count;
            for(int i=0;i<max;i++)
            {
                PersonnageAbstrait p = environnementFourmiliere.PersonnagesList[i];
                Console.WriteLine(p.GetType() +" "+ p.nom + ", Position [" + p.position.coordonnes.x + ":" + p.position.coordonnes.y + "], Prochain tour : " + p.comportement + " point de vie :" + p.pointDeVie+" porte de la nourriture : "+((Fourmi)p).nourriturePortee);
                this.evenements.AddRange(p.comportement.executer(p, environnementFourmiliere));
                p.pointDeVie--;
            }

        }
        public void MiseAJourPersonnage()
        {
            List<PersonnageAbstrait> PersonnageASupprimer = new List<PersonnageAbstrait>();
            foreach (PersonnageAbstrait p in environnementFourmiliere.PersonnagesList)
            {
                if (p.pointDeVie <= 0)
                {
                    evenements.Add(new Evenement(p, (int)FourmiliereConstante.typeEvenement.destruction));
                    PersonnageASupprimer.Add(p);
                }
            }
            foreach (PersonnageAbstrait p in PersonnageASupprimer)
            {
                if (p.GetType() == typeof(Oeuf))
                {
                    ajouterFourmi(((Oeuf)p).type);
                }

                environnementFourmiliere.ZoneAbstraiteList[p.position.coordonnes.x].zoneAbstraiteList[p.position.coordonnes.y].PersonnagesList.Remove(p);
                environnementFourmiliere.PersonnagesList.Remove(p);
            }
        }
        public void MiseAJourObjets()
        {
            List<ObjetAbstrait> objetsASupprimer = new List<ObjetAbstrait>();
            foreach (ObjetAbstrait o in environnementFourmiliere.ObjetsList)
            {
                if (o.GetType() == typeof(Nourriture))
                {
                    if (((Nourriture)o).valeurNutritive == 0)
                    {
                        evenements.Add(new Evenement(o, (int)FourmiliereConstante.typeEvenement.destruction));
                        objetsASupprimer.Add(o);
                    }
                }
                
            }
            Console.WriteLine(environnementFourmiliere.fourmiliere.valeurNutritiveTotalFourmiliere + " de nourriture en stock");
            foreach (ObjetAbstrait o in objetsASupprimer)
            {

                environnementFourmiliere.ZoneAbstraiteList[((Nourriture)o).position.coordonnes.x].zoneAbstraiteList[((Nourriture)o).position.coordonnes.y].ObjetsList.Remove(o);
                environnementFourmiliere.ObjetsList.Remove(o);
            }
        }
        public void GererMeteo()
        {
            if (nombreTour != 0 && nombreTour % 40 == 0)
            {
                if (!pluie)
                {
                    Console.WriteLine("La pluie tombe");
                    environnementFourmiliere.meteo.etatPluie = true;
                    
                    pluie = true;
                }
                else
                {
                    Console.WriteLine("Le soleil brille");
                    environnementFourmiliere.meteo.etatPluie = false;
                    pluie = false;
                }
            }

            environnementFourmiliere.meteo.notifierObservateur(environnementFourmiliere);
        }
        public List<Evenement> executerTour()
        {

            GererMeteo();
            nombreTour++;
            GererPersonnage();
            MiseAJourPersonnage();
            MiseAJourObjets();

            return this.evenements;
        }
        public static void Main()
        {
            GestionnaireDeTour g = new GestionnaireDeTour();
            g.init();
            g.ajouterFourmi((int)FourmiliereConstante.typeFourmie.fourmiReine);
            g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture), 9, 9);
            
            g.ajouterFourmi((int)FourmiliereConstante.typeFourmie.fourmiOuvriere);
            g.ajouterFourmi((int)FourmiliereConstante.typeFourmie.fourmiOuvriere);
            g.ajouterFourmi((int)FourmiliereConstante.typeFourmie.fourmiOuvriere);
            g.ajouterFourmi(((int)FourmiliereConstante.typeFourmie.fourmiGuerriere));
            g.ajouterFourmi(((int)FourmiliereConstante.typeFourmie.fourmiChaman));
            g.ajouterFourmi(((int)FourmiliereConstante.typeFourmie.oeufFourmiGuerriere));
            g.ajouterFourmi(((int)FourmiliereConstante.typeFourmie.oeufFourmiOuvriere));
            g.ajouterFourmi(((int)FourmiliereConstante.typeFourmie.oeufFourmiChaman));
            g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture), 5, 5);
            g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture), 3, 5);
            g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture), 2, 5);
            g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture), 1, 5);
            g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture), 3, 6);
            g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture), 5, 4);
            g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture), 5, 7);
            g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture), 5, 8);
            g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture), 5, 9);
            g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture), 5, 3);
            g.ajouterObjet(((int)FourmiliereConstante.typeObjectAbstrait.nourriture), 15, 15);
            //g.charger();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Tour : " + (g.nombreTour));
                g.executerTour();
                g.evenements = new List<Evenement>();
            }
            g.sauvegarde();
        }
    }

}
