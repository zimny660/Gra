using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class LimitBorder : Rectangle
    {
        public LimitBorder(Coordinate leftUpCorner, Coordinate rightDownCorner, char symbol) : base(leftUpCorner, rightDownCorner, symbol)
        {
            CreateEveryElementList();
        }

        public static List<Coordinate> EveryElementOfBorder = new List<Coordinate>();

        public void CreateEveryElementList()
        {
            int numberOfWalls = 4;
            for (int i = 0; i < numberOfWalls; i++)
            {
                for (int j = 0; j < Walls[i].ElementsWall.Count - 1; j++)
                {
                    EveryElementOfBorder.Add(Walls[i].ElementsWall[j].Position);
                }
            }
        }
    }
}
