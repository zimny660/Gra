using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Rectangle
    {
        public Rectangle() { }
        public Rectangle(Coordinate leftUpCorner, Coordinate rightDownCorner, char symbol)
        {
            LeftUpCorner = leftUpCorner;
            RightUpCorner = new Coordinate(rightDownCorner.X, leftUpCorner.Y);
            LeftDownCorner = new Coordinate(leftUpCorner.X, rightDownCorner.Y);
            RightDownCorner = rightDownCorner;
            Symbol = symbol;

            Walls[0] = new Wall(LeftUpCorner, RightUpCorner, Symbol);
            Walls[1] = new Wall(LeftUpCorner, LeftDownCorner, Symbol);
            Walls[2] = new Wall(RightUpCorner, RightDownCorner, Symbol);
            Walls[3] = new Wall(LeftDownCorner, RightDownCorner, Symbol);
        }

        protected Wall[] Walls = new Wall[4];
        Coordinate LeftUpCorner;
        Coordinate RightUpCorner;
        Coordinate LeftDownCorner;
        Coordinate RightDownCorner;
        char Symbol;
    }
}
