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
    /// Interaction logic for Grafico.xaml
    /// </summary>
    public partial class Grafico : UserControl
    {

        List<Punto> points { get; set;} 


        public Grafico()
        {
            InitializeComponent();
            points= new List<Punto>();
        }
        /// <summary>
        /// 
        /// </summary>
        public void CreatePoint(double x, double y, SolidColorBrush color, string categoria ,int id)
        {
            Punto auxPoint = new Punto(x, y, color, categoria, id);
           
            points.Add(auxPoint);
            AddChildren(auxPoint);
            
            Canvas.SetLeft(auxPoint, auxPoint.CoordX);
            Canvas.SetTop(auxPoint, auxPoint.CoordY);



        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="punto"></param>
        private void AddChildren(Punto punto)
        {
            graph.Children.Add(punto);
        }



    }
}
