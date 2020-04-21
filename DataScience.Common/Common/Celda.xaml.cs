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
    /// Interaction logic for Celda.xaml
    /// </summary>
    public partial class Celda : UserControl
    {
        public Estado EstadoCelda { get; set; }

        public int Fila { get; set; }
        public int Columna { get; set; }
        ///public int Recompensa { get; set; }

        private int recompensa=0;

        public int Recompensa
        {
            get {

                return recompensa;

            }
            set {
                LbRecompensa.Foreground = Brushes.White;
                LbRecompensa.Content =  "R:" + value.ToString();
                recompensa = value;

            }
        }


        public Celda()
        {
            InitializeComponent();
        }

        public Celda(int fila, int columna)
        {

            InitializeComponent();
            EstadoCelda = new Vacia(this);
            Fila = fila;
            Columna = columna;
            LbFila.Content = LbFila.Content + ":" + Fila.ToString();
            LbColumna.Content = LbColumna.Content + ":" + Columna.ToString();
            LbRecompensa.Content = LbRecompensa.Content + ":" + Recompensa.ToString();

        }

        public void CalcularLoQueSea()
        {
            EstadoCelda.CalcularLoqueSea();
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            cuadrito.Background = Brushes.Orange;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            cuadrito.Background = Brushes.Gray;
        }
    }
}
