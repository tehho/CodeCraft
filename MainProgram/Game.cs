using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace MainProgram
{
    public class Game
    {
        private Player _player;

        private readonly Dictionary<string, Location> _locations;
        private Location _currenLocation;

        public delegate string Enter();

        private bool _running;

        public Game()
        {
            Options.Debugg = false;
            _locations = new Dictionary<string, Location>();
        }

        public void Init()
        {
            _locations.Add("menu",
                new Location("Main Menu", "Welcome to CodeCraft!\nThe main menu of CodeCraft", null));

            var menu = _locations["menu"];

            _locations.Add("newgame", new Location(null, "New Game", "Starts a new game!", menu));
            _locations.Add("loadgame", new Location(null, "Load Game", "Starts a new game!", menu, () =>
            {
                Input.PressEnterToContinue();
                return null;
            }));
            _locations.Add("options", new Location(null, "Options", "Starts a new game!", menu));
            _locations.Add("quit", new Location("Quit", "", menu));

            _currenLocation = _locations["menu"];

            LoadMenu();
            LoadNewGame();
            //LoadLoadGame();
            LoadOptions();
            LoadQuit();
        }

        private void LoadNewGame()
        {
            _locations["newgame"].AddEvent(CreateNewPlayer);
        }

        private Location CreateNewPlayer()
        {
            //_player = Player.CreateNewPlayer();

            CreateTestWorld();

            return _locations["testville"];
        }

        private void LoadQuit()
        {
            _locations["quit"].AddEvent(() =>
            {
                Quit();
                return null;
            });
        }

        public void Run()
        {
            _running = true;

            while (_running)
            {
                try
                {
                    var nextLocation = _currenLocation.Enter();
                    _currenLocation = nextLocation ?? _currenLocation;
                    Input.ClearScreen();
                }
                catch (Exception e)
                {
                    Input.LogError(e);
                    _currenLocation = _locations["menu"];
                }
            }
        }

        public void CreateTestWorldLocations()
        {
            if (!_locations.ContainsKey("testville"))
            {
                _locations.Add("testville", new Location("Testville", "This is the test city {Name}", null));
            }

            if (!_locations.ContainsKey("testton"))
            {
                _locations.Add("testton", new Location("testton", "This is the test city {Name}", null));
            }

            if (!_locations.ContainsKey("testville_tavern"))
            {
                _locations.Add("testville_tavern", new Location("Tavern", "This is the tavern city {Name}",
                    _locations["testville"],
                    () =>
                    {
                        Input.DisplayText("Halloj innefrån tavarnen");
                        Input.PressEnterToContinue();
                        return null;
                    }));
            }
        }

        public void CreateTestWorldRelationships()
        {
            if (_locations["testville"]._locations.Count == 0)
            {
                _locations["testville"].AddLocation(_locations["testville_tavern"], "Bar", "Tavernan");
                _locations["testville"].AddLocation(_locations["testton"], "next");
                _locations["testville"].AddLocation(_locations["menu"], "menu", "main");
                _locations["testville"].AddInput();
            }

            if (_locations["testton"]._locations.Count == 0)
            {
                _locations["testton"].AddLocation(_locations["testville"], "next");
                _locations["testton"].AddInput();
            }
        }

        public void CreateTestWorld()
        {
            CreateTestWorldLocations();

            CreateTestWorldRelationships();
        }

        public void LoadMenu()
        {
            _locations["menu"].AddLocation(_locations["newgame"], "newgame", "new");
            _locations["menu"].AddLocation(_locations["loadgame"], "loadgame", "load");
            _locations["menu"].AddLocation(_locations["options"], "settings");
            _locations["menu"].AddLocation(_locations["quit"]);

            _locations["menu"].AddInput();
        }

        public void LoadOptions()
        {
            var options = _locations["options"];

            _locations.Add("options_show_settings", new Location(null, "Show settings", "Show current settings",
                options, () =>
                {
                    Input.DisplayText(Options.ToString());
                    return null;
                }, () =>
                {
                    Input.PressEnterToContinue();
                    return null;
                }));

            _locations.Add("options_toggle_debugg", new Location(null, "Toggle Debugg", "Toggle debuggmode", options,
                () =>
                {
                    Options.Debugg = !Options.Debugg;
                    return null;
                }));
            _locations.Add("options_storyline", new Location(null, "Storyline", "The Storyline filename", options, () =>
            {
                Options.WorldFile = Input.GetInputWithMessage("Enter a .wld file as storyfile.");
                return null;
            }));

            _locations["options"].AddLocation(_locations["options_show_settings"], "Show", "current");
            _locations["options"].AddLocation(_locations["options_toggle_debugg"], "Debugg");
            _locations["options"].AddLocation(_locations["options_storyline"], "Worldfile", "world", "story");
            _locations["options"].AddLocation(_locations["menu"], "return", "done");

            _locations["options"].AddInput();
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
            return DialogOptions.CreateOptions("Main menu", "New Game", "Load Game", "Options", "Quit");
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