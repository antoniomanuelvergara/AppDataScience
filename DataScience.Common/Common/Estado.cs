using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience.Common.Common
{
    /// <summary>
    /// implementamos un patron state para las celdas...
    /// </summary>
    public abstract class Estado
    {
        public Celda Celda { get; set; }

        public Estado(Celda Celda)
        {
            this.Celda = Celda;
        }
        //lista de metodos que implementaremos segun el estado...
        public abstract void CalcularLoqueSea();


    }
    /// <summary>
    /// un estado posible
    /// </summary>
    public class Bloque : Estado
    {
        public Bloque(Celda Celda) : base(Celda) { }
        
        /// <summary>
        /// 
        /// </summary>
        public override void CalcularLoqueSea()
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// otro estado posible
    /// </summary>
    public class Vacia : Estado
    {
        public Vacia(Celda Celda) : base(Celda) { }
      
        /// <summary>
        /// 
        /// </summary>
        public override void CalcularLoqueSea()
        {
            throw new NotImplementedException();
        }
    }
}