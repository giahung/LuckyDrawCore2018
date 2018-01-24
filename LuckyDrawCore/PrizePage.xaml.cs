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

namespace LuckyDrawCore
{
    /// <summary>
    /// Interaction logic for PrizePage.xaml
    /// </summary>
    public partial class PrizePage : Page
    {
        public PrizePage()
        {
            InitializeComponent();
            Loaded += PrizePage_Loaded;
        }

        private void PrizePage_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyUp += Window_KeyUp;

            switch (DrawHelper.CurrentStage)
            {
                case 9:
                    PrizeImage.Source = new BitmapImage(new Uri("/Resources/8thPrize.png", UriKind.Relative));
                    break;
                case 8:
                    PrizeImage.Source = new BitmapImage(new Uri("/Resources/7thPrize.png", UriKind.Relative));
                    break;
                case 7:
                    PrizeImage.Source = new BitmapImage(new Uri("/Resources/6thPrize.png", UriKind.Relative));
                    break;
                case 6:
                    PrizeImage.Source = new BitmapImage(new Uri("/Resources/5thPrize.png", UriKind.Relative));
                    break;
                case 5:
                    PrizeImage.Source = new BitmapImage(new Uri("/Resources/4thPrize.png", UriKind.Relative));
                    break;
                case 4:
                    PrizeImage.Source = new BitmapImage(new Uri("/Resources/3rdPrize.png", UriKind.Relative));
                    break;
                case 3:
                    PrizeImage.Source = new BitmapImage(new Uri("/Resources/2ndPrize.png", UriKind.Relative));
                    break;
                case 2:
                    PrizeImage.Source = new BitmapImage(new Uri("/Resources/1stPrize.png", UriKind.Relative));
                    break;
                case 1:
                    window.KeyUp -= Window_KeyUp;
                    //PrizeImage.Source = new BitmapImage(new Uri("/Resources/4thPrize.png", UriKind.Relative));
                    NavigationService.Navigate(new Uri("ThankPage.xaml", UriKind.Relative));
                    break;
                default:
                    window.KeyUp -= Window_KeyUp;
                    NavigationService.Navigate(new Uri("ThankPage.xaml", UriKind.Relative));
                    break;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F1:
                    (sender as Window).KeyUp -= Window_KeyUp;
                    NavigationService.Navigate(new Uri("DrawPage.xaml", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }
    }
}
