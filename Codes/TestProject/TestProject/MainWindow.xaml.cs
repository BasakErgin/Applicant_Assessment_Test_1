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

namespace TestProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPickByUser_Click(object sender, RoutedEventArgs e)
        {
            WindowMachinePredict w = new WindowMachinePredict();
            w.Show();
            Close();
        }

        private void BtnPickByMachine_Click(object sender, RoutedEventArgs e)
        {
            WindowUserPredict w = new WindowUserPredict();
            w.Show();
            Close();
        }
    }
}