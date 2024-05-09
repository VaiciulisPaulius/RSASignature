using System.Security.Cryptography;
using System.Text;

namespace RSASignature
{
    public partial class Form1 : Form
    {

        private ClientServer server;

        RSAParameters PubKey;
        public Form1()
        {
            InitializeComponent();
            InitializeServer();
            Form1_Load();
        }

        private void InitializeServer()
        {
            server = new ClientServer();
        }
        private void OnAddressConfirm(object sender, EventArgs e)
        {

        }
        private void Form1_Load()
        {
            try
            {
                string ip = server.GetLocalIPAddress();

                ipInfoBox.Text = ip;

            }
            catch (Exception ex) { }
            //ipInfoBox.Text = "Hello";
        }
        private async void ConnectToServerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = serverAddressInputBox.Text;
                int host = Convert.ToInt32(serverHostInputBox.Text);

                if (ip == null || host == null) return;

                Task<bool> success = server.Connect(ip, host);
                bool isConnected = await success;

                if (isConnected)
                {
                    statusLabel.Text = "statusas: Prisijungta.";
                }
                else
                {
                    statusLabel.Text = "statusas: Nepavyko prisijungti.";
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The data was not signed or verified");
            }
        }
        private void SendData_Click(object sender, EventArgs e)
        {
            server.SendObject(PubKey);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a UnicodeEncoder to convert between byte array and string.
                ASCIIEncoding ByteConverter = new ASCIIEncoding();

                string dataString = textInputBox.Text;

                // Create byte arrays to hold original, encrypted, and decrypted data.
                byte[] originalData = ByteConverter.GetBytes(dataString);
                byte[] signedData;

                // Create a new instance of the RSACryptoServiceProvider class
                // and automatically create a new key-pair.
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

                // Export the key information to an RSAParameters object.
                // You must pass true to export the private key for signing.
                // However, you do not need to export the private key
                // for verification.
                RSAParameters PrivKey = RSAalg.ExportParameters(true);
                PubKey = RSAalg.ExportParameters(false);

                // Hash and sign the data.
                signedData = HashAndSignBytes(originalData, PrivKey);

                string signedDataText = Convert.ToBase64String(signedData);

                modulusField1.Text = Convert.ToBase64String(PrivKey.Modulus);
                modulusField2.Text = Convert.ToBase64String(PrivKey.Modulus);

                privateExponentField.Text = Convert.ToBase64String(PrivKey.D);
                publicExponentField.Text = Convert.ToBase64String(PubKey.Exponent);



                rsaSignatureField.Text = signedDataText;

                // Verify the data and display the result to the
                // console.
                if (VerifySignedHash(originalData, signedData, PrivKey))
                {
                    Console.WriteLine("The data was verified.");
                }
                else
                {
                    Console.WriteLine("The data does not match the signature.");
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The data was not signed or verified");
            }

        }
        public static byte[] HashAndSignBytes(byte[] DataToSign, RSAParameters Key)
        {
            try
            {
                // Create a new instance of RSACryptoServiceProvider using the
                // key from RSAParameters.
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

                RSAalg.ImportParameters(Key);

                // Hash and sign the data. Pass a new instance of SHA256
                // to specify the hashing algorithm.
                return RSAalg.SignData(DataToSign, SHA256.Create());
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public static bool VerifySignedHash(byte[] DataToVerify, byte[] SignedData, RSAParameters Key)
        {
            try
            {
                // Create a new instance of RSACryptoServiceProvider using the
                // key from RSAParameters.
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

                RSAalg.ImportParameters(Key);

                // Verify the data using the signature.  Pass a new instance of SHA256
                // to specify the hashing algorithm.
                return RSAalg.VerifyData(DataToVerify, SHA256.Create(), SignedData);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }
    }
}