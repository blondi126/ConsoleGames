using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gallows
{
    public class Gallows
    {
        private readonly string[] _dictionary = File.ReadAllLines("D:\\Studies\\Course_Udemy_CS\\Gallows\\WordsStockRus.txt");
        public string Word;
        public string GuessedWord { get; set; }
        public int AttemptsCounter = 6;
        public int RightAns = 0;

       public Gallows()
        {
            var randomInt = new Random();
            var num = randomInt.Next(0, _dictionary.Length);
            Word = _dictionary[num];
            var tmp = _dictionary[num];
            var tmp0 = tmp.ToCharArray();
            for (var i = 0; i < Word.Length; i++) tmp0[i] = '-';
            GuessedWord = new string(tmp0);
        }
        public bool FindAndGetLetter(char letter)
        {
            var ret = false;
            for (var i =0; i<Word.Length; i++)
            {
                if (Word[i] != letter) continue;

                var tmp0 = GuessedWord.ToCharArray();
                tmp0[i] = letter;
                GuessedWord = new string(tmp0);
                ret = true;
                RightAns++;
            }
            if(!ret)AttemptsCounter--;
            return ret;
        }
    }
}
