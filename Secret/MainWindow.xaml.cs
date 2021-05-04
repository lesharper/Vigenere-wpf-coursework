using System;
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

namespace Secret
{
    public partial class MainWindow : Window
    {
        public bool isEncrypt;
        public bool isDecrypt;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void rdbIsEncrypt_Checked(object sender, RoutedEventArgs e)
        {
            isEncrypt = true;
            isDecrypt = false;
        }

        private void rdbIsDecrypt_Checked(object sender, RoutedEventArgs e)
        {
            isDecrypt = true;
            isEncrypt = false;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            var cipher = new VigenerCipher();

            if ((txtInitial != null) && (txtKey != null) && isEncrypt)
            {
                var encryptedText = cipher.Encrypt(txtInitial.Text, txtKey.Text);
                txtChange.Text = encryptedText;
            }
            else if ((txtInitial != null) && (txtKey != null) && isDecrypt)
            {
                var decryptText = cipher.Decrypt(txtInitial.Text, txtKey.Text);
                txtChange.Text = decryptText;
            }

        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txtChange.Text);
        }
    }
}
