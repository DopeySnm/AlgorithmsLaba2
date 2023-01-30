using AlgorithmsLaba2.Sevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace AlgorithmsLaba2.View
{
    public partial class DragonCurveFractalPage : Page
    {
        private DragonCurveFractal dragonCurveFractal;
        public DragonCurveFractalPage()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            dragonCurveFractal = new DragonCurveFractal(canvas, tbLabel);
            dragonCurveFractal.CheckAndStart(inputRings, sender, e);
        }
        private void but_ClickBack(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainMenu();
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
