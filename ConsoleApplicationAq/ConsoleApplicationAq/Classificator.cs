using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationAq
{
    public class Classificator
    {

        public Recubrimiento Recubrimiento { get; set; }

        public List<RowData> ListDataRow { get; set; }

        public Classificator(Recubrimiento recubrimiento, List<RowData> listDataRowToClassify)
        {
            Recubrimiento = recubrimiento;
            ListDataRow = listDataRowToClassify;
        }
        
        /// <summary>
        /// Metodo para clasificar la lista de los que no tienen clase en base a la estrella obtenida en el training 
        /// </summary>
        /// <returns></returns>
        public List<RowData> ClassifyList()
        {

            foreach (RowData rowData in ListDataRow)
            {
                ClassData Class = new ClassData();
                Class=Classify(rowData);
                rowData.Class = Class;
            }
         
            return ListDataRow;
        }

        /// <summary>
        /// Metodo que clasifica una fila
        /// </summary>
        /// <param name="rowData"></param>
        /// <returns></returns>
        private ClassData Classify(RowData rowData)
        {
            ClassData classData = new ClassData();
            classData.Value = "Negativo";
            //recorreremos todo los complejos del recubrimiento, que esta relacionados como "O", por tanto en el momento que se cumpla un complex ya podemos clasificar
            foreach (Complex complex  in Recubrimiento.Complexes)
            {                
                //aqui dentro evaluamos una relacion "Y" de todos los atributos del complejo
                //si todo lo que trae el complejo en sus atributos esta 
                if (DescribeEjemploPositivo(complex, rowData))
                    {
                    //tendremos realmente que conocer el nombre de la clase que estamos evaluando como positiva pero de momento pongo simplemente "positivo"
                    classData.Value = "Positivo"; 
                    return classData;
                    }

            }

            //aqui meteremos la logica que clasifica la fila segun la estrella            
            return classData;

        }

        //es muy parecido al que usa el controlador a excepcion de que devuelve un bool en lugar de un int, analizar si sustituirlo.
        public bool DescribeEjemploPositivo(Complex complejo, RowData positivo)
        {

            int contadorDeTrues = 0;
            //para cada atributo del ejemplo positivo que ha recibido 
            foreach (Attribute attribute in positivo.Attributes)
            {
                //para los atributos que componen el complejo
                foreach (Attribute c in complejo.Expresiones)
                {
                    //si ese atributo tiene el mismo nombre y el mismo valor
                    if ((attribute.Name == c.Name) && (attribute.Value == c.Value))
                    {
                        //para que devuelva un true es fundamental que todos los atributos del complejo sean true
                        contadorDeTrues = contadorDeTrues + 1;

                    }
                }
                //para que devuelva un true es fundamental que todos los atributos del complejo sean true
                if (complejo.Expresiones.Count == contadorDeTrues)
                    return true;

            }


            return false;


        }


    }
}
