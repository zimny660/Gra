using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Snake
{
    static class Core
    {
        static public void Init()
        {
            Console.SetWindowSize(60, 30);
            Console.Clear();
            Console.CursorVisible = false;
            var nextMenu = Menu.ShowInitial();
            OpenMenu(nextMenu);
        }
        static public void OpenMenu(string nextMenu)
        {
            Console.Beep(1000, 20);
            Console.Beep(1200, 20);
            switch (nextMenu)
            {
                case "Start":
                    PlayGame();
                    break;
                case "Wyjśćie":
                    System.Environment.Exit(0);
                    break;
                case "Wynik":
                    throw new NotImplementedException();
                    break;
                case "Menu":
                    var FromInitialNextMenu = Menu.ShowInitial();
                    Core.OpenMenu(FromInitialNextMenu);
                    break;
                case "Nazwa Gracza":
                    var FromPlayerNameTypeNextMenu = Menu.ShowPlayerNameTyper();
                    Core.OpenMenu(FromPlayerNameTypeNextMenu);
                    break;

            }
        }
        static public void PlayGame()
        {
            Console.Clear();
            TheGame theGame = new TheGame(1, 1);
            HUD hud = new HUD(Menu.SelectedName, theGame.Snakes[0].Lenght);
            LimitBorder limitBorder = new LimitBorder(new Coordinate(1, 7), new Coordinate(59, 29), '=');

            double frameRate = 1000 / 15;
            DateTime lastDate = DateTime.Now;

            while (!theGame.Exit)
            {
                theGame.Snakes[0].ChangeDirection();
                if ((DateTime.Now - lastDate).TotalMilliseconds >= frameRate)
                {
                    theGame.Play();
                    hud.ScoreRefresh(theGame.Snakes[0].Lenght);
                    lastDate = DateTime.Now;
                }
            }
            string nextMenu = Menu.ShowAfterDeath();
            Core.OpenMenu(nextMenu);
        }
    }
}