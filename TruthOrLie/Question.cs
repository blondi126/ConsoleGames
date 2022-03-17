using System;
using System.Collections.Generic;
using System.Text;


namespace TruthOrLie
{
    internal class Question
    {
        public string Name { get; set; }
        public string Answer { get; }
        public string Note { get; }

        public Question(string info)
        {
            var details = info.Split(';');
            Name = details[0].Trim('"', '?');
            Answer = details[1].Trim('"');
            Note = details[2].Trim('"');

        }
    }
}
