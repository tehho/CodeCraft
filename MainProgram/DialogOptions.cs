using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainProgram
{
    public class DialogOptions
    {
        public string Question;
        public List<DialogOption> PossibleAnswers;

        public DialogOptions()
        {
            Question = "";
            PossibleAnswers = new List<DialogOption>();
        }

        public DialogOptions(string question)
        {
            Question = question;
            PossibleAnswers = new List<DialogOption>();
        }

        public DialogOptions(string question, params string [] list)
        {
            Question = question;
            PossibleAnswers = new List<DialogOption>();

            foreach (var option in list)
            {
                PossibleAnswers.Add(new DialogOption(option));
            }
        }

        public string Check(string str)
        {
            foreach (var possibleAnswer in PossibleAnswers)
            {
                if (possibleAnswer.Check(str))
                {
                    return possibleAnswer.Answer;
                }
            }
            throw new ArgumentOutOfRangeException(nameof(PossibleAnswers), "Option does not exit in possible answers");
        }


        public void AddDialogOption(DialogOption option)
        {
            PossibleAnswers.Add(option);
        }

        public static DialogOptions AreYouSure()
        {
            return CreateOptions("Are you sure?", "Yes", "No");

        }

        public static DialogOptions CreateOptions(string str)
        {
            var pos = str.IndexOf('\n');
            var question = str.Substring(0, pos);
            str = str.Substring(pos + 1);

            return CreateOptions(question, str);
        }
        public static DialogOptions CreateOptions(string question, string options)
        {
            var list = options.Split("\n").ToList();

            return CreateOptions(question, list.ToArray());
        }
        public static DialogOptions CreateOptions(string question, params string[] options)
        {
            if (string.IsNullOrWhiteSpace(question))
            {
                throw new ArgumentException("Question can't be Null or Empty", nameof(question));
            }
            if (options == null)
                throw new NullReferenceException("Options can't be null");

            var temp = new DialogOptions
            {
                Question = question,
                PossibleAnswers = new List<DialogOption>()
            };
            foreach (var item in options)
            {
                temp.PossibleAnswers.Add(new DialogOption(item));
            }

            return temp;
        }

        public static DialogOptions CreateOptions(string question, List<Location> locations, params string[] options)
        {

            var size = locations?.Count ?? options.Length;

            var optionList = new List<string>();

            for (var i = 0; i < size; i++)
            {
                var str = "";
                if (locations != null)
                    str += $"{locations[i].Name}";

                if (i < options.Length)
                    str += $",{options[i]}";

                optionList.Add(str);
            }

            return CreateOptions(question, optionList.ToArray());

        }
    }
}
