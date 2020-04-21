using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience.Common.Graph
{
    public class Graph<T> : IEnumerable<T>
    {
        //const int size = 100;
        //int[,] matrizDeCosto = new int[size, size];
        //int[,] matrizDeAdyacencia = new int[size, size];
        protected List<Node<T>> verticeSet;
        protected List<Arc<T>> arcoList;
        protected Collection<T> coleccion;
        /// <summary>
        /// 
        /// </summary>
        public Graph() : this(null) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_verticeSet"></param>
        public Graph(List<Node<T>> _verticeSet)
        {
            if (_verticeSet == null)
            {
                this.verticeSet = new List<Node<T>>();
                this.arcoList = new List<Arc<T>>();
            }
            else
                this.verticeSet = _verticeSet;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertice"></param>
        /// <returns></returns>
        public Node<T> InsertarNodo(Node<T> nodo)
        {
            verticeSet.Add(nodo);
            return new Node<T>(nodo.Value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public Arc<T> InsertarArco(Node<T> from, Node<T> to, int cost)
        {
            to.AdyacentsNodes.Add(from);
            from.AdyacentsNodes.Add(to);
            arcoList.Add(new Arc<T>(from, to, cost));
            return new Arc<T>(from, to, cost);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public Arc<T> InsertarArcoDirigido(Node<T> from, Node<T> to, int cost)
        {
            from.AdyacentsNodes.Add(to);
            arcoList.Add(new Arc<T>(from, to, cost));
            return new Arc<T>(from, to, cost);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertice"></param>
        /// <returns></returns>
        public bool RemoveNode(Node<T> vertice)
        {
            Node<T> nodeToRemove = findByValue(vertice.Value);
            IEnumerable<Arc<T>> arcoToRemove = arcoList.Where(a => a.from == nodeToRemove || a.to == nodeToRemove);
            var selectedA = new List<Arc<T>>();
            if (nodeToRemove == null)
                return false;
            verticeSet.Remove(nodeToRemove);
            foreach (Arc<T> arcoItem in arcoToRemove)
            {
                selectedA.Add(arcoItem);
            }
            foreach (Arc<T> arcoItem in selectedA)
            {
                arcoList.Remove(arcoItem);
            }
            foreach (Node<T> refNode in verticeSet)
            {
                int index = refNode.AdyacentsNodes.IndexOf(nodeToRemove);
                if (index != -1)
                {
                    refNode.AdyacentsNodes.RemoveAt(index);

                }
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arco"></param>
        /// <returns></returns>
        public bool isDirigido(Arc<T> arco)
        {
            try
            {
                bool duplaDirecao = (arco.from.AdyacentsNodes.Contains(arco.to)) && (arco.to.AdyacentsNodes.Contains(arco.from));
                if (duplaDirecao)
                    return false;
                return true;
            }
            catch { return true; }
        }
        /// <summary>
        /// nos devuelve una lista de los arcos que estan conectados a un nodo en particular
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public List<Arc<T>> listaArcosIncidentes(Node<T> nodo)
        {
            List<Arc<T>> lista = new List<Arc<T>>();
            foreach (Arc<T> arco in arcoList)
            {
                if (arco.from == nodo || arco.to == nodo)
                    lista.Add(arco);
            }
            return lista;
        }
        /// <summary>
        /// nos devuelve el nodo contrario en caso de existir.
        /// </summary>
        /// <param name="vertice"></param>
        /// <param name="arco"></param>
        /// <returns></returns>
        public Node<T> nodoOpuesto(Node<T> nodo, Arc<T> arco)
        {
            if (isAdyacente(nodo, arco.from))
                return arco.from;
            else if (isAdyacente(nodo, arco.to))
                return arco.to;
            else throw new Exception { };
        }
        /// <summary>
        /// nos dice si dos nodos son adyacentes
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public bool isAdyacente(Node<T> from, Node<T> to)
        {
            return from.AdyacentsNodes.Contains(to) || to.AdyacentsNodes.Contains(from);
        }
        /// <summary>
        /// nos devuelve un nodo final
        /// </summary>
        /// <param name="aresta"></param>
        /// <returns></returns>
        public Node<T>[] NodoFinal(Arc<T> arco)
        {
            return new Node<T>[2] { arco.from, arco.to };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="antiguoVertice"></param>
        /// <param name="nuevoVertice"></param>
        public void substituirNodo(Node<T> antiguoNodo, Node<T> nuevoNodo)
        {
            Node<T> vertice = findByValue(antiguoNodo.Value);
            vertice.Value = nuevoNodo.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="antiguaarco"></param>
        /// <param name="novaarco"></param>
        public void substituirArco(Arc<T> antiguoArco, Arc<T> nuevoArco)
        {
            int index = arcoList.FindIndex(a => a.from == antiguoArco.from && a.to == antiguoArco.to);
            if (index > -1)
                arcoList[index] = nuevoArco;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Node<T> findByValue(T value)
        {
            return verticeSet.FirstOrDefault(v => v.Value.Equals(value));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Node<T>> getListaNodos()
        {
            return verticeSet;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Arc<T>> getListaArcos()
        {
            return arcoList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arco"></param>
        /// <returns></returns>
        public string getArco(Arc<T> arco)
        {
            try
            {
                return arco.from.Value.ToString() + " - " + arco.to.Value.ToString();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return coleccion.GetEnumerator();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    


        ///// <summary>
        ///// 
        ///// </summary>
        //public void isEuleriano()
        //{
        //    int soma = 0;
        //    int grau;
        //    int linhaAtual = 0;
        //    int numeroLinhas = verticeSet.Count;
        //    while ((soma <= 2) && (linhaAtual < numeroLinhas))
        //    {
        //        grau = 0;
        //        for (int i = 0; i < numeroLinhas; i++)
        //        {
        //            grau += matrizDeAdyacencia[linhaAtual, i];
        //        }
        //        if (grau % 2 == 1)
        //        {
        //            soma++;
        //        }
        //        Console.WriteLine(grau.ToString());
        //        linhaAtual++;
        //    }
        //    if (soma > 2)
        //        Console.WriteLine("Nao é Euleriano!");
        //    else if (soma == 2)
        //        Console.WriteLine("É semieuleriano!");
        //    else
        //        Console.WriteLine("É euleriano!");
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="from"></param>
        ///// <param name="to"></param>
        //public void Dijkstra(Node<T> from, Node<T> to)
        //{
        //    List<Node<T>> listaNaoVisitados = new List<Node<T>>();
        //    List<Arc<T>> arcos = getListaarcos();
        //    string path = "";
        //    int costo = 0;
        //    bool isPrimero = true;
        //    foreach (Node<T> v in verticeSet)
        //    {
        //        listaNaoVisitados.Add(v);
        //    }
        //    foreach (Arc<T> a in arcos)
        //    {
        //        a.Cost = int.MaxValue;

        //    }
        //    arcos.ElementAt(0).Cost = 0;
        //    listaNaoVisitados.Remove(from);
        //    while (listaNaoVisitados.Count != 0)
        //    {
        //        int smallest = 0;
        //        Node<T> visitado = new Node<T>();
        //        Arc<T> arestavisitada = new Arc<T>(null, null);
        //        Arc<T> arestavisitadaFinalWhile = new Arc<T>(null, null);

        //        foreach (Node<T> v in from.ChildrenNodes)
        //        {
        //            if (isPrimero)
        //            {
        //                if (arcos.Find(a => a.from == from && a.to == v).Cost < smallest)
        //                {
        //                    smallest = arcos.Find(a => a.from == from && a.to == v).Cost;
        //                    visitado = arcos.Find(a => a.from == from && a.to == v).to;
        //                    arestavisitada = arcos.Find(a => a.from == from && a.to == v);
        //                }
        //            }
        //            else
        //            {
        //                if (arcos.Find(a => a.from == from && a.to == v).Cost + arestavisitadaFinalWhile.Cost < arcos.Find(a => a.from == arestavisitadaFinalWhile.to && a.to == v).Cost)
        //                {
        //                    smallest = arcos.Find(a => a.from == from && a.to == v).Cost;
        //                    visitado = arcos.Find(a => a.from == from && a.to == v).to;
        //                    arestavisitada = arcos.Find(a => a.from == from && a.to == v);
        //                }
        //            }
        //        }
        //        arestavisitadaFinalWhile = arestavisitada;
        //        path = path + getArco(arestavisitadaFinalWhile).ToString();
        //        costo = costo + arestavisitada.Cost;
        //        listaNaoVisitados.Remove(from);
        //        from = visitado;
        //        isPrimero = false;
        //    }
        //    Console.WriteLine(path);
        //}

        /// <summary>
        /// 
        /// </summary>
        //public void MostrarMatrizdeCosto()
        //{
        //    List<Node<T>> listaNodos = getListaNodos();
        //    List<Arc<T>> listaArcos = arcoList;

        //    for (int i = 0; i < listaNodos.Count; i++)
        //    {
        //        for (int j = 0; j < listaNodos.Count; j++)
        //        {
        //            if (arcoList.Find(a => a.from == listaNodos.ElementAt(i) && a.to == listaNodos.ElementAt(j)) != null)
        //            {
        //                int custo = arcoList.Find(a => a.from == listaNodos.ElementAt(i) && a.to == listaNodos.ElementAt(j)).Cost;
        //                matrizDeCosto[i, j] = custo;
        //            }
        //            else if (isDiriguido(arcoList.Find(a => a.from == listaNodos.ElementAt(j) && a.to == listaNodos.ElementAt(i))) == false)
        //            {
        //                int custo = arcoList.Find(a => a.from == listaNodos.ElementAt(j) && a.to == listaNodos.ElementAt(i)).Cost;
        //                matrizDeCosto[i, j] = custo;
        //            }
        //            else
        //            {
        //                matrizDeCosto[i, j] = 0;
        //            }
        //            Console.Write(matrizDeCosto[i, j].ToString() + " ");
        //        }
        //        Console.WriteLine("\n");
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public void MostrarMatrizdeAdyacencia()
        //{
        //    List<Node<T>> listaVertice = getListaNodos();
        //    List<Arc<T>> listaArcos = arcoList;
        //    for (int i = 0; i < listaVertice.Count; i++)
        //    {
        //        for (int j = 0; j < listaVertice.Count; j++)
        //        {
        //            if (arcoList.Find(a => a.from == listaVertice.ElementAt(i) && a.to == listaVertice.ElementAt(j)) != null)
        //            {
        //                matrizDeAdyacencia[i, j] = 1;
        //            }
        //            else if (isDiriguido(arcoList.Find(a => a.from == listaVertice.ElementAt(j) && a.to == listaVertice.ElementAt(i))) == false)
        //            {
        //                matrizDeAdyacencia[i, j] = 1;
        //            }
        //            else
        //            {
        //                matrizDeAdyacencia[i, j] = 0;
        //            }
        //            Console.Write(matrizDeAdyacencia[i, j].ToString() + " ");
        //        }
        //        Console.WriteLine("\n");
        //    }
        //}



    }
}
