using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationAq
{
    public class Attribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int Cost { get; set; } = 1;
        //ponemos esto para poder desactivar en el excel las columnas que consideremos y no entren en la clasificacion
        public int State { get; set; } = 1; 
    }
}



