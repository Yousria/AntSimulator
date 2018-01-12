using AntSimulator.Fabrique;
using AntSimulator.Objet;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{
    [XmlRoot("environnement")]
    [XmlInclude(typeof(BoutDeTerrain))]
    [XmlInclude(typeof(EnvironnementConcret))]
    public abstract class EnvironnementAbstrait
    {
        /*[XmlElement("listeAccesEnvironnement")]
        public List<AccesAbstrait> AccesAbstraitList { get; set; }*/
        public TableauZoneAbstraite[] ZoneAbstraiteList { get; set; }
        public List<ObjetAbstrait> ObjetsList { get; set; }
        public List<PersonnageAbstrait> PersonnagesList { get; set; }
        public Fourmiliere fourmiliere;
        public MeteoObservable meteo= new MeteoObservable();

        public abstract void InitChemins();
        public EnvironnementAbstrait()
        {
            //AccesAbstraitList = new List<AccesAbstrait>();
            ZoneAbstraiteList = new TableauZoneAbstraite[FourmiliereConstante.NbCase];
            for(int i = 0; i < FourmiliereConstante.NbCase; i++)
            {
                ZoneAbstraiteList[i] = new TableauZoneAbstraite();
            }
            ObjetsList = new List<ObjetAbstrait>();
            PersonnagesList = new List<PersonnageAbstrait>();
        }
        public abstract void AjouteChemins(FabriqueAbstraite fabrique, params AccesAbstrait[] accesArray);
        public void AjouteObjet(ObjetAbstrait unObjet)
        {
            ObjetsList.Add(unObjet);
        }
        public void AjouterPersonnage(PersonnageAbstrait unPersonnage)
        {
            PersonnagesList.Add(unPersonnage);
        }
        public void AjouterZoneAbstraite(ZoneAbstraite zoneAbstraite)
        {
            ZoneAbstraiteList[zoneAbstraite.coordonnes.x].zoneAbstraiteList[zoneAbstraite.coordonnes.y] = zoneAbstraite;
        }
        public abstract void ChargerEnvironnement(FabriqueAbstraite fabrique);
        public abstract void ChargerObjets(FabriqueAbstraite fabrique);
        public abstract void ChargerPersonnages(FabriqueAbstraite fabrique);
        public abstract void DeplacerPersonnage(PersonnageAbstrait unPersonnage, ZoneAbstraite source,
            ZoneAbstraite destination);
        public abstract string Simuler();
        public abstract string Statistiques();

    }
}
