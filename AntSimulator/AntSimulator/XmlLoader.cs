using AntSimulator.Objet;
using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{
    class XmlLoader
    {
        
        public static void loadPersonnage(EnvironnementAbstrait env)
        {
            foreach(PersonnageAbstrait p in env.PersonnagesList)
            {
                env.ZoneAbstraiteList[p.position.coordonnes.x].zoneAbstraiteList[p.position.coordonnes.y].PersonnagesList.Add(p);
                p.position = env.ZoneAbstraiteList[p.position.coordonnes.x].zoneAbstraiteList[p.position.coordonnes.y];
            }
           

        }
       
        public static void loadObject(EnvironnementAbstrait env)
        {
            foreach (ObjetAbstrait o in env.ObjetsList)
            {
                env.ZoneAbstraiteList[o.position.coordonnes.x].zoneAbstraiteList[o.position.coordonnes.y].ObjetsList.Add(o);
                o.position = env.ZoneAbstraiteList[o.position.coordonnes.x].zoneAbstraiteList[o.position.coordonnes.y];
            }
        }
        public static List<EnvironnementAbstrait> loadEnvironnement(StreamReader streamReader)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<EnvironnementAbstrait>));
            List<EnvironnementAbstrait> envs = (List<EnvironnementAbstrait>)xmlSerializer.Deserialize(streamReader);
            envs[0].InitChemins();
            loadPersonnage(envs[0]);
            loadObject(envs[0]);
            return envs;

        }
    }
}
