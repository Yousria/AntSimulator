using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator
{
    public class Evenement
    {
        public Object o;
        public int ValeurEvenement;

        public Evenement(Object o , int ValeurEvenement)
        {
            this.o = o;
            this.ValeurEvenement = ValeurEvenement;
        }
    }
}
