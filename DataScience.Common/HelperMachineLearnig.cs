using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience.Common
{
   public static class HelperMachineLearnig
    {


        /// <summary>
        /// obtenemos la lista con las categorias, la tabla tiene que tener un columna llamada CLASS donde vendrá el valor de la categoria
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static Result<string,DBNull> getListaCategorias(DataTable Data)
        {
            Result<string, DBNull> result = new Result<string, DBNull>(ResultType.LIST); 

            try
            {         
                List<string> listaCategorias= new List<string>();
      
                foreach (DataRow row in Data.Rows)
                {
               
                    listaCategorias.Add(Convert.ToString(row["CLASS"]));
                 }
              
                List<string> listaCategoriasAux = new List<string>();
                listaCategoriasAux.Add(listaCategorias[0]);

                //hacemos una lista donde no estan los repetidos
                foreach (string item in listaCategorias)
                {
                    if(!listaCategoriasAux.Any(x => x == item))
                    {
                        listaCategoriasAux.Add(item);
                    }
                }

                    result.DataList = listaCategoriasAux;
            }

            catch (Exception ex)
            {

                result.ErrorList.Add(ex.ToString());

                return result;                

            }


            return result;
        }

    }





}
