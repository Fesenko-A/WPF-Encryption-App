using System.IO;
using System.Windows;
using VolvoApp.Utility;
using VolvoApp.Encryption;
using VolvoApp.MessageBoxes;
using Microsoft.Extensions.DependencyInjection;

namespace VolvoApp
{
    /// <summary>
    /// Interaction logic for EncryptWindow.xaml
    /// </summary>
    public partial class EncryptWindow : Window {
        private readonly IEncryptor _encryptor;
        private readonly IServiceProvider _serviceProvider;

        public EncryptWindow(IEncryptor encryptor, IServiceProvider serviceProvider) {
            _encryptor = encryptor;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(Globals.LanguageDictionary);  // languages support
        }

        private void BackButton_Click(object sender, RoutedEventArgs e) {
            this.Hide();
            var chooseWindow = _serviceProvider.GetRequiredService<ChooseWindow>();
            chooseWindow.Show();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e) {
            string password = EncryptionPasswordBox.Password.ToString();
            if (password != Globals.MyKey) {
                IncorrectPasswordWindow window = new IncorrectPasswordWindow();
                window.Show();
                return;
            }

            string newFolder = string.Concat(Globals.CommonFolderPath, string.Concat(RecipientComboBox.Text.ToString(), "\\"));
            Directory.CreateDirectory(newFolder);

            string fileName = string.Concat(TopicTextBox.Text.ToString(), ".txt");
            string text = MainTextBox.Text.ToString();
            string newFilePath = string.Concat(newFolder, fileName);
            _encryptor.EncryptStringToFile(text, newFilePath);

            MessageBox.Show($"OK\n{newFilePath}");
        }
    }
}
