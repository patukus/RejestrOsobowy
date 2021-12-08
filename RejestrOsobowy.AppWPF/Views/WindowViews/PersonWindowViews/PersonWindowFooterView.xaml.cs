﻿using RejestrOsobowy.AppWPF.ViewModels.WindowViewModels;
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

namespace RejestrOsobowy.AppWPF.Views.WindowViews.PersonWindowViews
{
    /// <summary>
    /// Interaction logic for PersonWindowFooterView.xaml
    /// </summary>
    public partial class PersonWindowFooterView : UserControl
    {
        PersonWindowViewModel vm;
        public PersonWindowFooterView(PersonWindowViewModel vm)
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
