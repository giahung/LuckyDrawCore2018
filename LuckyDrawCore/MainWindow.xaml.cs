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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SetMainGridSize();
        }

        private void SetMainGridSize()
        {
            var h = MainGrid.ActualHeight;
            var w = MainGrid.ActualWidth;
            var r = h / w;
            var n = 512 / 1024.0;
            if (r >= n)
            {
                MainGrid.Width = w;
                MainGrid.Height = w * n;
            }
            else
            {
                MainGrid.Height = h;
                MainGrid.Width = h / n;
            }
        }
 
    }
}
