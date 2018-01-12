using System.Xml.Serialization;

namespace AntSimulator
{
    [XmlInclude(typeof(Chemin))]
    public abstract class AccesAbstrait
    {
        [XmlElement("zoneAccesDebut")]
        public  Coordonnees debut { get; set; }
        [XmlElement("zoneAccesFin")]
        public Coordonnees fin { get; set; }

        public AccesAbstrait(Coordonnees debut, Coordonnees fin)
        {
            this.debut = debut;
            this.fin = fin;
        }
        public AccesAbstrait()
        {

        }
        public ZoneAbstraite getDebut(EnvironnementAbstrait env)
        {
            return env.ZoneAbstraiteList[debut.x].zoneAbstraiteList[debut.y];
        }
        public ZoneAbstraite getFin(EnvironnementAbstrait env)
        {
            return env.ZoneAbstraiteList[fin.x].zoneAbstraiteList[fin.y];
        }
    }
}