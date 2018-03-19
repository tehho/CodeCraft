using System.Collections.Generic;
using System.Linq;
namespace MainProgram
{
    public class DialogOptions
    {
        public string question;
        public List<DialogOption> possibleAnswers;

        public string Check(string str)
        {
            foreach (var list in possibleAnswers)
            {
                if(list.Check(str))
                {
                    return list.Question;
                }
            }

            return "";
        }

        public static DialogOptions CreateOptions(string question, string options)
        {
            string[] list = options.Split("\n");

            return CreateOptions(question, list);
        }
        public static DialogOptions CreateOptions(string question, string[] options)
        {
            DialogOptions temp = new DialogOptions
            {
                question = question,
                possibleAnswers = new List<DialogOption>()
            };

            foreach (var item in options)
            {
                temp.possibleAnswers.Add(new DialogOption(item));
            }

            return temp;
        }
    }
}
