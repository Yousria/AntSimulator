using AntSimulator.Objet;
using AntSimulator.Personnage;
using System.Xml.Serialization;

namespace AntSimulator.Fabrique
{
    [XmlInclude(typeof(FabriqueFourmiliere))]
    public abstract class FabriqueAbstraite
    {
        public abstract string Titre { get; }
        public static int id = 0;
        public EnvironnementAbstrait env;
        
        public FabriqueAbstraite()
        {
            env=EnvironnementConcret.getInstance();
        }
        
        
        public abstract EnvironnementAbstrait creerEnvironnement();
        public abstract ZoneAbstraite creerZone(string nom, Coordonnees coordonnees,EnvironnementAbstrait env);
        public abstract AccesAbstrait creerAcces(ZoneAbstraite debut, ZoneAbstraite fin);
        public abstract PersonnageAbstrait creerPersonnage(string nom,int typeFourmi, ZoneAbstraite zoneFourmiliere, EnvironnementAbstrait env);
        public abstract ObjetAbstrait creerObjet(string nom, int TypeObjet, ZoneAbstraite coordonnes, EnvironnementAbstrait env);


    }
}