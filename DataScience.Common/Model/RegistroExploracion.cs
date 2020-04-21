using DataScience.Common.Common;
using DataScience.Common.Graph;
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
    public class RegistroExploracion
    {

        public Node<Celda> NodoCurrent { get; set; }
        public Action Accion { get; set; }
        public Node<Celda> NodoNext { get; set; }
        public int Recompemsa { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class RegistroExploracionGrid
    {

        public string NodoCurrent { get; set; }
        public string Accion { get; set; }
        public string NodoNext { get; set; }
        public string Recompensa { get; set; }

 


        private RegistroExploracion Registro;


        /// <summary>
        /// nos devulve el registro de Exploracion
        /// </summary>
        /// <returns></returns>
        public RegistroExploracion getRegistro()
        {
            return Registro;
        }

        public RegistroExploracionGrid(RegistroExploracion reg)
        {
            this.Registro = reg;
            string filaCurrent=reg.NodoCurrent.Value.Fila.ToString();
            string columnaCurrent = reg.NodoCurrent.Value.Columna.ToString();
            string filaNext = reg.NodoNext.Value.Fila.ToString();
            string columnaNext = reg.NodoNext.Value.Columna.ToString();

            NodoCurrent = filaCurrent + ":" + columnaCurrent;
            NodoNext = filaNext + ":" + columnaNext;

            if(reg.NodoCurrent.Value.Fila< reg.NodoNext.Value.Fila)
            {
                Accion = "Arriba";
                reg.Accion = Action.Arriba;
            }
            else if(reg.NodoCurrent.Value.Fila > reg.NodoNext.Value.Fila)
            {
                Accion="Abajo";
                reg.Accion = Action.Abajo;
            }
            else if(reg.NodoCurrent.Value.Columna < reg.NodoNext.Value.Columna)
            {
                Accion = "Derecha";
                reg.Accion = Action.Derecha;

            }
            else if(reg.NodoCurrent.Value.Columna > reg.NodoNext.Value.Columna)
            {
                Accion = "Izquierda";
                reg.Accion = Action.Izquierda;
         
            } 
                             
            Recompensa = reg.Recompemsa.ToString();
           

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class RegistroQ

    {
        public string QName { get; set; }
        public float QValue { get; set; }
        public int Episodio { get; set; }


    }



    /// <summary>
    /// 
    /// </summary>
    public enum Action{
        
        Arriba=1,
        Abajo=2,
        Derecha=3,
        Izquierda=4

    }

   
}
