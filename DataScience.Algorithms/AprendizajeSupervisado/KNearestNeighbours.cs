using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataScience.Common.Interfaces;
using DataScience.Common;
using System.Collections;

namespace DataScience.Algorithms.AprendizajeSupervisado
{
    /// <summary>
    /// Algoritmo K-NN  (el vecino mas cercano, donde K es el numero de vecinos más cercanos)
    /// Tecnica de aprendizaje supervisado: necesita datos de entrenamiento
    /// se conocen de entrada las clases existentes y se sabe a que clase pertenecenç
    /// Localizaremos loos K vecinos más cercanos (distancia Euclidea) y asignaremos la clase a la que
    /// pertenezcan la mayoría de esos vecinos
    /// </summary>
    public class KNearestNeighbours<T, E> //: IBaseLearning<T, E>
    {

        private int k; //numero de vecinos que se tendran en cuenta,  suele ser impar para evitar empates

        private DataTable data; //conjuntos de datos conocidos que nos llegan 
        //tenemos que dividir la data que nos llega entre conjunto de pruebas y conjunto de entrenamiento (HelperDistribution)
        private DataTable dataLearning; //conjuntos prueba
        private DataTable dataValidation; //conjunto entrenamiento
        private DataTable dataTest; //conjunto de prueba
        public List<string> categories { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public KNearestNeighbours()
        {
           
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="k"></param>
        public KNearestNeighbours(DataSet dataSet, int k, bool normalize=false)
        {
            this.k = k;
            this.data = dataSet.Tables[0];
            this.dataTest = dataSet.Tables[1];
            //alamcenamos las categorias en una lista
            categories = HelperMachineLearnig.getListaCategorias(data).DataList;
        }

        /// <summary>
        ///la ejecución del algoritmo se divide entre Fase de entrenamiento, Fase de Testing
        /// </summary>
        /// <returns></returns>
        public Result<int, T> Execute()
        {
            Result<int, T> result = new Result<int, T>(ResultType.DICTIONARY);
            
            //fase1
            result=Training();
            //fase2
             Testing();
         
            return result;
        }
        /// <summary>
        /// distribucion , aprendizaje, validacion
        /// </summary>
        /// <returns></returns>
        public Result<int,T> Training()
        {

            Result<int, T> result = new Result<int, T>(ResultType.DICTIONARY);
            
            //distribuimos la Data entre dataLearning y dataValidation
            Distribution(DistributionType.SIMPLE);
            //aqui ejecutamos el algoritmo en si mismo
            result = Learning();
            //aqui validamos contra el conjunto conocido de validacion y vemos nuestro porcentaje acierto, 
            Validation();

            return result;

        }
        /// <summary>
        /// distribucion de la data en aprendizaje -entrenamiento
        /// </summary>
        /// <returns></returns>
        public Result<T, E> Distribution(DistributionType distributionType)
        {

            Result<T, E> result = new Result<T, E>(ResultType.SIMPLE);

            //TODO esta distribucion
            dataLearning = data; //un porcentaje de los datos de la lista 75%
      
            dataValidation =data;  //el resto de los elementos de la lista 25%



            return result;
        }

        /// <summary>
        ///   lazy learning (solo contruimos la tabla que realmente ya lo conocemos.)
        /// </summary>
        /// <returns></returns>
        public Result<int, T> Learning()
        {
            //hay que normalizar
            //se calcula su distancia a todos los elementos de la tabla
        
            Result<int, T> result = new Result<int, T>(ResultType.DICTIONARY);
            List<T> resAux = new List<T>();

            //para cada fila del test, en princio esta pensado solo para que se le pase 1,esto hay que generalizlo para una lista de Test
            foreach (DataRow rowTest in dataTest.Rows)
            {

                Object[] rowTestArray = rowTest.ItemArray;

                //le quitamos la ultima columna que contiene la CLASS  que buscamos para solo enviar al helper valores double
                List<T> auxRowTestArray = new List<T>();

                for (int i = 0; i < rowTestArray.Length - 1; i++)
                {
                    auxRowTestArray.Add((T)rowTestArray[i]);
                }

                //para cada uno de los valores de la lista  de learning calculamos la distancia euclidea
                foreach (DataRow rowData in dataLearning.Rows)
                {
                    Object[] rowDataArray = rowData.ItemArray;
                    //le quitamos la ultima columna que contiene la CLASS para solo enviar al helper valores double
                    List<T> auxRowDataArray = new List<T>();

                    for (int i = 0; i < rowDataArray.Length - 1; i++)
                    {
                        auxRowDataArray.Add((T)rowDataArray[i]);
                    }

                    //almacenamos la lista en el objecto resultado
                    resAux.Add((dynamic)HelperMath<T, E>.DistanciaEuclidea(auxRowTestArray, auxRowDataArray).Data);
                }

              }

                //guardamos el resultado en un diccionario
                //Dictionary<int, T> dictionary = new Dictionary<int, T>();
                int posicion = 1;

                foreach (var item in resAux)
                {
                    result.DataDictionary.Add(posicion++, item);

                }
                //ordena por valor la lista resultado
                var resultOrdernado = from entry in result.DataDictionary orderby entry.Value ascending select entry;

                Dictionary<int, T> resultAux = new Dictionary<int, T>();
            
                foreach (KeyValuePair<int, T> item in resultOrdernado)
                {
                    resultAux.Add(item.Key, item.Value);
                }
                //tenemos el diccionario posicion-distancia ordenado
                result.DataDictionary = resultAux;


            //¿que falta?

            //tenemos una lista con las distancias ordenadas contra 1 elemento que estamos evaluando
            //tenemos un k por ejemplo k=5, por lo queremos quedarnos con ese K distancias

            //Dictionary<int, string> posicionCategoria = new Dictionary<int, string>();

            ////recorremos todas las filas

        
            //int contador = 1;
            //foreach (DataRow item in data.Rows)
            //{
            //    string categoria=item["CLASS"].ToString();  //obtenemos la clase que contiene cada columna
                
            //    foreach (KeyValuePair< int, T > item2 in resultAux)
            //    {
            //        if(contador==item2.Key)
            //        {
            //            posicionCategoria.Add(contador, categoria);
            //        }

            //    }
            //    contador++;
            //}

       
            //debemos saber de que clase son los 5 primeros y los que sean mayoria sera la clase de nuestro elemento


                result.categoria = "";
                return result;  //devuelve un diccionario ordemadp
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Result<T, E> Validation()
        {
            Result<T, E> result = new Result<T, E>(ResultType.LIST);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Result<T, E> Testing()
        {
            Result<T, E> result = new Result<T, E>(ResultType.LIST);

            return result;
        }
    }
}
