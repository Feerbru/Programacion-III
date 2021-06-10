using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseDado
{
    class Jugador
    {
        public int Cuenta { get; set; }
        public String Nombre { get; set; }
        public int Apuesta { get; set; }
        public int TipoApuesta { get; set; }
        public int DineroApuesta { get; set; }

        public Jugador(String nombre)
        {
            this.Nombre = nombre;
            this.Cuenta = 100;
            this.Apuesta = 0;
            this.TipoApuesta = 0;
            this.DineroApuesta = 0;
        }
        
    }
}
