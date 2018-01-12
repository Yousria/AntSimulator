using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Objet
{
    class PierreObstacle : Obstacle
    {
        public PierreObstacle()
        {

        }
        public PierreObstacle(String nom, ZoneAbstraite position, int id) : base(nom, position,id)
        {
       
        }
    }
}
