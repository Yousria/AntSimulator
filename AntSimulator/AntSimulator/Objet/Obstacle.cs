using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntSimulator.Objet
{
    public class Obstacle : ObjetAbstrait, EstObstacle
    {
        public Obstacle() : base()
        {

        }
        public Obstacle(String nom, ZoneAbstraite position, int id): base(nom,position,id)
        {
        }
    }
}
