using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Wall
    {
        public Wall(Coordinate startPoint, Coordinate endPoint, char symbol)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            if (startPoint.X == endPoint.X)
            {
                for (int i = startPoint.Y; i <= endPoint.Y; i++)
                {
                    ElementsWall.Add(new Block(startPoint.X, i, symbol));
                }
            }
            else if (startPoint.Y == endPoint.Y)
            {
                for (int i = startPoint.X; i <= endPoint.X; i++)
                {
                    ElementsWall.Add(new Block(i, startPoint.Y, symbol));
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public List<Block> ElementsWall = new List<Block>();
        public Coordinate StartPoint;
        public Coordinate EndPoint;
    }
}
