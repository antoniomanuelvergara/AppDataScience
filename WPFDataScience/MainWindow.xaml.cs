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
using WPFDataScience.Examples;
using WPFDataScience.Supervised;

namespace WPFDataScience
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KNeighbours_Click(object sender, RoutedEventArgs e)
        {
            //puedo hacer eso porque instance es statica, no puedo instanciar el formulario porque su constructor es privado
            FormKNeighbours K = FormKNeighbours.Instance();

            //vamos a meter un singleton para practicar
            K.Show();
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //puedo hacer eso porque instance es statica, no puedo instanciar el formulario porque su constructor es privado
            FormQLearning K = new FormQLearning();

            //vamos a meter un singleton para practicar
            K.Show();
        }
    }
}
