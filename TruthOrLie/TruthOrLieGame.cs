using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TruthOrLie
{
    internal class TruthOrLieGame
    {
        public int CountOfWrong { get; }
        public int CountOfGetQuestions { get; private set; } = 0;
        public int CountOfQuestion { get; }
        public int CountOfWrongAnswers { get; set; } = 0;
        public string PathToFile {get;}
        private readonly List<string> _answers;

        public TruthOrLieGame(string fileName, int countOfTries = 2)
        {
            PathToFile = fileName;
            CountOfWrong = countOfTries;
            _answers = File.ReadAllLines(PathToFile)
                .ToList();
            CountOfQuestion = _answers.Count();
        }

        public Question GetQuestion()
        {
            
            if (CountOfGetQuestions < CountOfQuestion)
            {

                var tmp = new Question(_answers[CountOfGetQuestions]);
                CountOfGetQuestions++;
                return tmp;
            }
            else throw new ArgumentException("Qestion is over");
        }

        public void WrongAnswer()
        {
            CountOfWrongAnswers++;
        }
        
    }
}
