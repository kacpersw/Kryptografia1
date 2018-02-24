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

namespace PrzestawieniaMacierzowe2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encrypt(object sender, RoutedEventArgs e)
        {
            var key = EncryptKey.Text.ToCharArray();
            var keys = GetKeys(key);

            var encryptedText = string.Empty;
            var text = EncryptInput.Text;
            var words = new string[keys.Length];

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = i; j < text.Length; j += key.Length)
                {
                    if (j < text.Length)
                        words[i] += text[j];
                }
            }
            for (int i = 0; i < keys.Length; i++)
            {
                encryptedText += words[GetPosition(keys, i)];
            }

            EncryptedText.Text = encryptedText;
        }

        private void Decrypt(object sender, RoutedEventArgs e)
        {
            var key = DecryptKey.Text;
            var keyToGetKeys = DecryptKey.Text.ToCharArray();
            var keys = GetKeys(keyToGetKeys);

            var decryptedText = string.Empty;
            var text = DecryptInput.Text;
            var textHelper = text;

            var keyLength = key.Length;
            var textLength = text.Length;

            //get words

            var words = new List<string>();
            while (textLength != 0)
            {
                var floatScore = (float)textLength / keyLength;
                var intScore = textLength / keyLength;

                var wordLength = (floatScore > (float)intScore) ? intScore + 1 : intScore;
                words.Add(textHelper.Substring(0, wordLength));
                textHelper = textHelper.Substring(wordLength, textHelper.Length - wordLength);
                textLength = textHelper.Length;
                keyLength--;
            }

            var wordsInGoodOrder = new List<string>();

            for (int i = 0; i < keys.Length; i++)
            {
                wordsInGoodOrder.Add(words[keys[i]]);
            }

            var counter = 0;
            var positionInWord = 0;
            while (counter != text.Length)
            {
                foreach (var word in wordsInGoodOrder)
                {
                    if (positionInWord < word.Length)
                    {
                        decryptedText += word[positionInWord];
                        counter++;
                    }
                }

                positionInWord++;
            }

            DecryptedText.Text = decryptedText;
        }

        private int[] GetKeys(char[] key)
        {
            var newestKey = 0;
            var keys = new int[key.Length];

            for (int i = 0; i < key.Length; i++)
            {
                var min = key.Min();
                if (min == '~')
                    break;

                for (int j = 0; j < key.Length; j++)
                {
                    if (key[j] == min)
                    {
                        keys[j] = newestKey;
                        newestKey++;
                        key[j] = '~';
                    }
                }
            }

            return keys;
        }

        private int GetPosition(int[] weights, int weight)
        {
            for (int i = 0; i < weights.Length; i++)
            {
                if (weights[i] == weight)
                    return i;
            }
            return 0;
        }
    }
}
