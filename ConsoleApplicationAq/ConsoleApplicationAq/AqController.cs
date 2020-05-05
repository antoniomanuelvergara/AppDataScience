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
            LEF lef = new LEF();
            return Estrella(data.Positivos, data.Negativos, lef);

        }



        public void DeleteIndenticals(List<Complex> cpx)
        {

           

        }


        public Recubrimiento Estrella(Dictionary<int,RowData> positivos, Dictionary<int, RowData> negativos,LEF lef)
        {
            //creamos un recubrimiento de reglas
            Recubrimiento rules = new Recubrimiento();
            //int contador = 0;

            //while(positivos.Count>0)
            //
            foreach (KeyValuePair<int, RowData> semilla in data.Positivos)
            {
                //cogemos el primero de los ejemplos positivos
                //RowData semilla = positivos[1];
                //realizamos una llamada al procedimiento Aq que hemos llamado INDUCE,
                Estrella estrella = Induce(semilla.Value, negativos);
                Complex complexSelected = ElegirComplejo(estrella, positivos, negativos, lef);
                rules.Complexes.Add(complexSelected);
                //por ultimo quitamos de los positivos los ejemplos cubiertos por P, complejo.
                //contador++;
            }
            //}

            return rules;
        }

        private Complex ElegirComplejo(Estrella estrella, Dictionary<int, RowData> positivos, Dictionary<int, RowData> negativos, LEF lef)
        {

            //de momento para avanzar con el algoritmo me quedo con el primero del recubrimento...

            Complex cpx = estrella.Complexes.FirstOrDefault();

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
                            if(cpx.AddAttributes(complex,Lprima))
                            {
                                //solo debe añadir sino existe ya en la lista: esto hace que se añadan tal vez en distinto orden...
                                                                                              
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



        private void DeleteComplex(List<Complex> Lprima)
        {

           


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
