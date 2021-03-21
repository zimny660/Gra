using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Slot
    {
        public Slot(string text, Coordinate position, string opensMenu)
        {
            Text = text;
            Position = position;
            OpensMenu = opensMenu;
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(Text);
        }
        public string Text { get; set; }
        public Coordinate Position;
        public string OpensMenu { get; set; }
    }
}
