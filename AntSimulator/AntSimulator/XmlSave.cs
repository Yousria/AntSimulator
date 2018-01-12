using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AntSimulator.Personnage;
using AntSimulator.Objet;
using AntSimulator.Fabrique;
using AntSimulator.Comportement;
using AntSimulator.Objet.Pheromone;

namespace AntSimulator
{
    class XmlSave
    {

        public static void savePersonnage(List<PersonnageAbstrait> personnages, StreamWriter streamWriter)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(personnages.GetType());
            
                xmlSerializer.Serialize(streamWriter, personnages);


        }
        
        public static void saveZone(List<ZoneAbstraite> zone, StreamWriter streamWriter)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(zone.GetType());
            xmlSerializer.Serialize(streamWriter, zone);
            streamWriter.Close();
        }
        public static void saveObject(List<ObjetAbstrait> objet, StreamWriter streamWriter)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(objet.GetType());
            xmlSerializer.Serialize(streamWriter, objet);
        }
        public static void saveEnvironnement(List<EnvironnementAbstrait> environnement, StreamWriter streamWriter)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(environnement.GetType());
            xmlSerializer.Serialize(streamWriter, environnement);
        }

    }
}
