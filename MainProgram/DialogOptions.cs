using System.Collections.Generic;
using System.Linq;
namespace MainProgram
{
    public class DialogOptions
    {
        public string question;
        public List<DialogOption> possibleAnswers;

        public static DialogOptions CreateOptions(string question, string options)
        {
            DialogOptions temp = new DialogOptions
            {
                question = question,
                possibleAnswers = new List<DialogOption>()
            };

            List<string> list = options.Split("\n").ToList();

            foreach (var item in list)
            {
                temp.possibleAnswers.Add(new DialogOption(item));
            }

            return temp;
        }
    }
}
