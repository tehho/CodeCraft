using System;
using System.Collections.Generic;
using System.Reflection;

namespace MainProgram
{
    public static class Input
    {
        public static void DisplayText(object message)
        {
            Console.WriteLine(message);
        }
        public static void DisplayText(string message)
        {
            Console.WriteLine(message);
        }

        public static void LogError(object obj)
        {
            if (Options.Debugg)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                DisplayText(obj);
                Console.ResetColor();
            }
        }

        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void Seperator()
        {
            DisplayText("----------");
        }

        public static bool AreYouSure()
        {
            var result = 0;
            do
            {
                var message = GetInputFromOptions(DialogOptions.AreYouSure()).ToLower();
                switch(message)
                {
                    case "yes":
                        result = 1;
                        break;
                    case "no":
                        result = 2;
                        break;
                    default:
                        result = 3;
                        break;
                }
                
            }
            while (result != 1 && result != 2);

            return (result == 1);
        }
        
        public static string GetInputFromOptions(DialogOptions options)
        {
            while (true)
            {
                DisplayText(options.Question);

                Seperator();

                List<DialogOption> possibleAnswers = options.PossibleAnswers;

                for (int i = 0; i < possibleAnswers.Count; i++)
                {
                    DisplayText($"{i + 1}. {possibleAnswers[i]}");
                }

                var input = GetInput();

                for (int i = 0; i < possibleAnswers.Count; i++)
                {
                    if (input == (i+1).ToString())
                        return possibleAnswers[i].Answer;

                    if (possibleAnswers[i].Check(input))
                        return possibleAnswers[i].Answer;
                }

                try
                {
                    return options.Check(input);
                }
                catch (ArgumentException ae)
                {
                    DisplayText("That's not a vaild option!");
                    if (Options.Debugg)
                    {
                        LogError(ae);
                    }
                }

                DisplayText("");
            }
        }

        public static string GetInputWithMessage(string message)
        {
            DisplayText(message);

            return GetInput();
        }

        public static string GetInput()
        {
            return Console.ReadLine();
        }
        
        public static void PressEnterToContinue()
        {
            GetInputWithMessage("Press ENTER to continue");
        }
    }
}
