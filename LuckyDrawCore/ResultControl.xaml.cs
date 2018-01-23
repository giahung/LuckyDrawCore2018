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
using System.Windows.Threading;

namespace LuckyDrawCore
{
    /// <summary>
    /// Interaction logic for ResultControl.xaml
    /// </summary>
    public partial class ResultControl : UserControl
    {
        public ResultControl()
        {
            InitializeComponent();
        }

        private Random rand = new Random();
        private DispatcherTimer timer = new DispatcherTimer();
        public void StartAnimation()
        {
            timer.Interval = TimeSpan.FromMilliseconds(25);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            firstNum.Text = rand.Next(10).ToString();
            secondNum.Text = rand.Next(10).ToString();
            thirdNum.Text = rand.Next(10).ToString();
        }

        public void SetResult(string rs)
        {
            timer.Stop();
            timer.Tick -= timer_Tick;
            firstNum.Text = rs[0] + "";
            secondNum.Text = rs[1] + "";
            thirdNum.Text = rs[2] + "";
        }
    }
}
