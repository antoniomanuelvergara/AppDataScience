using DataScience.Common.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience.Algorithms.Busquedas
{
    public class BusquedaProfundidadRecursiva<T>
    {

        public BusquedaProfundidadRecursiva()
        { }

        public void RecorridoProfundidad(Graph<T> grafo)
        {

            List<Node<T>> listaNodos = grafo.getListaNodos();

            //recorre todos los nodos y si la posición es false llama a la funcion recursiva
            int posicion = 0;
            foreach (Node<T> nodo in listaNodos)
            {
                if (nodo.IsVisit == false)
                {
                    RecProfundidadRecursivo(nodo, posicion);
                }
                posicion++;
            }

        }
        private void RecProfundidadRecursivo(Node<T> nodo, int posicion)
        {
            //nada mas entrar ya pone a visitado el nodo
            nodo.IsVisit = true;
            Console.WriteLine(nodo.Value);
            //guarda en una lista todos los nodos adyacentes al nodo que se esta evaluando.
            NodeList<T> adyacentes = nodo.AdyacentsNodes;
            int pos = 0;
            //recorre todos los nodos adyacentes
            foreach (Node<T> nod in adyacentes)
            {

                if (nodo.IsVisit == false)
                {

                    RecProfundidadRecursivo(nod, pos);

                }
                pos++;
            }


        }




    }
}
