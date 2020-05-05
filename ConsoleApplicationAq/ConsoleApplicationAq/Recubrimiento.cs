using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationAq
{
    public class Recubrimiento: Estrella
    {
        public string Result { get; set; }



        public string GetRecubrimento()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Recubrimiento: ");

            foreach (Complex complex in Complexes)
            {
               
                if ((Complexes.IndexOf(complex) + 1) == Complexes.Count)
                    sb.Append(complex.GetComplex());
                else
                    sb.Append(complex.GetComplex()+ " O ");

            }

            return sb.ToString();
        }

    }
}
