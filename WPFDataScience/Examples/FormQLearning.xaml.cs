using DataScience.Common.Common;
using DataScience.Common.Graph;
using DataScience.Common.Model;
using DataScience.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WPFDataScience.UserControls;

namespace WPFDataScience.Examples
{
    /// <summary>
    /// Interaction logic for WinTest.xaml
    /// </summary>
    public partial class FormQLearning : Window
    {

        public QLearningMVVM qLearningMVVM { get; set; }
        

      


        public FormQLearning()
        {

            InitializeComponent();
            this.DataContext = this;

  

            qLearningMVVM = new QLearningMVVM();

            //dimensionX =6;
            //dimensionY =6;
           

            CBFilas.Items.Add("1");
            CBFilas.Items.Add("2");
            CBFilas.Items.Add("3");
            CBFilas.Items.Add("4");
            CBFilas.Items.Add("5");
            CBFilas.Items.Add("6");
            CBFilas.Items.Add("7");
            CBFilas.Items.Add("8");
            CBFilas.Items.Add("9");
            CBFilas.Items.Add("10");

            CBColumnas.Items.Add("1");
            CBColumnas.Items.Add("2");
            CBColumnas.Items.Add("3");
            CBColumnas.Items.Add("4");
            CBColumnas.Items.Add("5");
            CBColumnas.Items.Add("6");
            CBColumnas.Items.Add("7");
            CBColumnas.Items.Add("8");
            CBColumnas.Items.Add("9");
            CBColumnas.Items.Add("10");


            CBFilas.SelectedIndex = 5;
            CBColumnas.SelectedIndex = 5;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            qLearningMVVM.Explorar();

           
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            
            qLearningMVVM.CrearTablero(Convert.ToInt32(CBFilas.Text), Convert.ToInt32(CBColumnas.Text));

            cuadro.Children.Add(qLearningMVVM.Tablero);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            qLearningMVVM.ExplorarRapido();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //esto ejecutará el algoritmo QLearning
            qLearningMVVM.ExecuteQLearning();
        }
    }
}
