﻿using System;
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
        public DrawPage()
        {
            InitializeComponent();
            this.Loaded += DrawPage_Loaded;
        }

        void DrawPage_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyUp += window_KeyUp;
        }

        private void window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    if (firstTimePress)
                    {
                        Result.StartAnimation();
                    }
                    else
                    {
                        Result.SetResult(DrawHelper.GetWinner());
                    }
                    firstTimePress = !firstTimePress;
                    break;               
                default:
                    break;
            }
        }
    }

}
