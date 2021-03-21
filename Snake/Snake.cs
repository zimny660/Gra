using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake : ISnake
    {
        public Snake()
        {
            HeadCoordinate = new Coordinate();
        }
        public Snake(int startX, int startY)
        {
            HeadCoordinate = new Coordinate(startX, startY);
        }
        public Snake(int startX, int startY, int typesOfSteering) : this(startX, startY)
        {
            this.typesOfSteering = (TypesOfSteering)typesOfSteering;
        }
        public int Lenght { get; set; } = 20;
        public Direction CurrDirection { get; set; } = Direction.Right;
        public Coordinate HeadCoordinate { get; set; }
        public List<Coordinate> Tail { get; set; } = new List<Coordinate>();
        private bool outOfRange = false;
        private TypesOfSteering typesOfSteering = TypesOfSteering.arrows;
        public bool GameOver
        {
            get { return Tail.Where(c => c.X == HeadCoordinate.X && c.Y == HeadCoordinate.Y).ToList().Count > 1 || outOfRange || this.HitWall(); }
        }
        public void EatSnack()
        {
            Lenght++;
            Task task = new Task(BeepAfterEat);
            task.Start();
        }

        public void Move()
        {
            switch (CurrDirection)
            {
                case Direction.Left:
                    HeadCoordinate.X--;
                    break;
                case Direction.Right:
                    HeadCoordinate.X++;
                    break;
                case Direction.Up:
                    HeadCoordinate.Y--;
                    break;
                case Direction.Down:
                    HeadCoordinate.Y++;
                    break;
            }
            try
            {
                Console.SetCursorPosition(HeadCoordinate.X, HeadCoordinate.Y);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("O");
                Tail.Add(new Coordinate(HeadCoordinate.X, HeadCoordinate.Y));
                if (Tail.Count > this.Lenght)
                {
                    var endTail = Tail.First();
                    Console.SetCursorPosition(endTail.X, endTail.Y);
                    Console.Write(" ");
                    Tail.Remove(endTail);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                outOfRange = true;
            }
        }
        private void BeepAfterEat()
        {
            Console.Beep();
        }

        public bool HitWall()
        {
            if (this.Tail.Any(x => LimitBorder.EveryElementOfBorder.Contains(x)))
                return true;
            return false;
        }

        public void ChangeDirection()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (typesOfSteering == TypesOfSteering.arrows)
                {
                    switch (input.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (this.CurrDirection != Direction.Right)
                                this.CurrDirection = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            if (this.CurrDirection != Direction.Left)
                                this.CurrDirection = Direction.Right;
                            break;
                        case ConsoleKey.UpArrow:
                            if (this.CurrDirection != Direction.Down)
                                this.CurrDirection = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            if (this.CurrDirection != Direction.Up)
                                this.CurrDirection = Direction.Down;
                            break;
                    }
                }
                if (typesOfSteering == TypesOfSteering.wsad)
                {
                    switch (input.Key)
                    {
                        case ConsoleKey.A:
                            if (this.CurrDirection != Direction.Right)
                                this.CurrDirection = Direction.Left;
                            break;
                        case ConsoleKey.D:
                            if (this.CurrDirection != Direction.Left)
                                this.CurrDirection = Direction.Right;
                            break;
                        case ConsoleKey.W:
                            if (this.CurrDirection != Direction.Down)
                                this.CurrDirection = Direction.Up;
                            break;
                        case ConsoleKey.S:
                            if (this.CurrDirection != Direction.Up)
                                this.CurrDirection = Direction.Down;
                            break;
                    }
                }
            }
        }

    }
    public enum Direction { Left, Right, Up, Down }
    public enum TypesOfSteering { arrows, wsad };

}