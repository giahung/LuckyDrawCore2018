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
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
            this.Loaded += WelcomePage_Loaded;
        }

        private void WelcomePage_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyUp += Window_KeyUp;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.F1:
                    (sender as Window).KeyUp -= Window_KeyUp;
                    NavigationService.Navigate(new Uri("DrawPage16.xaml", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }
    }
}
