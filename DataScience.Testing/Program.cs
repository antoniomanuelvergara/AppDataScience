using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataScience.Common;
using System.Data;
using DataScience.Algorithms.AprendizajeSupervisado;
using DataScience.Common.Graph;
using DataScience.Algorithms.Busquedas;

namespace DataScience.Testing
{
    class Program
    {
        static void Main(string[] args)
        {


            DataSet dataSet = new DataSet("Data");
            DataTable data= new DataTable("DataLearning");
            DataTable dataTest = new DataTable("DataTest");

            data.Columns.Add("Atributo1", typeof(double));
            data.Columns.Add("Atributo2", typeof(double));
            data.Columns.Add("Atributo3", typeof(double));
            data.Columns.Add("Atributo4", typeof(double));
            data.Columns.Add("CLASS", typeof(string));

            data.Rows.Add(5.1, 3.5, 1.4, 0.2, "Iris-Setosa");
            data.Rows.Add(7.0, 3.2, 4.7,1.4 ,"Iris-Versicolor");
            data.Rows.Add(5.1, 3.5, 1.4, 2.5, "Iris-Virginica");
            data.Rows.Add(5.1, 2.5, 3.4, 1.5, "Iris-Virginica");


            dataTest.Columns.Add("Atributo1", typeof(double));
            dataTest.Columns.Add("Atributo2", typeof(double));
            dataTest.Columns.Add("Atributo3", typeof(double));
            dataTest.Columns.Add("Atributo4", typeof(double));
            dataTest.Columns.Add("CLASS", typeof(string)); //siempre se llamará asi esta columna

            dataTest.Rows.Add(5.4, 3.7, 1.5, 0.2, "?");
            //dataAnalyze.Rows.Add(4.0, 0.2, 4.7, 3.4, "?");

            dataSet.Tables.Add(data);
            dataSet.Tables.Add(dataTest);

            KNearestNeighbours<double,DBNull> knn = new KNearestNeighbours<double,DBNull>(dataSet, 1,true);

            Result<int,double> result =knn.Execute(); //devuelve un diccionario key= posicion value= distancia


            //test decimal
            List<decimal> num = new List<decimal> { 1.3m, 4.0m, 5.5m, 6.8m,9.4m};
            Result<decimal,DBNull> resultado= HelperMath<decimal,DBNull>.Media(num);
            Result<decimal,DBNull> resultado11 = HelperMath<decimal,DBNull>.Mediana(num);
            Console.Write("la media es:"+ resultado.Data + resultado.Message + " ");
            Console.WriteLine("la mediana es:" + resultado11.Data + resultado11.Message);


            //test float
            List<float> num2 = new List<float> { 1.00f, 4.1f, 5.4f, 6.5f, 9.7f };
            Result<float,DBNull> resultado2 = HelperMath<float,DBNull>.Media(num2);
            Result<float,DBNull> resultado22 = HelperMath<float,DBNull>.Mediana(num2);
            Console.Write("la media es:" + resultado2.Data + resultado2.Message + " ");
            Console.WriteLine("la mediana es:" + resultado22.Data + resultado22.Message);

            //test double
            List<double> num3 = new List<double> { 1.00,4,4, 5, 6, 9,9,10.5,4,5,3,4,6,7,4,4,4.0};
            Result<double,DBNull> resultado3 = HelperMath<double,DBNull>.Media(num3);
            Result<double,DBNull> resultado32 = HelperMath<double,DBNull>.Mediana(num3);
            Console.Write("la media es:" + resultado3.Data + resultado3.Message+ " ");
            Console.WriteLine("la mediana es:" + resultado32.Data + resultado32.Message);



            //test int
            List<int> num4 = new List<int> { 2, 4, 6, 1, 9, 100,8,7 };
            Result<int,DBNull> resultado4 = HelperMath<int,DBNull>.Media(num4);
            Result<int,DBNull> resultado5 = HelperMath<int,DBNull>.Mediana(num4);
            Console.Write("la media es:" + resultado4.Data + resultado4.Message +" ");
            Console.WriteLine("la mediana es:" + resultado5.Data + resultado5.Message);


            //calculamos maximos y minimos 
            Console.WriteLine("el maximo es " + HelperMath<double,DBNull>.Maximo(num3).Data);
            Console.WriteLine("el minimo es "+ HelperMath<double,DBNull>.Minimo(num3).Data);

            Console.WriteLine("la varianza es " + HelperMath<double,DBNull>.Varianza(num3).Data);
            Console.WriteLine("la desviacion tipica es " + HelperMath<double,DBNull>.DesviacionTipica(num3).Data);
            Console.WriteLine("el coeficiente de variación es " + HelperMath<double,DBNull>.CoeficienteVariacion(num3).Data);
            Dictionary<double,int> r= HelperMath<double, int>.Moda(num3).DataDictionary;
            Console.WriteLine("la moda vale " + r.First().Value + " para el elemento de la lista de valor " +r.First().Key);


            Graph<string> graph = new Graph<string>();

            Node<string> nodo1 = new Node<string>("Sevilla");
            Node<string> nodo2 = new Node<string>("Cordoba");
            Node<string> nodo3 = new Node<string>("Madrid");
            Node<string> nodo4 = new Node<string>("Valencia");

            graph.InsertarNodo(nodo1);
            graph.InsertarNodo(nodo2);
            graph.InsertarNodo(nodo3);
            graph.InsertarNodo(nodo4);

            graph.InsertarArco(nodo1, nodo2, 10);
            graph.InsertarArco(nodo2, nodo3, 6);
            graph.InsertarArco(nodo3, nodo4, 8);
            graph.InsertarArco(nodo3, nodo1, 8);
            graph.InsertarArco(nodo4, nodo1, 4);




            //Console.WriteLine(graph.isAdyacente(nodo2, nodo3));

            List<Node<string>> nodos = graph.getListaNodos();

            //Console.WriteLine(graph.getListaNodos().Count());
            //graph.MostrarMatrizdeAdyacencia();


            BusquedaProfundidadRecursiva<string> bpr = new BusquedaProfundidadRecursiva<string>();
            bpr.RecorridoProfundidad(graph);

            //bool[] resultado=bpr.Resultado();
            //for(int i = 0; i<resultado.Length; i++)
            //{
            //    Console.WriteLine(resultado[i]);
            //}


            Console.ReadLine();






        }
    }
}
