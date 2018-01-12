using AntSimulator.Comportement;
using System.Xml.Serialization;

namespace AntSimulator
{
    public  class FourmiliereConstante
    {
        public enum typeFourmie{
            [XmlEnum("EnumOuvriere")]
            fourmiOuvriere=1,
            [XmlEnum("EnumGuerriere")]
            fourmiGuerriere=2,
            [XmlEnum("EnumReine")]
            fourmiReine=3,
            fourmiChaman = 4,
            oeufFourmiOuvriere = 5,
            oeufFourmiGuerriere = 6,
            oeufFourmiChaman = 7
        };
        public enum direction {
            [XmlEnum("EnumGauche")]
            gauche=0,
            [XmlEnum("EnumDroite")]
            droite=1,
            [XmlEnum("EnumHaut")]
            haut=2,
            [XmlEnum("EnumBas")]
            bas=3 };
        public enum typeObjectAbstrait {
            [XmlEnum("EnumNourriture")]
            nourriture=1,
            [XmlEnum("EnumOeuf")]
            oeuf=2,
            [XmlEnum("EnumFourmiliere")]
            fourmiliere=3,
            [XmlEnum("EnumPheromoneInactive")]
            pheromoneInactive = 4,
            [XmlEnum("EnumPheromoneGauche")]
            pheromoneGauche = 5,
            [XmlEnum("EnumPheromoneHaut")]
            pheromoneHaut = 6,
            [XmlEnum("EnumPheromoneDroite")]
            pheromoneDroite = 7,
            [XmlEnum("EnumPheromoneBas")]
            pheromoneBas = 8
        };

        public static int pointDeVieOuvriere = 5;
        public static int pointDeVieGuerriere = 10;
        public static int pointDeVieReine = 20;
        public static int NbCase = 20;
        public static Coordonnees fourmiliere = new Coordonnees(10, 10);
        public enum typeEvenement
        {
            passeLeTour=0,
            destruction = 1,
            mouvementGauche = 2,
            mouvementDroit = 3,
            mouvementHaut = 4,
            mouvementBas = 5,
            pondreOeuf = 6,
            eclore = 7
        };
    }
}
