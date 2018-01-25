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
    public partial class DrawPage16 : Page
    {
        private bool firstTimePress = true;
        private bool hasResult = false;
        private List<ResultControl> resultControls = new List<ResultControl>();
        public DrawPage16()
        {
            InitializeComponent();
            this.Loaded += DrawPage_Loaded;
        }

        void DrawPage_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyUp += Window_KeyUp;
            RenderResultControl();
        }

        private void RenderResultControl()
        {
            for (int i = 0; i < 16; i++)
            {
                var rc = new ResultControl();
                rc.SetValue(Grid.RowProperty, i / 4);
                rc.SetValue(Grid.ColumnProperty, i % 4);
                rc.SetValue(MarginProperty, new Thickness(15, 5, 15, 5));
                rc.Width = 41 * 3;
                rc.Height = 65;
                Container.Children.Add(rc);
                resultControls.Add(rc);
            }
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
                            btnStart.Visibility = Visibility.Hidden;
                            foreach (var item in resultControls)
                            {
                                item.StartAnimation();
                            }
                            //btnStart.Source = new BitmapImage(new Uri("Resources/bgButtonStop.png", UriKind.Relative));
                        }
                        else
                        {
                            foreach (var item in resultControls)
                            {
                                item.SetResult(DrawHelper.GetWinner());
                            }
                            hasResult = true;
                            //btnStart.Source = new BitmapImage(new Uri("Resources/bgButtonStart.png", UriKind.Relative));
                        }
                        firstTimePress = !firstTimePress;
                    }
                    break;
                case Key.F2:
                    if (firstTimePress && hasResult)
                    {
                        (sender as Window).KeyUp -= Window_KeyUp;
                        NavigationService.Navigate(new Uri("DrawPage.xaml", UriKind.Relative));
                    }
                    break;
                case Key.F1:
                    if (firstTimePress && hasResult)
                    {
                        if (--DrawHelper.CurrentStage == 10)
                        {
                            hasResult = false;
                            foreach (var item in resultControls)
                            {
                                item.SetResult("000");
                            }
                        }
                        else
                        {
                            (sender as Window).KeyUp -= Window_KeyUp;
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
