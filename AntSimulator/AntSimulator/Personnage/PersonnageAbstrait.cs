using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AntSimulator.Comportement;

namespace AntSimulator.Personnage
{
    [XmlInclude(typeof(Fourmi))]
    [XmlInclude(typeof(FourmiGuerriere))]
    [XmlInclude(typeof(FourmiOuvriere))]
    [XmlInclude(typeof(FourmiReine))]
    [XmlInclude(typeof(FourmiChaman))]

    public abstract class PersonnageAbstrait : IObservateur
    {
        [XmlIgnore]
        public EnvironnementAbstrait env;
        [XmlElement("positionPersonnage")]
        public ZoneAbstraite position;
        [XmlAttribute("nomPersonnage")]
        public String nom {get; set;}
        [XmlElement("viePersonnage")]
        public int pointDeVie{get; set;}
        public ComportementAbstrait comportement { get; set; }
        public int champDeVision;
        public  int id;

        public PersonnageAbstrait(String nom,int id,EnvironnementAbstrait env)
        {
            this.nom = nom;
            this.id = id;
            this.env=env;
        }
        public PersonnageAbstrait( int id,EnvironnementAbstrait env)
        {
            this.nom = nom;
            this.env = env;
        }
        public PersonnageAbstrait()
        {
            this.nom = "test";
        }

        
        public abstract List<Evenement> executerComportement(EnvironnementAbstrait env);
        public abstract void actualiser(bool etatPluie,EnvironnementAbstrait env);
        public void Bouger(ZoneAbstraite z)
        {
            this.position.PersonnagesList.Remove(this);
            this.position = z;
            z.PersonnagesList.Add(this);
        }
        public abstract ZoneAbstraite AnalyserSituation(EnvironnementAbstrait env);
    }
}
