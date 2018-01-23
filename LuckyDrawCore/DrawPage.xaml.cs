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
    /// Interaction logic for DrawPage.xaml
    /// </summary>
    public partial class DrawPage : Page
    {
        private bool firstTimePress = true;
        private bool hasResult = false;
        public DrawPage()
        {
            InitializeComponent();
            this.Loaded += DrawPage_Loaded;
        }

        void DrawPage_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyUp += Window_KeyUp;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    if (!hasResult)
                    {
                        if (firstTimePress)
                        {
                            Result.StartAnimation();
                            btnStart.Source = new BitmapImage(new Uri("Resources/bgButtonStop.png", UriKind.Relative));
                        }
                        else
                        {
                            hasResult = true;
                            Result.SetResult(DrawHelper.GetWinner());
                            btnStart.Source = new BitmapImage(new Uri("Resources/bgButtonStart.png", UriKind.Relative));
                        }
                        firstTimePress = !firstTimePress;
                    }
                    break;
                case Key.F2:
                    if (firstTimePress && hasResult)
                    {
                        hasResult = false;
                        Result.SetResult("000");
                    }
                    break;
                case Key.F1:
                    if (firstTimePress && hasResult)
                    {
                        (sender as Window).KeyUp -= Window_KeyUp;
                        if (--DrawHelper.CurrentStage == 10)
                        {
                            NavigationService.Navigate(new Uri("DrawPage16.xaml", UriKind.Relative));
                        }
                        else
                        {
                            NavigationService.Navigate(new Uri("PrizePage.xaml", UriKind.Relative));
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }

}
