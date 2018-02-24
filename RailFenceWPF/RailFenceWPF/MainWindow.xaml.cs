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

namespace RailFenceWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encrypt(object sender, RoutedEventArgs e)
        {
            var rail = 4;
            int.TryParse(EncryptHeight.Text ,out rail);
            var plainText = EncryptInput.Text;
            var railFence = new List<string>();

            for (var i = 0; i < rail; i++)
            {
                railFence.Add(string.Empty);
            }

            var number = 0;
            var increment = 1;

            foreach (var c in plainText)
            {
                if (number + increment == rail)
                {
                    increment = -1;
                }
                else if (number + increment == -1)
                {
                    increment = 1;
                }
                railFence[number] += c;
                number += increment;
            }

            var buffer = string.Empty;

            foreach (var s in railFence)
            {
                buffer += s;
            }

            EncryptedText.Text = buffer;
        }

        private void Decrypt(object sender, RoutedEventArgs e)
        {
            var rail = 4;
            var cipherLength = DecryptInput.Text.Length;
            var cipherText = DecryptInput.Text;
            int.TryParse(DecryptHeight.Text ,out rail);
            var railFence = new List<List<int>>();

            for (var i = 0; i < rail; i++)
            {
                railFence.Add(new List<int>());
            }

            var number = 0;
            var increment = 1;

            for (var i = 0; i < cipherLength; i++)
            {
                if (number + increment == rail)
                {
                    increment = -1;
                }
                else if (number + increment == -1)
                {
                    increment = 1;
                }
                railFence[number].Add(i);
                number += increment;
            }

            var counter = 0;
            var buffer = new char[cipherLength];

            for (int i = 0; i < rail; i++)
            {
                for (var j = 0; j < railFence[i].Count; j++)
                {
                    buffer[railFence[i][j]] = cipherText[counter];
                    counter++;
                }
            }

            DecryptedText.Text = new string(buffer); 
        }
    }
}
