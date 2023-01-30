using AlgorithmsLaba2.Model;
using AlgorithmsLaba2.Sevice;
using AlgorithmsLaba2.View;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AlgorithmsLaba2.ViewModels
{
    public partial class HanoiTowerPage : Page
    {
        private HanoiTower hanoiTower;
        public HanoiTowerPage()
        {
            InitializeComponent();
        }
        private void but_ClickStart(object sender, RoutedEventArgs e)
        {
            if (hanoiTower != null)
            {
                hanoiTower.Start(100);
            }
        }
        private void but_ClickGet(object sender, RoutedEventArgs e)
        {
            if (hanoiTower != null)
            {
                hanoiTower.ClearAllTowers();
            }
            hanoiTower = new HanoiTower(tower1, tower2, tower3, inputRings);
            hanoiTower.GetRings(inputRings.Text);
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
