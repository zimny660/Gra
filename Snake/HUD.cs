using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class HUD
    {
        public HUD()
        {
            PlayerNameFrame = new Rectangle(new Coordinate(1, 1), new Coordinate(15, 6), Symbol);
            GameTitleFrame = new Rectangle(new Coordinate(15, 1), new Coordinate(45, 6), Symbol);
            ScoreFrame = new Rectangle(new Coordinate(45, 1), new Coordinate(59, 6), Symbol);
            Init();
        }
        public HUD(string playerName) : this()
        {
            PlayerName = playerName;
            Init();
        }
        public HUD(string playerName, int score) : this(playerName)
        {
            Score = score;
        }

        char Symbol = '=';
        Rectangle PlayerNameFrame;
        Rectangle GameTitleFrame;
        Rectangle ScoreFrame;

        Coordinate PlayerNamePosition = new Coordinate(5, 3);
        Coordinate GameTitlePosition = new Coordinate(22, 3);
        Coordinate ScorePosition = new Coordinate(50, 3);

        string PlayerName;
        const string GameTitle = "SNAKE";
        const string PlayerNameTitle = "Gracz:";
        const string ScoreTitle = "Wynik:";
        int Score;

        public void ScoreRefresh()
        {
            Console.SetCursorPosition(ScorePosition.X, ScorePosition.Y + 1);
            Console.Write(Score);
        }
        public void ScoreRefresh(int score)
        {
            Score = score;
            ScoreRefresh();
        }

        public void Init()
        {
            ScoreRefresh();
            GameTitleDisplay();
            ScoreTitleDisplay();
            PlayerNameDisplay();
        }
        public void PlayerNameDisplay()
        {
            Console.SetCursorPosition(PlayerNamePosition.X, PlayerNamePosition.Y);
            Console.Write(PlayerNameTitle);
            Console.SetCursorPosition(PlayerNamePosition.X, PlayerNamePosition.Y + 1);
            Console.Write(PlayerName);
        }
        public void GameTitleDisplay()
        {
            Console.SetCursorPosition(GameTitlePosition.X, GameTitlePosition.Y);
            Console.Write(GameTitle);
            
        }
        public void ScoreTitleDisplay()
        {
            Console.SetCursorPosition(ScorePosition.X, ScorePosition.Y);
            Console.Write(ScoreTitle);
        }
    }
}
