using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationAq
{
    public class AqController
    {
        private Dictionary<ClassData, Recubrimiento> classToLearning; //lista de clases con su correspondiente recubrimiento 


        private DataAq data;

        //el controlador tiene que recibir los datos
        public AqController(DataAq data)
        {
            this.data = data;

        }

        public Recubrimiento Start()
        {
            LEF lef = new LEF(1,3,2);
            return Estrella(lef);

        }



        public void DeleteIndenticals(List<Complex> cpx)
        {

           

        }


        public Recubrimiento Estrella(LEF lef)
        {
            //creamos un recubrimiento de reglas
            Recubrimiento rules = new Recubrimiento();
            //int contador = 0;

            while(data.Positivos.Count>0)
            //
            //foreach (KeyValuePair<int, RowData> semilla in data.Positivos)
            {
                //siempre cogemos el que esta en esa posicion
                var semilla = data.Positivos.First();
                //realizamos una llamada al procedimiento Aq que hemos llamado INDUCE,
                Estrella estrella = Induce(semilla.Value, data.Negativos);
                Complex complexSelected = ElegirComplejo(estrella, data.Positivos, data.Negativos, lef);
                if (complexSelected != null)
                {
                    rules.Complexes.Add(complexSelected);
                    //por ultimo quitamos de los positivos los ejemplos cubiertos por P, complejo.
                    DeletePositivesCubiertos(complexSelected);
                }
               
                //contador++;
            }
            //}

            return rules;
        }

        private void DeletePositivesCubiertos(Complex complexSelected)
        {
            var PositivosCopy =  data.Positivos.ToDictionary(entry => entry.Key,entry => entry.Value);

            foreach (KeyValuePair <int, RowData> positivo in data.Positivos)
            {
                if (DescribeEjemploPositivo(complexSelected, positivo.Value)==1)
                {
                    PositivosCopy.Remove(positivo.Key);
                }

            }

            data.Positivos = PositivosCopy;
            
        }

        private Complex ElegirComplejo(Estrella estrella, Dictionary<int, RowData> positivos, Dictionary<int, RowData> negativos, LEF lef)
        {

            List<Complex> ComplejosSeleccionados= new List<Complex>();
            List<Complex> ComplejosSeleccionadosAux = new List<Complex>();

            //para complejo en la estrella, rellenaremos el campo numeroEjemplosPositivos que cubre.
            foreach (Complex complex in estrella.Complexes)
            {
                foreach (KeyValuePair<int, RowData> positivo in positivos)
                {
                    complex.NumeroEjemplosPositivos = complex.NumeroEjemplosPositivos + DescribeEjemploPositivo(complex, positivo.Value);
                }

                complex.CalculaCostTotal();
            }
            //evalua la covertura
            ComplejosSeleccionadosAux = estrella.Complexes;
            ComplejosSeleccionados = estrella.Complexes.Where(x => x.NumeroEjemplosPositivos >= lef.Cobertura).ToList();
            if (ComplejosSeleccionados.Count == 0)
                ComplejosSeleccionados = ComplejosSeleccionadosAux;

            //evalua el costo para el desempate
            ComplejosSeleccionadosAux = ComplejosSeleccionados;
            if (ComplejosSeleccionados.Count >= 1)
                ComplejosSeleccionados = ComplejosSeleccionados.Where(x => x.CostTotal <= lef.Cost).ToList();
            if (ComplejosSeleccionados.Count == 0)
                ComplejosSeleccionados = ComplejosSeleccionadosAux;

            //evalua la simplicidad de la expresion para el desempate
            ComplejosSeleccionadosAux = ComplejosSeleccionados;
            if (ComplejosSeleccionados.Count >= 1)
            ComplejosSeleccionados = ComplejosSeleccionados.Where(x => x.Expresiones.Count <= lef.NumeroExpresiones).ToList();
                if (ComplejosSeleccionados.Count == 0)
                    ComplejosSeleccionados = ComplejosSeleccionadosAux;
           
            //al final como nada nos asegura que no haya quedado uno solo, nos quedamos con el primero de los que quedan
            Complex cpx = ComplejosSeleccionados.FirstOrDefault();
           
            return cpx;
        }

        /// <summary>
        /// recibe un ejemplo positivo y todos los ejemplos negativos
        /// </summary>
        /// <param name="sample"></param>
        /// <param name="negativos"></param>
        /// <returns></returns>
        public Estrella Induce(RowData sample, Dictionary<int, RowData> negativos)
        {
            //la estrella es el conjunto de de complejos (reglas?) que devolveremos
            Estrella estrella = new Estrella();
            List<Complex> L = new List<Complex>(); //ira conteniendo los complejos que se han considerado hasta ahora pero que no son validos
            List<Complex> Lprima = new List<Complex>();      
            //selectores
            List<Attribute> selectores = sample.Attributes;        
            do
            {
                //PASO 1: tenemos que combinar lo que hay en L con lo que hay selectores y meterlo en L' prima
                foreach(Attribute attribute in selectores)
                {
                    if (L.Count != 0)
                    {
                        foreach (Complex complex in L)
                        {
                            Complex cpx = new Complex();
                            cpx.Expresiones.Add(attribute);
                            if(cpx.AddAttributes(complex))
                            {
                                //solo debe añadir sino existe ya en la lista: esto hace que se añadan tal vez en distinto orden...
                               if(!cpx.ExistInList(Lprima))                                                                     
                                Lprima.Add(cpx);
                            }                         
                        }
                    }
                    else
                    {
                        Complex cpx = new Complex();
                        cpx.Expresiones.Add(attribute);
                        Lprima.Add(cpx);
                    }
                }
                //FIN PASO 1

                //PASO 2 SACAR DE L prima aquellos complejos que esten en la estrella o en L

                Complex[] LprimaAux = new Complex[Lprima.Count];
                Lprima.ToArray().CopyTo(LprimaAux, 0);
                List<Complex> LprimaCopy = LprimaAux.ToList();

                //recorremos todos los complejos de Lprima
                foreach (Complex cpx in Lprima)
                {
                    //primero borramos los que ya esten en la estrella
                    foreach (Complex cpxStar in estrella.Complexes)
                    {
                        if (cpx.isIdentical(cpxStar))
                        {
                            LprimaCopy.Remove(cpx);
                        }
                    }
                    //segundo borramos los que esten en L
                    foreach (Complex cpxL in L)
                    {
                        if (cpx.isIdentical(cpxL))
                        {
                            LprimaCopy.Remove(cpx);
                        }

                    }
                }
                Lprima = LprimaCopy;
                //fin PASO 2
                //hacemos esto porque no podemos recorrer una lista al mismo que tiempo que borramos elementos de ella.
                LprimaAux = new Complex[Lprima.Count];
                Lprima.ToArray().CopyTo(LprimaAux, 0);
                 LprimaCopy = LprimaAux.ToList();
                //fin de lo que hacemos, que hay que mejorar, porque mete complejidad inecesaria al algoritmo y coste computaciones.

                foreach (Complex complejo in Lprima)
                {
                    //si  no describe a ningun ejemplo negativo
                    if (!DescribeEjemploNegativo(complejo))
                    {
                        //añade el complejo a la estrella
                        estrella.Complexes.Add(complejo);
                        LprimaCopy.Remove(complejo);
                    }                    
                }

                L = LprimaCopy;

            } while (L.Count != 0) ;//esto nunca va pasar 

                return estrella;  //devuelve una estrella o conjuntos de complejos
        }

     
        public int DescribeEjemploPositivo(Complex complejo, RowData positivo)
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
                        return 1;

                }

            
            return 0;


        }


        /// <summary>
        /// Devolvera true si el complejo describe a todos los casos negativos
        /// </summary>
        /// <param name="complejo"></param>
        /// <returns></returns>
        public bool DescribeEjemploNegativo(Complex complejo)
        {
      
            //debemos coger todos los atributos del complejo que no sea nulos
            //debemos ver si "TODOS" los valores de ese atributo se encuentran con el mismo valor en el ejemplo negativo
            //en cuyo caso tendremos TRUE como respuesta, en caso contrario sería FALSE la respuesta

            //recorremos cada ejemplo negativo
            foreach (KeyValuePair<int, RowData> result in data.Negativos)
            {
                 int contadorDeTrues = 0;
                //para cada atributo de un ejemplo negativo en concreto
                foreach (Attribute attribute in result.Value.Attributes)
                {                   
                    //para los atributos que componen el complejo
                    foreach(Attribute c in complejo.Expresiones)
                    {
                        //si ese atributo tiene el mismo nombre y el mismo valor
                        if ((attribute.Name == c.Name) && (attribute.Value== c.Value))
                        {
                            //para que devuelva un true es fundamental que todos los atributos del complejo sean true
                            contadorDeTrues = contadorDeTrues + 1;

                        }
                    }
                    //para que devuelva un true es fundamental que todos los atributos del complejo sean true
                    //nota importante, por ahora en el momento que encuentra un solo ejemplo negativo se sale y no sigue analizando ejemplos negativos
                    if (complejo.Expresiones.Count == contadorDeTrues)
                        return true;

                }
           
            }

            return false;

        }


    }
}
