using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience.Common
{
    //tipo de resultados que podemos obtener
    public enum ResultType{

        SIMPLE=1,
        LIST=2,
        DICTIONARY=3,
        DATATABLE=4,
        DATASET=5
    }

    public enum MessageType
    {
        IsOk=0,
        IsError=1,
        IsCancel=2,
        IsWarning=3,
        IsInfo=4

    }


    //clase para gestionar los resultados que obtenemos..
    public  class Result<T,E>
    {
       
        public T Data { get; set; } //para resultados  de un solo dato
        public List<T> DataList { get; set; } //para listas de resultados
        public Dictionary<T,E> DataDictionary { get; set; } //para los resultados en diccionario 
        public DataTable DataTableR { get; set; }    //para devolver una tabla de resultados
        public DataSet DataSetR { get; set; }  //pàra devolver un conjunto de tablas de resultado
        public string categoria { get; set; }  //el resultado que devuelve un clasificador

        public ResultType resultType { get; set; }

        public MessageType messageType { get; set; }

        public string Message { get; set; }

        public IList<string> ErrorList { get; set; } = new List<string>();



        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="resultType"></param>
        public Result(ResultType resultType)
        {
            this.resultType = resultType;

            switch (resultType)
            {
                case ResultType.SIMPLE:
                    {
                        break;
                    }
                case ResultType.LIST:
                    {
                        DataList = new List<T>();
                        break;
                    }
                case ResultType.DICTIONARY:
                    {
                        DataDictionary = new Dictionary<T,E>();
                        break;
                    }
                  
                case ResultType.DATATABLE:
                    {
                        DataTableR = new DataTable();
                        break;
                    }
                 
                case ResultType.DATASET:
                    {
                        DataSetR = new DataSet();
                        break;
                    }
                 default:
                    {
                        break;

                    }

            }



        }

    }
}
