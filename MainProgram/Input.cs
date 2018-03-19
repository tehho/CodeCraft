using System;

namespace MainProgram
{
    public static class Input
    {
        

        public static void DisplayText(string message)
        {
            Console.WriteLine(message);
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
            int result = 0;
            do
            {
                string message = GetInputFromOptions(Options.CreateOptions("Are you sure?", "Yes\nNo")).ToLower();
                switch(message)
                {
                    case "1":
                    case "yes":
                        result = 1;
                        break;
                    case "2":
                    case "no":
                        result = 2;
                        break;
                    default:
                        break;
                }
            }
            while (result != 1 && result != 2);

            return (result == 1);
        }
        
        public static string GetInputFromOptions(DialogOptions options)
        {
            DisplayText(options.question);

            Seperator();

            for (int i = 0; i < options.possibleAnswers.Count; i++)
            {
                DisplayText($"{i + 1}. {options.possibleAnswers[i]}");
            }

            return GetInput();
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
