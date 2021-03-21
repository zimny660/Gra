using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class TheGame
    {
        public TheGame(int numberOfPlayers, int numberOfSnacks)
        {
            NumberOfPlayers = numberOfPlayers;
            for (int i = 0; i < numberOfPlayers; i++)
            {
                Snakes.Add(new Snake(40, 20, i));
            }
            for (int i = 0; i < numberOfSnacks; i++)
            {
                Snacks.Add(new Snack());
            }
        }
        public List<Snake> Snakes { get; set; } = new List<Snake>();
        public List<Snack> Snacks { get; set; } = new List<Snack>();
        public int NumberOfPlayers { get; set; }

        public bool Exit = false;

        public void EndGameCheck()
        {
            if (Snakes.Where(x => x.GameOver == true).ToList().Count > 0)
            {
                this.Exit = true;
            }
        }
        public void ChangeSnakesDirections()
        {
            foreach (Snake snake in Snakes)
            {
                snake.ChangeDirection();
            }
        }
        public void MoveSnakes()
        {
            foreach (Snake snake in Snakes)
            {
                snake.Move();
            }
        }
        public void CheckIfSnakesAteSnack()
        {
            foreach (Snake snake in Snakes)
            {
                for (int i = 0; i < Snacks.Count; i++)
                {
                    if (snake.HeadCoordinate.Equals(Snacks[i].CurrentTarget))
                    {
                        snake.EatSnack();
                        Snacks[i] = new Snack();
                        while (Snacks[i].IsInSnake(snake))
                        {
                            Snacks[i].Erase();
                            Snacks[i] = new Snack();
                        }
                    }
                }

            }
        }
        public void Play()
        {

            MoveSnakes();
            CheckIfSnakesAteSnack();
            EndGameCheck();
        }
    }
}
