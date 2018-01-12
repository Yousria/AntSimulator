using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public interface IObservateur
    {
        void actualiser(bool state, EnvironnementAbstrait env);
    }
}
