using DataScience.Common.Graph;
using DataScience.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataScience.Common.Common
{
    /// <summary>
    /// Interaction logic for Tablero.xaml
    /// </summary>
    public partial class Tablero : UserControl
    {
        public Graph<Celda> GrafoTablero { get; set; }
        public int dimesionX { get; set; }
        public int dimensionY { get; set; }
        private Canvas graph;

        /// <summary>
        /// 
        /// </summary>
        public Tablero()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public Tablero(int dimX, int dimY)
        {
            InitializeComponent();

            graph = new Canvas();
            graph.Width = dimX * 100;
            graph.Height = dimY * 100;
            graph.HorizontalAlignment = HorizontalAlignment.Left;
            graph.VerticalAlignment = VerticalAlignment.Top;
            tablet.Children.Add(graph);


            this.dimesionX = dimX;
            this.dimensionY = dimY;

            GrafoTablero = new Graph<Celda>();          
            for (int i = 1; i <=dimX; i++)
            {

                for (int j = 1; j <= dimY; j++)
                {
                    //aqui crea los nodos y los inserta al tablero
                    Celda celda = new Celda(i, j);
                    Node<Celda> nodo = new Node<Celda>(celda);
                    GrafoTablero.InsertarNodo(nodo);
                    //obtengo la lista

                    List<Node<Celda>> listaNodos= GrafoTablero.getListaNodos();
                    //recorremos todos los los nodos
                    foreach (var item in listaNodos)
                    {
                        Celda celdaAux = item.Value;
                        if(celdaAux.Fila==i && celdaAux.Columna==j-1)
                        {
                            GrafoTablero.InsertarArco(nodo,item,1);  //el uno es coste del arco que no lo usamos.

                        }else if(celdaAux.Fila == i-1 && celdaAux.Columna == j)
                        {
                            GrafoTablero.InsertarArco(nodo, item, 1);  //el uno es coste del arco que no lo usamos.
                        }
                    }

                }
              
            }

            //añadimos las celdas...
            BuildCeldas();

        }

        /// <summary>
        /// Metodo para contruir las celdas...
        /// </summary>
        public void BuildCeldas()
        {
            CalculaRecompensas();

            List<Node<Celda>> listaNodos = GrafoTablero.getListaNodos();

            int posx = 0;
            int posy = 500;
            int i = 1;
            //recorremos cada uno de los nodos....
            foreach (Node<Celda> nodo in listaNodos)
            {
                Celda celda = nodo.Value;

               
                
                //cada vez que j aumente un numero subimos una posion
                if (celda.Fila == i + 1)
                {
                    posy = posy -100;
                    posx = 0;
                    i = celda.Fila;

                }

                graph.Children.Add(celda);
                Canvas.SetLeft(celda, posx);
                Canvas.SetTop(celda, posy);
                posx = posx + 100;

            }


            //de la lista de nodos cogemos el nm
           

        }

        /// <summary>
        /// calculamos las recomensas aleatotiamente
        /// </summary>
        public void CalculaRecompensas()
        {

            try
            {
                Random rnd = new Random();

                List<Node<Celda>> listaNodos = GrafoTablero.getListaNodos();

                for (int i = 0; i < 2; i++)
                {

                    int cantidad = listaNodos.Count;
                    int randomNumberNode = rnd.Next(0, cantidad);
                    Celda celda = listaNodos[randomNumberNode].Value;
                    celda.Recompensa = -100;                

                }

                //finalmente calculamos la recomensa positivo
                int  cantidad2 = listaNodos.Count;
                int randomNumberNode2 = rnd.Next(0, cantidad2);
                Celda celda2 = listaNodos[randomNumberNode2].Value;
                celda2.Recompensa = 100;



            }
            catch (Exception e)
            {

                throw;
            }

        }

        /// <summary>
        /// Explora una celda y devuelve un resultado que puede ser por ejemplo 
        /// </summary>
        public RegistroExploracion ExplorarCeldas(Node<Celda> nodoActual)
        {
            RegistroExploracion registroExploracion = new RegistroExploracion();
            registroExploracion.NodoCurrent = nodoActual;
            nodoActual.Value.cuadrito.Background = Brushes.Green;  
                   

            try
            {
                Random rnd = new Random();
                //tengo que obtener la lista de los nodos adyacentes al que tengo que es el nodoActual
                //despues almacenar en int la cantidad de nodos adyacentes que tenemos
                //despues aleatoriamente seleccionar uno.
                //dibujar eso.
                NodeList<Celda> listaNodosAyacentes = nodoActual.AdyacentsNodes;
                int cantidad = listaNodosAyacentes.Count;
                int randomNumberNode = rnd.Next(0, cantidad);

                Celda celda = listaNodosAyacentes[randomNumberNode].Value;
                celda.cuadrito.Background = Brushes.Red;

                listaNodosAyacentes[randomNumberNode].IsVisit = true;
                registroExploracion.NodoNext = listaNodosAyacentes[randomNumberNode];
                //esto seria la recomensa de la casilla futura a la que llegamos
                registroExploracion.Recompemsa = listaNodosAyacentes[randomNumberNode].Value.Recompensa;

                return registroExploracion;             

            }
            catch (Exception e)
            {

                throw;
            }

          
        }

        /// <summary>
        /// devuelve la celda 1,1 de la que partimos siempre-
        /// </summary>
        /// <returns></returns>
        public Node<Celda>  getPrimeraCelda()
        {
            //obtengo toda la lista de nodos
            Celda celda=null;
            List<Node<Celda>> listaNodos = GrafoTablero.getListaNodos();
            //recorro todos los nodos
            foreach (Node<Celda> nodo in listaNodos)
            {
                celda = nodo.Value;

                if (celda.Fila == 1 && celda.Columna == 1)
                    return nodo;

            }

            return null;
            
        }

    }
}
