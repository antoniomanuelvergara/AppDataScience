using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience.Common.Model
{

    /// <summary>
    /// 
    /// </summary>
    public class KNNModel
    {
        public IList<Persona> Datos { get; set; } 
        public IList<Persona> DatosTest { get; set; }


        /// <summary>
        /// ctor
        /// </summary>
        public KNNModel()
        {

            Datos = new List<Persona>();

            Datos.Add(new Persona() { estatura = 0.7, pelo = 0.4, CLASS = "Hombre" });
            Datos.Add(new Persona() { estatura = 0.5, pelo = 0.34, CLASS = "Mujer" });
            Datos.Add(new Persona() { estatura = 0.1, pelo = 0.22, CLASS = "Hombre" });
            Datos.Add(new Persona() { estatura = 0.3, pelo = 0.56, CLASS = "Mujer" });
            Datos.Add(new Persona() { estatura = 0.6, pelo = 0.4, CLASS = "Hombre" });

            Datos.Add(new Persona() { estatura = 0.1, pelo = 0.65, CLASS = "Hombre" });
            Datos.Add(new Persona() { estatura = 0.34, pelo = 0.52, CLASS = "Mujer" });
            Datos.Add(new Persona() { estatura = 0.15, pelo = 0.12, CLASS = "Hombre" });
            Datos.Add(new Persona() { estatura = 0.23, pelo = 0.6, CLASS = "Perro" });
            Datos.Add(new Persona() { estatura = 0.66, pelo = 0.14, CLASS = "Hombre" });

            Datos.Add(new Persona() { estatura = 0.17, pelo = 0.2, CLASS = "Hombre" });
            Datos.Add(new Persona() { estatura = 0.56, pelo = 0.4, CLASS = "Mono" });
            Datos.Add(new Persona() { estatura = 0.9, pelo = 0.2, CLASS = "Hombre" });
            Datos.Add(new Persona() { estatura = 0.1, pelo = 0.6, CLASS = "Mujer" });
            Datos.Add(new Persona() { estatura = 0.4, pelo = 0.3, CLASS = "Mono" });

            DatosTest = new List<Persona>();
            DatosTest.Add(new Persona() { estatura = 0.2, pelo = 0.54, CLASS = "?" });

        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class Persona
    {
        public double estatura { get; set; }
        public double pelo { get; set; }
        public string CLASS { get; set; }  //Sexo
    }
}
