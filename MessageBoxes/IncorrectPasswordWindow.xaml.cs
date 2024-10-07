﻿using System.Windows;
using VolvoApp.Utility;

namespace VolvoApp.MessageBoxes {
    /// <summary>
    /// Interaction logic for IncorrectPasswordWindow.xaml
    /// </summary>
    public partial class IncorrectPasswordWindow : Window {
        public IncorrectPasswordWindow() {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(Globals.LanguageDictionary);
        }

        private void OkButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}