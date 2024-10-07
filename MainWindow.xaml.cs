using System.Windows;
using VolvoApp.Data;
using VolvoApp.Utility;
using Microsoft.Extensions.DependencyInjection;

namespace VolvoApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDatabaseService _databaseService;

        public MainWindow(IServiceProvider serviceProvider, IDatabaseService databaseService) {
            _serviceProvider = serviceProvider;
            _databaseService = databaseService;
            InitializeComponent();
            SwitchLanguage("en");
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e) {
            string login = LoginTextBox.Text.ToString();
            string password = PasswordBox1.Password.ToString();

            var user = _databaseService.Login(login, password);
            if (user != null) {
                Globals.CurrentUser = user.Login;
                Globals.CurrentUserDepartment = user.Department;
                this.Hide();
                var chooseWindow = _serviceProvider.GetRequiredService<ChooseWindow>();
                chooseWindow.Show();
            }
            else {
                SuccessTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void SwitchLanguage(string langCode) {
            switch (langCode) {
                case "en":
                    Globals.LanguageDictionary.Source = new Uri("..\\Languages\\StringResources.en.xaml", UriKind.Relative);
                    break;
                case "ua":
                    Globals.LanguageDictionary.Source = new Uri("..\\Languages\\StringResources.ua.xaml", UriKind.Relative);
                    break;
                default:
                    Globals.LanguageDictionary.Source = new Uri("..\\Languages\\StringResources.en.xaml", UriKind.Relative);
                    break;
            }

            this.Resources.MergedDictionaries.Add(Globals.LanguageDictionary);
        }

        private void UaMenuItem_Click(object sender, RoutedEventArgs e) {
            SwitchLanguage("ua");
        }

        private void EnMenuItem_Click(object sender, RoutedEventArgs e) {
            SwitchLanguage("en");
        }
    }
}