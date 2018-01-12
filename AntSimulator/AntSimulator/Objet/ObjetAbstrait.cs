using System.Xml.Serialization;

namespace AntSimulator.Objet
{
    [XmlInclude(typeof(PheromoneAbstraite))]
    [XmlInclude(typeof(Nourriture))]
    public abstract class ObjetAbstrait
    {
        [XmlElement("zoneObjet")]
        public ZoneAbstraite position { get; set; }
        [XmlElement("nomObjet")]
        public string nom { get; set; }
        public int id;

        public ObjetAbstrait()
        {

        }
        public ObjetAbstrait(string nom, ZoneAbstraite position, int id)
        {
            this.position = position;
            this.nom = nom;
            this.id = id;
            //this.position = new BoutDeTerrain("", position.coordonnes);
        }
    }
}