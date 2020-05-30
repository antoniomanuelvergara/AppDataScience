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
        //numero de ejmplos positivos que cubre el complejo
        public int NumeroEjemplosPositivos { get; set; } = 0;

        public int CostTotal { get; set; } = 0;

        public Complex()
        {
            Expresiones = new List<Attribute>();

           

        }

        public void CalculaCostTotal()
        {

            foreach(Attribute atr in Expresiones)
            {
                CostTotal = CostTotal + atr.Cost;
            }
        }

        
        /// <summary>
        /// añade un atributo a la lista de expresiones
        /// </summary>
        /// <param name="complex"></param>
        /// <param name="cpx"></param>
        /// <returns></returns>
        public bool AddAttributes(Complex complex)
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

        public bool ExistInList(List<Complex> Lprima)
        {
            foreach (Complex cpx in Lprima)
            {
                if (cpx.isIdentical(this))
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



        /// <summary>
        /// nos devuelve en formato texto el complejo con todos sus atributos
        /// </summary>
        /// <returns></returns>
        public string GetComplex()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Sí (");

            foreach(Attribute attribute in Expresiones)
            {
                if ((Expresiones.IndexOf(attribute) + 1) == Expresiones.Count)
                    sb.Append(attribute.Name+ "= "+ attribute.Value+ " )");
                else
                    sb.Append(attribute.Name + "= " + attribute.Value + " y ");  

            }

            return sb.ToString();
        }


    }
}
