using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator.Objet
{
    public class Nourriture : ObjetAbstrait
    {
        [XmlElement("valeurNutritiveNourriture")]
        public int valeurNutritive { get; set; }

        public Nourriture():base()
        {
            valeurNutritive = 2;
        }
        public Nourriture(string nom,ZoneAbstraite position,int id) : base(nom,position,id)
        {
            valeurNutritive = 2;
        }
    }
}
