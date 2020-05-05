using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationAq
{
    public class Complex
    {
        public List<Attribute> Expresiones { get; set; }

        public Complex()
        {
            Expresiones = new List<Attribute>();
        }

        public bool AddAttributes(Complex complex, List<Complex> cpx)
        {
           
            //obtenemos los atributos que estan en el primero pero no en el segundo
            List<Attribute> firstNotSecond = complex.Expresiones.Except(Expresiones).ToList();

            foreach (Attribute at in firstNotSecond)
            {                
               Expresiones.Add(at);
            }
           
            if(firstNotSecond.Count>0)
            {
                return true;
            }

            return false;
        }


        

        /// <summary>
        /// te dice si dos complejos son iguales , devuelve true si son iguales
        /// </summary>
        /// <param name="cpx"></param>
        /// <returns></returns>
        public bool isIdentical(Complex cpx)
        {
            var firstNotSecond = cpx.Expresiones.Except(Expresiones).ToList();
            var secondNotFirst = Expresiones.Except(cpx.Expresiones).ToList();

            //necesitamos saber si dos listas de atributos de dos complejos son identicas...
            return !firstNotSecond.Any() && !secondNotFirst.Any();

        }




        public string GetComplex()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("IF (");

            foreach(Attribute attribute in Expresiones)
            {
                if ((Expresiones.IndexOf(attribute) + 1) == Expresiones.Count)
                    sb.Append(attribute.Value+ " )");
                else
                    sb.Append(attribute.Value + " ^ ");  

            }

            return sb.ToString();
        }


    }
}
