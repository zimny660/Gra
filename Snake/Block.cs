using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Block
    {
        public Block(int x, int y)
        {
            Position.X = x;
            Position.Y = y;
            Paint();
        }
        public Block(int x, int y, char symbol) : this(x, y)
        {
            BlockSymbol = symbol;
            Paint();
        }
        public Block(Coordinate position, char symbol)
        {
            Position = position;
            BlockSymbol = symbol;
            Paint();
        }
        public Coordinate Position = new Coordinate();
        char BlockSymbol = '|';

        public void Paint()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(BlockSymbol);
        }
        public void Erase()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(" ");
        }
    }
}
