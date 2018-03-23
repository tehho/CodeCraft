using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace MainProgram
{
    public static class Options
    {
        private static string _worldFile;

        public static bool Debugg { get; set; }

        public static string WorldFile
        {
            get => _worldFile;
            set
            {
                if (Path.GetExtension(value) != ".wld")
                {
                    throw new ArgumentException($"Worldfile needs to be .wld not {value}", nameof(WorldFile));
                }

                _worldFile = value;
            }
        }

        public static void Initialize()
        {
            Debugg = true;
            WorldFile = "test_world.wld";
        }
        public static void Initialize(string file)
        {
            if (!File.Exists(file))
                throw new ArgumentException($"Options file {file} does not exist", nameof(file));

            var list = File.ReadAllLines(file);

            foreach (var command in list)
            {
                var commandos = command.Split(':');
                if (commandos.Length > 1)
                    SetVarBasedOnCommando(commandos[0], commandos[1]);
            }

        }

        public new static string ToString()
        {
            return $"Debugg: {Debugg}\nStoryline: {WorldFile}\n";
        }

        private static void SetVarBasedOnCommando(string commando, string value)
        {
            switch (commando)
            {
                case "WorldFile":
                    WorldFile = value;
                    break;
                case "debugg":
                    try
                    {
                        Debugg = bool.Parse(value);
                    }
                    catch (FormatException fe)
                    {
                        throw new FormatException("Value for debugg not parsable", fe);
                    }
                    catch (ArgumentException ae)
                    {
                        throw new ArgumentException("Value for debugg not parsable", nameof(Debugg), ae);
                    }
                    break;
            }
        }

        public static DialogOptions GetDialogOptions()
        {
            return DialogOptions.CreateOptions("Options", "Set Debugg,debugg", "Set Worldfile,Worldfile,StoryFile");
        }
    }
}