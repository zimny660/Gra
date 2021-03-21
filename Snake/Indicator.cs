using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Indicator : Block
    {
        public Indicator(Coordinate position, char symbol) : base(position, symbol) { }
        public void Move(Coordinate offset)
        {
            base.Erase();
            base.Position += offset;
            base.Paint();
            Console.Beep(1000, 20);
        }


    }
}
