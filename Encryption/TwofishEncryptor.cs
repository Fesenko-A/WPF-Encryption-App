using System.Text;
using System.IO;
using VolvoApp.Utility;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;

namespace VolvoApp.Encryption
{
    public class TwofishEncryptor : IEncryptor
    {
        private static readonly byte[] iv = Encoding.UTF8.GetBytes("5132578943216093");
        private static readonly byte[] key = Encoding.UTF8.GetBytes(Globals.MyKey.PadRight(32).Substring(0, 32));

        public void EncryptStringToFile(string plainText, string outputFilePath) {
            IBlockCipher engine = new TwofishEngine();
            BufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(engine));
            cipher.Init(true, new ParametersWithIV(new KeyParameter(key), iv));

            byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] outputBytes = new byte[cipher.GetOutputSize(inputBytes.Length)];
            int length = cipher.ProcessBytes(inputBytes, 0, inputBytes.Length, outputBytes, 0);
            cipher.DoFinal(outputBytes, length);

            File.WriteAllBytes(outputFilePath, outputBytes);
        }

        public string DecryptFileToString(string inputFilePath) {
            IBlockCipher engine = new TwofishEngine();
            BufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(engine));
            cipher.Init(false, new ParametersWithIV(new KeyParameter(key), iv));

            byte[] inputBytes = File.ReadAllBytes(inputFilePath);
            byte[] outputBytes = new byte[cipher.GetOutputSize(inputBytes.Length)];
            int length = cipher.ProcessBytes(inputBytes, 0, inputBytes.Length, outputBytes, 0);
            length += cipher.DoFinal(outputBytes, length);

            return Encoding.UTF8.GetString(outputBytes, 0, length).TrimEnd('\0');
        }
    }
}
