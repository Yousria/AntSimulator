using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntSimulator.Objet;
using AntSimulator.Fabrique;
using AntSimulator.Personnage;

namespace AntSimulator
{
    public class Fourmiliere : ObjetAbstrait
    {

        private FabriqueAbstraite fabriqueFourmiliere = null;
        public List<PersonnageAbstrait> PersonnagesList { get; set; }
        public List<Oeuf> listOeuf { get; set; }
        public List<Nourriture> listNourriture { get; set; }
        public int valeurNutritiveTotalFourmiliere { get; set; }

        public Fourmiliere() : base()
        {
            fabriqueFourmiliere = new FabriqueFourmiliere();
        }

        public Fourmiliere(String nom, ZoneAbstraite position,int id) : base(nom,position,id)
        {
            this.PersonnagesList = new List<PersonnageAbstrait>();
            this.listOeuf = new List<Oeuf>();
            this.listNourriture = new List<Nourriture>(); 
        }

        public void addNouriture(Nourriture nouriture)
        {
            this.listNourriture.Add(nouriture);
            this.valeurNutritiveTotalFourmiliere += nouriture.valeurNutritive;
        }

        /*public static explicit operator Fourmiliere(ObjetAbstrait v)
        {
            throw new NotImplementedException();
        }*/
    }
}
