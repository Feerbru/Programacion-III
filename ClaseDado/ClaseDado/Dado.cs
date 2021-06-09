using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseDado
{
    public class Dado
    {
        private int caras;
        Random random = new Random();

        public Dado(){}

        public int getCaras() 
        {
            return this.caras;
        }
        public void lanzarDado()
        {
            this.caras = random.Next(1, 7);
        }
    }
}
