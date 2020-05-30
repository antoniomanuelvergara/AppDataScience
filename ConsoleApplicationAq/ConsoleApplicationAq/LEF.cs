using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationAq
{
    //funcion lexicografica
    public class LEF
    {
        public int Cobertura { get; set; } = 1; //como minimo debe cubrir a 1 ejemplo positivo       
        public int Cost { get; set; } = 3; //si hay empate como maximo el costo puede ser 3
        public int NumeroExpresiones { get; set; } = 2; //si hay empate como maximo estara compuesto de dos expresiones


        public LEF(int cobertura,int cost, int numeroExpresiones)
        {
            this.Cobertura = cobertura;
            this.Cost = cost;
            this.NumeroExpresiones = numeroExpresiones;
        }
    }
}
