using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace MainProgram
{
    public class Game
    {
        private Player _player;

        private readonly Dictionary<string, Location> _locations;
        private Location _currenLocation;
        
        private bool _running;

        public Game()
        {
            _locations = new Dictionary<string, Location>();
        }

        public void Init()
        {
            _locations.Add("newgame", new OneWayLocation(null, "New Game", "Creates a new game", CreateTestWorld));
            _locations.Add("loadgame", new MultiWayLocation(null, "Load Game", "Load Game", "What do you want to do?", "Continue last save,Continue", "Load from save,save,load"));


            LoadOptions();
            
            _locations.Add("quit", new OneWayLocation(null, "Quit", "Quiting the game", Quit));
            
            LoadMenu();

            _currenLocation = _locations["menu"];

        }

        public void Run()
        {
            _running = true;

            Input.DisplayText("Welcome to CodeCraft!");

            while (_running)
            {
                try
                {
                    _currenLocation = _currenLocation.Enter();
                    
                    Input.ClearScreen();
                }
                catch (Exception e)
                {
                    Input.LogError(e);
                    _currenLocation = _locations["menu"];
                }
            }
        }

        public void CreateTestWorld()
        {
            var list = new Dictionary<string, Location>();

            list.Add("testville",
                new MultiWayLocation(null, "Testville", "This is the test city {Name}", "Where do you want to go?"));
            list.Add("testton",
                new MultiWayLocation(null, "Testton", "This is the test city {Name}", "Where do you want to go?"));
            list.Add("testville_tavern",
                new OneWayLocation(list["testville"], "Tavern", "This is the tavern city {Name}",
                    () => Input.DisplayText("Halloj innefrån tavarnen"), Input.PressEnterToContinue));

            ((MultiWayLocation) list["testville"]).AddLocation(list["testville_tavern"], "Bar");
            ((MultiWayLocation) list["testville"]).AddLocation(list["testton"], "Next");
            ((MultiWayLocation) list["testville"]).AddLocation(_locations["menu"], "menu", "main");

            ((MultiWayLocation) list["testton"]).AddLocation(list["testville"], "Next");

            foreach (var location in list)
            {
                _locations.Add(location.Key, location.Value);
            }

            ((OneWayLocation)_locations["newgame"]).Parent = list["testville"];
            
        }

        public void LoadMenu()
        {
            var list = new List<Location>()
            {
                _locations["newgame"],
                _locations["loadgame"],
                _locations["options"],
                _locations["quit"]                
            };

            _locations.Add("menu", new MultiWayLocation(list, "Menu", "Main Menu", "What do you want to do?", "new,newgame", "load,loadgame,continue"));

            ((MultiWayLocation)_locations["options"]).AddLocation(_locations["menu"],"Return");
            ((OneWayLocation) _locations["quit"]).Parent = _locations["menu"];
        }

        public void LoadOptions()
        {
            var option = new MultiWayLocation(null, "Options", "Options", "What do you want to do?");

            var list = new List<Location>()
            {
                new OneWayLocation(option, "Show settings", "Show current settings", () => Input.DisplayText(Options.ToString()), Input.PressEnterToContinue),
                new OneWayLocation(option, "Toggle Debugg", "Toggle debuggmode", () => Options.Debugg = !Options.Debugg),
                new OneWayLocation(option, "Storyline", "The Storyline filename", () => Options.WorldFile = Input.GetInputWithMessage("Enter a .wld file as storyfile."))
            };

            option.AddLocation(list[0], "Show", "current");
            option.AddLocation(list[1], "Debugg");
            option.AddLocation(list[2], "Worldfile","world","story");

            _locations.Add("options", option);
        }

        private void NewGame()
        {
            _player = Player.CreateNewPlayer();
            Input.DisplayText("NewGame not fully implimented");
            Input.PressEnterToContinue();
        }
        
        private void LoadGame()
        {
            Input.DisplayText("LoadGame not implimented");
            Input.PressEnterToContinue();
        }
        

        void Quit()
        {
            Input.DisplayText("You are about to quit!");
            if (Input.AreYouSure())
            {
                _running = false;
            }
        }

        DialogOptions GetMainMenuOptions()
        {
            return DialogOptions.CreateOptions("Main menu", "New Game","Load Game","Options","Quit");
        }
    }
    public enum GameState
    {
        Running = 0,
        Menu = 1,
        NewGame,
        LoadGame,
        Options,
        Quit
    }
}
