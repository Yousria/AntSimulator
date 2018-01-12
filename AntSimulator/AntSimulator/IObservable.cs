using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public interface IObservable
    {
        void ajouterObservateur(IObservateur observateur);
        void supprimerObservateur(IObservateur observateur);
        void notifierObservateur(EnvironnementAbstrait env);
    }
}
