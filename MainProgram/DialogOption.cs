using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace MainProgram
{

    public class DialogOption
    {
        private readonly List<string> _options;

        public string Answer => _options[0];

        public DialogOption(string option)
        {
            _options = option.Split(",")
                .Select((item) => item.Trim())
                .Where((item) => !string.IsNullOrWhiteSpace(item))
                .ToList();
        }

        public bool Check(string str)
        {
            return _options.Select((option) => option.ToLower())
                           .Contains(str.ToLower());
        }
        public override string ToString()
        {
            return Answer;
        }
    }
}
