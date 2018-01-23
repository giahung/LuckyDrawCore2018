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
            switch (DrawHelper.CurrentStage)
            {
                case 9:
                    PrizeImage.Source = new BitmapImage(new Uri("/Resource/8thPrize", UriKind.Relative));
                    break;
                case 8:
                    PrizeImage.Source = new BitmapImage(new Uri("/Resource/7thPrize", UriKind.Relative));
                    break;
                case 7:
                    PrizeImage.Source = new BitmapImage(new Uri("/Resource/6thPrize", UriKind.Relative));
                    break;
                case 6:
                    PrizeImage.Source = new BitmapImage(new Uri("/Resource/5thPrize", UriKind.Relative));
                    break;
                case 5:
                    PrizeImage.Source = new BitmapImage(new Uri("/Resource/4thPrize", UriKind.Relative));
                    break;
                case 4:
                    PrizeImage.Source = new BitmapImage(new Uri("/Resource/3thPrize", UriKind.Relative));
                    break;
                case 3:
                    PrizeImage.Source = new BitmapImage(new Uri("/Resource/2thPrize", UriKind.Relative));
                    break;
                case 2:
                    PrizeImage.Source = new BitmapImage(new Uri("/Resource/1thPrize", UriKind.Relative));
                    break;
                case 1:
                    //PrizeImage.Source = new BitmapImage(new Uri("/Resource/4thPrize", UriKind.Relative));
                    break;
                default:
                    break;
            }
            
        }
    }
}
