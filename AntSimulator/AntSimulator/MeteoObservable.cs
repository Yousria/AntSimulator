using AntSimulator.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AntSimulator
{
    public class MeteoObservable : IObservable
    {
        private List<IObservateur> listObservateur;
        [XmlElement("etatPluieMeteo")]
        public bool etatPluie { get; set; }

        public MeteoObservable()
        {
            this.listObservateur = new List<IObservateur>();
            etatPluie = false;
        }
        

        public void ajouterObservateur(IObservateur observateur)
        {
            this.listObservateur.Add(observateur);
        }

        public void notifierObservateur(EnvironnementAbstrait env)
        {
            this.listObservateur = new List<IObservateur>();
            foreach (Fourmi f in env.PersonnagesList)
                this.listObservateur.Add(f);
            foreach(IObservateur personnage in this.listObservateur)
            {
                personnage.actualiser(etatPluie, env);
            }
        }

        public void supprimerObservateur(IObservateur observateur)
        {
            this.listObservateur.Remove(observateur);
        }
    }
}
