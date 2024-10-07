namespace VolvoApp.Encryption {
    public interface IEncryptor {
        void EncryptStringToFile(string plainText, string outputFilePath) { }
        string DecryptFileToString(string inputFilePath) => "";
    }
}
