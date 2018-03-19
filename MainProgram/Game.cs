using System;
using System.Collections.Generic;

namespace MainProgram
{
    public enum GameState
    {
        Running = 0,
        Menu = 1,
        NewGame,
        LoadGame,
        Options,
        Quit
    }
    public class Game
    {
        GameState gameState;
        Player player;

        readonly Dictionary<string, DialogOptions> menuOptions;


        bool running;

        public Game()
        {
            gameState = GameState.Menu;
            menuOptions = new Dictionary<string, DialogOptions>();
        }

        public void Init()
        {
            LoadMenu();
        }

        public void LoadMenu()
        {
            menuOptions.Add("menu", GetMainMenuOptions());
        }

        public void Run()
        {
            running = true;
            gameState = GameState.Menu;
            Input.DisplayText("Welcome to CodeCraft!");

            while (running)
            {
                switch (gameState)
                {
                    case GameState.Running:
                        Running();
                        break;
                    case GameState.NewGame:
                        NewGame();
                        break;
                    case GameState.LoadGame:
                        LoadGame();
                        break;
                    case GameState.Options:
                        Options();
                        break;
                    case GameState.Menu:
                        Menu();
                        break;
                    case GameState.Quit:
                        Quit();
                        break;
                    default:
                        break;
                }
                Input.ClearScreen();
            }
        }

        private void Options()
        {
            Input.DisplayText("Options not implimented");
            Input.PressEnterToContinue();
            gameState = GameState.Menu;
        }

        private void Running()
        {

            gameState = GameState.Menu;
        }

        private void LoadGame()
        {
            Input.DisplayText("LoadGame not implimented");
            Input.PressEnterToContinue();
            gameState = GameState.Menu;
        }

        private void NewGame()
        {
            player = Player.CreateNewPlayer();
            Input.DisplayText("NewGame not fully implimented");
            Input.PressEnterToContinue();
            gameState = GameState.Running;
        }

        void Menu()
        {
            string message = Input.GetInputFromOptions(menuOptions["menu"]);

            message = message.ToLower();

            switch (message)
            {
                case "quit":
                case "4":
                    gameState = GameState.Quit;
                    break;
                case "1":
                case "newgame":
                    gameState = GameState.NewGame;
                    break;
                case "2":
                case "loadgame":
                    gameState = GameState.LoadGame;
                    break;
                case "3":
                case "options":
                    gameState = GameState.Options;
                    break;

                default:
                    break;

            }
        }

        void Quit()
        {
            Input.DisplayText("You are about to quit!");
            if (Input.AreYouSure())
            {
                running = false;
            }
            else
            {
                gameState = GameState.Menu;
            }
        }

        DialogOptions GetMainMenuOptions()
        {
            return DialogOptions.CreateOptions("Main menu", "New Game,1\nLoad Game,2\nOptions,3\nQuit,4");
        }
    }
}
