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
    /// Interaction logic for Baldosa.xaml
    /// </summary>
    public partial class Baldosa : UserControl
    {

        /// <summary>Dependency property to Get/Set Color when IsActive is true</summary>
        public static readonly DependencyProperty ColorOnProperty =
            DependencyProperty.Register("ColorOn", typeof(SolidColorBrush), typeof(Baldosa),
                new PropertyMetadata(Brushes.Aqua, new PropertyChangedCallback(Baldosa.OnColorOnPropertyChanged)));
        /// <summary>
        /// C
        /// </summary>
        public SolidColorBrush ColorOn
        {
            get
            {
                return (SolidColorBrush)GetValue(ColorOnProperty);
            }
            set
            {
                SetValue(ColorOnProperty, value);
            }
        }

        public Baldosa()
        {
            InitializeComponent();
        }

        private static void OnColorOnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Baldosa baldosa = (Baldosa)d;
            baldosa.ColorOn = (SolidColorBrush)e.NewValue;
            //y que esto suceda o no puede estar sujeto a toda la logica que queremos...
            baldosa.explorador.Fill= baldosa.ColorOn;
          
        }

    }
}
