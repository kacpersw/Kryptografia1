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

namespace PrzestawieniaMacierzowe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int d = 5;
        //private int d = 4; // It's for example in pdf

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encrypt(object sender, RoutedEventArgs e)
        {
             var keys = new int[] { 2, 3, 0, 4, 1 };
            // var keys = new int[] { 2, 0, 3, 1 }; // It's for example in pdf

            var length = EncryptInput.Text.Length;
            var text = EncryptInput.Text;
            var encryptedText = new char[length];

            while (text.Length % d != 0)
                text = text + " ";

            var lengthToArray = text.Length;
            var position = 0;
            var encryptedTextHelper = new char[lengthToArray];

            foreach (var key in keys)
            {
                var counter = key;
                for (var i = position; i < lengthToArray; i += d, counter += d)
                {
                    if (counter < length)
                        encryptedTextHelper[i] = text[counter];
                }
                position++;
            }

            var encryptedTextLength = 0;
            var helperIterator = 0;

            while (encryptedTextLength != length)
            {
                if (encryptedTextHelper[helperIterator] != '\0')
                {
                    encryptedText[encryptedTextLength] = encryptedTextHelper[helperIterator];
                    encryptedTextLength++;
                }
                helperIterator ++;
            }

            EncryptedText.Text = new string(encryptedText);
        }

        private void Decrypt(object sender, RoutedEventArgs e)
        {
            var keys = new int[] { 2, 3, 0, 4, 1 };

            var length = DecryptInput.Text.Length;
            var text = DecryptInput.Text;
            var decryptedText = new char[length];

            while (text.Length % d != 0)
                text = text + " ";

            var lengthToArray = text.Length;
            var decryptedTextHelper = new char[lengthToArray];
            var counterHelper = 0;
            foreach (var key in keys)
            {
                var counter = key;

                for (var i = counterHelper; i < lengthToArray; i += d, counter += d)
                {
                    if (i < length)
                        decryptedTextHelper[counter] = text[i];
                }
                counterHelper++;
            }

            var decryptedTextLength = 0;
            var helperIterator = 0;

            while (decryptedTextLength != length)
            {
                if (decryptedTextHelper[helperIterator] != '\0')
                {
                    decryptedText[decryptedTextLength] = decryptedTextHelper[helperIterator];
                    decryptedTextLength++;
                }
                helperIterator++;
            }

            DecryptedText.Text = new string(decryptedText);
        }
    }
}
