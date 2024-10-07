using System.Windows;
using VolvoApp.Utility;

namespace VolvoApp.MessageBoxes {
    /// <summary>
    /// Interaction logic for AccessDeniedWindow.xaml
    /// </summary>
    public partial class AccessDeniedWindow : Window {
        public AccessDeniedWindow() {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(Globals.LanguageDictionary);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
