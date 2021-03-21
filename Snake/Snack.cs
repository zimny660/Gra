using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class Snack
    {
        public Snack()
        {
            Random rand = new Random();
            var x = rand.Next(2, 58);
            var y = rand.Next(8, 28);
            CurrentTarget = new Coordinate(x, y);
            Draw();
        }
        public Snack(int x, int y)
        {
            CurrentTarget = new Coordinate(x, y);
            Draw();
        }
        public Coordinate CurrentTarget { get; set; }

        public void Draw()
        {
            if (!Console.IsOutputRedirected)
            {
                Console.SetCursorPosition(CurrentTarget.X, CurrentTarget.Y);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("O");
            }
        }

        public void Erase()
        {
            if (!Console.IsOutputRedirected)
            {
                Console.SetCursorPosition(CurrentTarget.X, CurrentTarget.Y);
                Console.WriteLine(" ");
            }
        }

        public bool IsInSnake(Snake snake)
        {
            if (snake.Tail.Where(c => c.Equals(this.CurrentTarget)).ToList().Count > 0 || snake.HeadCoordinate.Equals(this.CurrentTarget))
            {
                return true;
            }
            return false;
        }
    }
}
