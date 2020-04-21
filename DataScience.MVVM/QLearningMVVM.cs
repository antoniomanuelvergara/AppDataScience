using DataScience.Algorithms.QLearning;
using DataScience.Common.Common;
using DataScience.Common.Graph;
using DataScience.Common.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DataScience.MVVM
{

    //este sera nuestro controlador
    public class QLearningMVVM
    {
        #region propiedades
        public Tablero Tablero { get; set; }
        public int DimensionX { get; set;}
        public int DimensionY { get; set; }

        public ObservableCollection<RegistroExploracionGrid> TablaExploracion { get; set; }
        public ObservableCollection<RegistroQ> TablaQ { get; set; }

        #endregion propiedades


        #region campos

        //este es el algoritmo cañonero...
        private QLearning qLearning;

      
        private bool isFoundRecompensa = false;

        #endregion campos



        public QLearningMVVM()
        {
            //instanciamos la clase
            TablaExploracion = new ObservableCollection<RegistroExploracionGrid>();
            TablaQ = new ObservableCollection<RegistroQ>();
           
        }

  
        /// <summary>
        /// 
        /// </summary>
        public void ExecuteQLearning()
        {

            qLearning = new QLearning();
            qLearning.Execute();


        }

        public void CrearTablero(int X, int Y)
        {

           
            DimensionX = X;
            DimensionY = Y;

            Tablero = new Tablero(X,Y);
           


        }

        public void Explorar()
        {
            //inicialmente la celda actual es la 1,1
            Node<Celda> nodoActual = Tablero.getPrimeraCelda();
       
            DispatcherTimer dispathcer = new DispatcherTimer();
            int counter = 0;
            //Intervalo de 1 segundo
            dispathcer.Interval = new TimeSpan(0, 0, 1);
            dispathcer.Tick += (s, a) => {

                //por cada interaccion obtenemos un registro
                RegistroExploracion registro= Tablero.ExplorarCeldas(nodoActual);
                //añadirmos el registro que obtenemos a la tabla que tendra binding con la tabla de WPF
                //pero debemos evaluar si exite uno, en cuyo caso como ya pasó por ahí no se añade

                if (nodoActual.Value.Recompensa == 100)
                    isFoundRecompensa = true;

                int contador = 0;
                //vamos a ver si el elemento esta en el data grid
                foreach (RegistroExploracionGrid item in TablaExploracion)
                {

                    RegistroExploracionGrid regAux = new RegistroExploracionGrid(registro);

                    if (item.NodoCurrent.Equals(regAux.NodoCurrent) && item.NodoNext.Equals(regAux.NodoNext)                  
                    && item.Accion.Equals(regAux.Accion) && item.Recompensa.Equals(regAux.Recompensa))
                    {
                        //si el elemento ya esta en la lista lo borra
                        TablaExploracion.RemoveAt(contador);                       
                        break;

                    }

                    contador++;
                       
                }

                TablaExploracion.Add(new RegistroExploracionGrid(registro));              
                //aqui cambiamos la celda actual a otra...
                nodoActual = registro.NodoNext;
                
                //hasta que no encuentre el explorador la recomensa no va a parar
                if (counter > 25 && isFoundRecompensa)
                {
                    dispathcer.Stop();
                }

                counter++;
            };

            dispathcer.Start();

            //numero de iteraciones
           
            
            //haremos esto una serie de veces hasta finalizar la exploracion
           


        }
        /// <summary>
        /// Explorar si que veamos por pantalla
        /// </summary>
        public void ExplorarRapido()
        {
            //inicialmente la celda actual es la 1,1
            Node<Celda> nodoActual = Tablero.getPrimeraCelda();

          
            int contador = 0;
            
            while (contador < 25)
            {
                //por cada interaccion obtenemos un registro
                RegistroExploracion registro = Tablero.ExplorarCeldas(nodoActual);
                //añadirmos el registro que obtenemos a la tabla que tendra binding con la tabla de WPF
                //pero debemos evaluar si exite uno, en cuyo caso como ya pasó por ahí no se añade
                int contador2= 0;
                //vamos a ver si el elemento esta en el data grid
                foreach (RegistroExploracionGrid item in TablaExploracion)
                {

                    RegistroExploracionGrid regAux = new RegistroExploracionGrid(registro);

                    if (item.NodoCurrent.Equals(regAux.NodoCurrent) && item.NodoNext.Equals(regAux.NodoNext)
                    && item.Accion.Equals(regAux.Accion) && item.Recompensa.Equals(regAux.Recompensa))
                    {
                        //si el elemento ya esta en la lista lo borra
                        TablaExploracion.RemoveAt(contador2);
                        break;

                    }
              
                    contador2++;
                }

                TablaExploracion.Add(new RegistroExploracionGrid(registro));
                //aqui cambiamos la celda actual a otra...
                nodoActual = registro.NodoNext;

                contador++;

            }

            
          

        }



    }
}
