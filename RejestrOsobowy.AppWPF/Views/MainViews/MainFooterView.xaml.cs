﻿using RejestrOsobowy.AppWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RejestrOsobowy.AppWPF.Views.MainViews
{
    /// <summary>
    /// Interaction logic for MainFooterView.xaml
    /// </summary>
    public partial class MainFooterView : UserControl
    {
        MainViewModel vm;
        public MainFooterView(MainViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            this.DataContext = new
            {
                vm = this.vm,
            };
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            vm._SearchTimer.Stop();
            vm._SearchTimer.Start();
        }
    }
}