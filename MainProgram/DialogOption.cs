using System;
using System.Collections.Generic;
using System.Linq;

namespace MainProgram
{

    public class DialogOption
    {
        string displayQuestion;
        List<string> options;

        public string Question
        {
            get
            {
                return displayQuestion;
            }
        }

        public DialogOption(string option)
        {
            options = new List<string>(option.Split(","));
            displayQuestion = options[0];
        }

        public bool Check(string str)
        {
            return options.Contains(str);
        }
        public override string ToString()
        {
            return displayQuestion;
        }
    }
}
