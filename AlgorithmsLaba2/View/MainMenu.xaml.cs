using AlgorithmsLaba2.ViewModels;
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

namespace AlgorithmsLaba2.View
{
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private void Button_ClickOpenHanoinTowers(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new HanoiTowerPage();
        }

        private void Button_ClickOpenDragonCurveFractal(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new DragonCurveFractalPage();
        }

        private void Button_ClickExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
