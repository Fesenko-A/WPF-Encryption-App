using System.Windows;
using Microsoft.Win32;
using VolvoApp.Data;
using VolvoApp.Utility;
using VolvoApp.Encryption;
using VolvoApp.MessageBoxes;
using Microsoft.Extensions.DependencyInjection;

namespace VolvoApp
{
    /// <summary>
    /// Interaction logic for DecryptWindow.xaml
    /// </summary>
    public partial class DecryptWindow : Window {
        private readonly IEncryptor _encryptor;
        private readonly IDatabaseService _databaseService;
        private readonly IServiceProvider _serviceProvider;

        public DecryptWindow(IEncryptor encryptor, IDatabaseService databaseService, IServiceProvider serviceProvider) {
            _encryptor = encryptor;
            _databaseService = databaseService;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(Globals.LanguageDictionary);
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e) {
            string password = DecryptionPasswordBox.Password.ToString();
            if (password != Globals.MyKey) {
                IncorrectPasswordWindow window = new IncorrectPasswordWindow();
                window.Show();
                return; 
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            openFileDialog.InitialDirectory = Globals.CommonFolderPath;
            openFileDialog.ShowDialog();

            string filePath = string.Empty, folderDepartment = string.Empty;
            string[] splitFilePath;

            try {
                filePath = openFileDialog.FileName;
                splitFilePath = filePath.Split("\\");
                folderDepartment = splitFilePath[^2];  // second element from the back
            }
            catch (IndexOutOfRangeException) {
                FilePathTextBlock.Text = "Error";
                return;
            }

            if (!Globals.CurrentUserDepartment.Contains(folderDepartment) && folderDepartment != "All") {
                AccessDeniedWindow window = new AccessDeniedWindow();
                window.Show();
            }
            else {
                FilePathTextBlock.Text = filePath;
                string decryptedText = _encryptor.DecryptFileToString(filePath);
                MainTextBox.Text = decryptedText;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) {
            this.Hide();
            var chooseWindow = _serviceProvider.GetRequiredService<ChooseWindow>();
            chooseWindow.Show();
        }
    }
}
