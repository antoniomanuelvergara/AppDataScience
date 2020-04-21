using DataScience.Algorithms.AprendizajeSupervisado;
using DataScience.Common;
using DataScience.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using WPFDataScience.UserControls;

namespace WPFDataScience.Supervised
{
    /// <summary>
    /// Interaction logic for FormKNeighbours.xaml
    /// </summary>
    public partial class FormKNeighbours : Window
        
    {
        //propiedad para controlar el singleton, al ser estatica es una para todas las instancias que se hagan, esto es potente.
        private static FormKNeighbours instance=null;
        public KNNModel knnmodel { get; set; }  //aqui tenemos el binding bueno,...

        //no puedo instanciar directamente un formulario por ser privado el ctor
        private FormKNeighbours()
        {
            InitializeComponent();
            
            knnmodel = new KNNModel();
            this.DataContext = this;

            Load();

        }
        /// <summary>
        /// Singleton
        /// </summary>
        /// <returns></returns>
        public static FormKNeighbours Instance()
        {
            if (instance ==null)
                instance = new FormKNeighbours();
            return instance;

        }
        /// <summary>
        /// cerrar el singleton, volvemos a poner la instancia a nula
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            instance = null;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Load()
        {

            TBConsole.Text = TBConsole.Text + "\r\n";

        }

     

        public void Tiempo()
        {

            DispatcherTimer dispathcer = new DispatcherTimer();

            //Intervalo de 1 segundo
            dispathcer.Interval = new TimeSpan(0, 0, 1);
            dispathcer.Tick += (s, a) => {
        
                TBConsole.Text = TBConsole.Text+ "hola mundo  \r\n";


            };

            dispathcer.Start();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Tiempo();
        }
        /// <summary>
        /// boton clasificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            //instanciamos 
            DataTable datos = HelperDataTable.ConvertToDataTable<Persona>(knnmodel.Datos);
            DataTable datosTest = HelperDataTable.ConvertToDataTable<Persona>(knnmodel.DatosTest);

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(datos);
            dataSet.Tables.Add(datosTest);

            // k es el segundo parametro
            KNearestNeighbours<double, DBNull> knn = new KNearestNeighbours<double, DBNull>(dataSet, 5, true);
            //obtengo las categorias
            List<string> categorias = knn.categories;

            //creamos una lista de colores
            List<SolidColorBrush> colores = new List<SolidColorBrush>
            {
              Brushes.Blue,
              Brushes.Red,
              Brushes.Yellow,
              Brushes.Green
            };

            //creo un diccionario de categorias colores
            Dictionary<string, SolidColorBrush> catcolor = new Dictionary<string, SolidColorBrush>();

            for (int i = 0; i < categorias.Count; i++)
            {
                catcolor.Add(categorias[i], colores[i]);
            }

            //para cada elemento del modelo de datos...(esto yo creo que se tendra que cambiar ya que el modelo sera muy variopinto)
            //pero siempre tendremos un objeto CLASS
            int contador = 0;
            foreach (var item in knnmodel.Datos)
            {             
                foreach (KeyValuePair<string,SolidColorBrush> item2 in catcolor)
                {

                    if (item.CLASS == item2.Key)
                    {
                        contador++;
                        grafico.CreatePoint(item.estatura, item.pelo , item2.Value, item2.Key, contador);
                    }
                }
               
            }



            //crea el punto negro
            foreach (var item in knnmodel.DatosTest)
            {
                grafico.CreatePoint(item.estatura , item.pelo, Brushes.White,"???",999);

            }

           
            Result<int, double> result = knn.Execute();

            foreach (KeyValuePair<int,double> item in result.DataDictionary)
            {
               

                TBConsole.Text = TBConsole.Text +item.Key.ToString() +":  " + item.Value.ToString() +" \r\n";
            }

            
         

        } 


    }




}



