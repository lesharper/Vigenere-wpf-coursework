using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secret
{
    public class VigenerCipher
    {
        const string defaultAlphabet = 
        "ABCDEFGHIJKLMNOPQRSTUVWXYZАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯabcdefghiklmnopqrstuwxyzабвгдеёжзийклмнопрстуфхцшщъыьэюя*.,-_/'|1234567890";
        readonly string letters;

        public VigenerCipher(string alphabet = null)
        {
            letters = string.IsNullOrEmpty(alphabet) ? defaultAlphabet : alphabet;
        }

        //Генерация повторяющегося пароля
        private string GetRepeatKey(string s, int n)
        {
            var p = s;
            while (p.Length < n)
            {
                p += p;
            }
            return p.Substring(0, n);
        }

        private string Vigenere(string text, string password, bool encrypting = true)
        {
            var gamma = GetRepeatKey(password, text.Length);
            var retValue = String.Empty;
            var q = letters.Length;

            for (int i = 0; i < text.Length; i++)
            {
                var letterIndex = letters.IndexOf(text[i]);
                var codeIndex = letters.IndexOf(gamma[i]);
                if (letterIndex < 0)
                {
                    //Если буква не найдена, добавляем её в исходном виде
                    retValue += text[i].ToString();
                }
                else
                {
                    retValue += letters[(q + letterIndex + ((encrypting ? 1 : -1) * codeIndex)) % q].ToString();
                }
            }

            return retValue;
        }

        //Шифрование
        public string Encrypt(string plainMessage, string password)
        => Vigenere(plainMessage, password);

        //Расшифрование
        public string Decrypt(string encryptedMessage, string password)
        => Vigenere(encryptedMessage, password, false);
    }
}
