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

namespace WPFDataScience.UserControls
{
    /// <summary>
    /// Interaction logic for Punto.xaml
    /// </summary>
    public partial class Punto : UserControl
    {
        public double CoordX { get; set; }
        public double CoordY { get; set; }
        public SolidColorBrush color { get; set;}
        public string categoria { get; set; }        
        public int Id { get; set; }


        public Punto()
        {
            InitializeComponent();
        }


        public Punto(double coordX, double coordY, SolidColorBrush color, string categoria, int id)
        {
            InitializeComponent();
            CoordX = (coordX *500)+45;
            CoordY = ((1-coordY)*500)+45;
            this.color = color;
            pto.Fill = color;
            Id = id;
            Nota.Visibility = Visibility.Hidden;
            LbCategoria.Visibility = Visibility.Hidden;
            LbCoordX.Visibility = Visibility.Hidden;
            LbCoordY.Visibility = Visibility.Hidden;
            LbId.Visibility = Visibility.Hidden;
            area.Visibility = Visibility.Hidden;

            LbCategoria.Content = categoria;
            LbCoordX.Content = "X:" +coordX.ToString();
            LbCoordY.Content = "Y:" + coordY.ToString();
            LbId.Content = "ID:" + Id.ToString();


        }

        private void pto_MouseEnter(object sender, MouseEventArgs e)
        {
            Nota.Visibility = Visibility.Visible;
            LbCategoria.Visibility = Visibility.Visible;
            LbCoordX.Visibility = Visibility.Visible;
            LbCoordY.Visibility = Visibility.Visible;
            LbId.Visibility = Visibility.Visible;
            if(pto.Fill==Brushes.White)
            {
                area.Visibility = Visibility.Visible;
            }
        }

        private void pto_MouseLeave(object sender, MouseEventArgs e)
        {
            Nota.Visibility = Visibility.Hidden;
            LbCategoria.Visibility = Visibility.Hidden;
            LbCoordX.Visibility = Visibility.Hidden;
            LbCoordY.Visibility = Visibility.Hidden;
            LbId.Visibility = Visibility.Hidden;
            if (pto.Fill == Brushes.White)
            {
                area.Visibility = Visibility.Hidden;
            }

        }
    }
}
