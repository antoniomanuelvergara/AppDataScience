using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationAq
{
    class Program
    {
        static void Main(string[] args)
        {



            //ejecutamos y le mandamos los datos.
            DataAq datos = new DataAq();
          
            AqController aqC = new AqController(datos);
            Recubrimiento resultado = aqC.Start();
            Console.WriteLine(resultado.GetRecubrimento());
        
            Console.ReadKey();


        }
    }
}
