﻿using MahApps.Metro.Controls;
using RejestrOsobowy.AppWPF.ViewModels.WindowViewModels;
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
using System.Windows.Shapes;

namespace RejestrOsobowy.AppWPF.Windows
{
    /// <summary>
    /// Interaction logic for PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : MetroWindow
    {
        PersonWindowViewModel vm;
        public PersonWindow(PersonWindowViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            this.DataContext = new
            {
                vm = this.vm,
            };
        }
    }
}
