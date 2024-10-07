using System.Windows;
using VolvoApp.Utility;
using Microsoft.Extensions.DependencyInjection;

namespace VolvoApp
{
    /// <summary>
    /// Interaction logic for ChooseWindow.xaml
    /// </summary>
    public partial class ChooseWindow : Window { 
        private readonly IServiceProvider _serviceProvider;
    
        public ChooseWindow(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(Globals.LanguageDictionary);
            LoggedUserTextBlock.Text = Globals.CurrentUser + ", " + Globals.CurrentUserDepartment;
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e) {
            Globals.CurrentUser = string.Empty;
            Globals.CurrentUserDepartment = string.Empty;
            this.Hide();
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e) {
            this.Hide();
            var encryptWindow = _serviceProvider.GetRequiredService<EncryptWindow>();
            encryptWindow.Show();
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e) {
            this.Hide();
            var decryptWindow = _serviceProvider.GetRequiredService<DecryptWindow>();
            decryptWindow.Show();
        }
    }
}
