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

namespace WindowsSwitchesWPF.Controls
{
    /// <summary>
    /// Interaction logic for PlayButton.xaml
    /// </summary>
    public partial class PlayButton : UserControl
    {
        public PlayButton()
        {
            InitializeComponent();
        }

        private void Viewbox_MouseEnter(object sender, MouseEventArgs e)
        {
            mainEllipse.Fill = new SolidColorBrush(Colors.DarkGray);
            mainEllipse.Fill = new SolidColorBrush(Colors.DarkGray);
        }

        private void Viewbox_MouseLeave(object sender, MouseEventArgs e)
        {
            mainEllipse.Fill = new SolidColorBrush(Colors.Gray);
            mainEllipse.Stroke = new SolidColorBrush(Colors.Gray);
        }

        private void Viewbox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Color color = Colors.Gray;
            color.R -= 50;
            color.G -= 50;
            color.B -= 50;
            mainEllipse.Fill = new SolidColorBrush(color);
            mainEllipse.Stroke = new SolidColorBrush(Colors.Transparent);
        }

        private void Viewbox_MouseUp(object sender, MouseButtonEventArgs e)
        {           
            mainEllipse.Fill = new SolidColorBrush(Colors.Gray);
            mainEllipse.Stroke = new SolidColorBrush(Colors.Gray);
        }
    }
}
