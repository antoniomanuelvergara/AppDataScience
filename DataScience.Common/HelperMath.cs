using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataScience.Common
{
    public static class HelperMath<T,E>
    {


        /// <summary>
        /// Calculamos la distancia euclidea entre dos puntos de cualquier lista  de tipos numericos (float, double,decimal,int) 
        /// </summary>
        /// <param name="coordLearning"></param>
        /// <param name="coordData"></param>
        /// <returns></returns>
        public static Result<T,E> DistanciaEuclidea(List<T> coordPoint1, List<T> coordPoint2)
        {

            Result<T,E> result = new Result<T,E>(ResultType.SIMPLE);
            T sumatorio = (dynamic)0;

            try
            {                                  
                for(int i=0;i<coordPoint1.Count;i++)  
                {
                    sumatorio = (dynamic)sumatorio + Math.Pow(((dynamic)coordPoint1[i] -(dynamic)coordPoint2[i]),2);
                 
                }

                result.Data= Math.Sqrt(Math.Abs((dynamic)sumatorio));

            }
            catch (Exception ex)
            {
                result.Message = ex.ToString();

            }

            return result;


        }

  

        /// <summary>
        /// Calculamos de media de cualquier lista  de tipos numericos (float, double,decimal,int) 
        /// la media es la suma de todos divido por el cantidad total
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Result<T,E> Media(List<T> values)
        {
            Result<T,E> result = new Result<T,E>(ResultType.SIMPLE);
            try
            {
                T sumatorio = (dynamic)0; 
               
                //recorremos toda la lista
                foreach (T valor in values)
                {
                   //suma todos los valores
                    sumatorio  = (dynamic)sumatorio + (dynamic)valor;              
                }
                             
                T resultado= (T)(dynamic)sumatorio;
                //cantidad de valores que se le pasan  
                T divisor = (T)(dynamic)values.Count();  
                //se calcula la media
                result.Data = (T)(resultado / (dynamic)divisor);
                
            }
            catch (Exception ex)
            {
             
                result.Message= ex.ToString();
            }
           
            return result;

        }

        /// <summary>
        /// Calculamos de mediana de cualquier lista  de tipos numericos (float, double,decimal,int) 
        /// la mediana es el valor que una vez ordenada la lista queda justo en medio
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Result<T,E> Mediana(List<T> values)
        {
            Result<T,E> result = new Result<T,E>(ResultType.SIMPLE);
        
            try
            {
                //ordena la lista de menor a mayor
                values.Sort();

                int valorDeEnMedio = Convert.ToInt32(values.Count() / 2);
                int cociente= Convert.ToInt32(values.Count()%2);

                if (cociente != 0) //es impar
                    result.Data = values[valorDeEnMedio + 1];
                else // es par
                {
                    //en el caso par lo resolvemos con la media de los dos de en medio
                    List<T> aux = new List<T> { values[valorDeEnMedio-1], values[valorDeEnMedio] };
                    result.Data = (dynamic)Media(aux).Data;
                }
                //primero si es impar el de enmedio
                //si es impar el la media de los dos de enmedio

            }
            catch (Exception ex)
            {

                result.Message = ex.ToString();
            }


            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Result<T, E> Maximo(List<T> values)
        {
            Result<T, E> result = new Result<T, E>(ResultType.SIMPLE);

            try
            {
                result.Data = values.Max<T>();

            }
            catch (Exception ex)
            {

                result.Message = ex.ToString();
            }
        
            return result;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Result<T, E> Minimo(List<T> values)
        {
            Result<T, E> result = new Result<T, E>(ResultType.SIMPLE);

            try
            {
                result.Data = values.Min<T>();

            }
            catch (Exception ex)
            {

                result.Message = ex.ToString();
            }

            return result;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Result<T,int> Moda(List<T> values)
        {
            Result<T,int> result = new Result<T,int>(ResultType.DICTIONARY);

            try
            {
                //comparamos todos con todos y si hay repetición se añade al diccionario<valor, numero de repeticiones>
                foreach (T item in values)
                {
                    int count = (dynamic)0;

                    foreach (T item2 in values)
                    {
                        if (item.Equals(item2) && !result.DataDictionary.ContainsKey(item))
                        {
                            result.DataDictionary.Add(item2, count);
                        }
                        if (item.Equals(item2))
                        {
                            count = (dynamic)count + 1;
                            result.DataDictionary[item] = count;
                        }
                    }
                }
                    //ordena por valor la lista resultado
                    var resultOrdernado = from entry in result.DataDictionary orderby entry.Value descending select entry;

                    //calculamos la  moda
                    Dictionary<T,int> resultAux = new Dictionary<T,int>();

                    int maximo =(dynamic) 0;  

                    foreach (KeyValuePair<T,int> item3  in resultOrdernado)
                    {
                        int a = item3.Value;
                        if ((dynamic)a >= maximo && !resultAux.ContainsKey(item3.Key))
                        {
                            resultAux.Add(item3.Key, item3.Value);
                            maximo = a;
                        }

                    }
                    result.DataDictionary.Clear();

                    result.DataDictionary = resultAux;


                

            }
            catch (Exception ex)
            {

                result.Message = ex.ToString();
            }

            return result;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Result<T,E> Varianza(List<T> values)
        {
            Result<T,E> result = new Result<T,E>(ResultType.SIMPLE);
            result.Data = (dynamic)0;

            //calculamos la media de los datos
            T media = (dynamic)Media(values).Data;
          
            try
            {
                //varianza
                foreach (T item in values)
                {

                     result.Data = result.Data + Math.Pow((item - (dynamic)media), 2);

                }

                result.Data = (T)result.Data / ((dynamic)values.Count - 1);


            }
            catch (Exception ex)
            {

                result.Message = ex.ToString();
            }

            return result;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Result<T, E> DesviacionTipica(List<T> values)
        {
            Result<T, E>result = new Result<T, E>(ResultType.SIMPLE);

            try
            {
                result.Data = Math.Sqrt((dynamic)Varianza(values).Data);

            }
            catch (Exception ex)
            {

                result.Message = ex.ToString();
            }

            return result;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static Result<T,E> CoeficienteVariacion(List<T> values)
        {
            Result<T,E> result = new Result<T,E>(ResultType.SIMPLE);

            try
            {
                result.Data = (DesviacionTipica((dynamic)values).Data / Media(values).Data) * 100;

            }
            catch (Exception ex)
            {

                result.Message = ex.ToString();
            }

            return result;

        }


    }
}
