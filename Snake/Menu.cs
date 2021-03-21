using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    static class Menu
    {
        public static string SelectedName = "";
        public static string ShowInitial()
        {
            bool exitMenu = false;
            Console.Clear();
            Banner banner = new Banner(new Coordinate(9, 5));
            Coordinate SlotsPosition = new Coordinate(25, 13);
            Slot start = new Slot("Start", SlotsPosition, "Nazwa Gracza");
            Slot wynik = new Slot("Wyniki", SlotsPosition + new Coordinate(0, 2), "Otwórz wyniki");
            Slot wyjscie = new Slot("Wyjśćie", SlotsPosition + new Coordinate(0, 4), "Wyjśćie");
            Slot[] slots = { start, wynik, wyjscie };
            Rectangle border = new Rectangle(new Coordinate(1, 1), new Coordinate(59, 29), '=');
            Indicator indicator = new Indicator(SlotsPosition + new Coordinate(-2, 0), '-');

            string output = "";

            while (!exitMenu)
            {
                Coordinate upOffset = new Coordinate(0, 2);
                Coordinate downOffset = new Coordinate(0, -2);
                ConsoleKeyInfo input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (slots.Where(x => x.Position.Y.Equals(indicator.Position.Y - downOffset.Y)).ToList().Count > 0)
                        {
                            indicator.Move(new Coordinate(0, 2));
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (slots.Where(x => x.Position.Y.Equals(indicator.Position.Y + downOffset.Y)).ToList().Count > 0)
                        {
                            indicator.Move(new Coordinate(0, -2));
                        }
                        break;
                    case ConsoleKey.Enter:
                        var selectedMenu = slots.Where(x => x.Position.Y.Equals(indicator.Position.Y)).ToArray();
                        output = selectedMenu[0].OpensMenu;
                        exitMenu = true;
                        break;
                }

            }
            return output;
        }
        public static string ShowAfterDeath()
        {
            bool exitMenu = false;
            Console.Clear();
            //Banner banner = new Banner(new Coordinate(9, 5));
            Coordinate SlotsPosition = new Coordinate(25, 13);
            Slot start = new Slot("Start", SlotsPosition, "Start");
            Slot wynik = new Slot("Menu", SlotsPosition + new Coordinate(0, 2), "Menu");
            Slot wyjscie = new Slot("Wyjśćie", SlotsPosition + new Coordinate(0, 4), "Wyjśćie");
            Slot[] slots = { start, wynik, wyjscie };
            Rectangle border = new Rectangle(new Coordinate(1, 1), new Coordinate(59, 29), '=');
            Indicator indicator = new Indicator(SlotsPosition + new Coordinate(-2, 0), '-');

            string output = "";

            while (!exitMenu)
            {
                Coordinate upOffset = new Coordinate(0, 2);
                Coordinate downOffset = new Coordinate(0, -2);
                ConsoleKeyInfo input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (slots.Where(x => x.Position.Y.Equals(indicator.Position.Y - downOffset.Y)).ToList().Count > 0)
                        {
                            indicator.Move(new Coordinate(0, 2));
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (slots.Where(x => x.Position.Y.Equals(indicator.Position.Y + downOffset.Y)).ToList().Count > 0)
                        {
                            indicator.Move(new Coordinate(0, -2));
                        }
                        break;
                    case ConsoleKey.Enter:
                        var selectedMenu = slots.Where(x => x.Position.Y.Equals(indicator.Position.Y)).ToArray();
                        output = selectedMenu[0].OpensMenu;
                        exitMenu = true;
                        break;
                }
            }
            return output;
        }

        public static string ShowPlayerNameTyper()
        {
            Console.Clear();
            Banner banner = new Banner(new Coordinate(9, 5));
            Rectangle border = new Rectangle(new Coordinate(1, 1), new Coordinate(59, 29), '=');
            Console.SetCursorPosition(20, 13);
            Console.Write("Wpisz nazwe gracza:");
            Console.SetCursorPosition(20, 14);
            do
            {
                Console.SetCursorPosition(20, 14);
                SelectedName = Console.ReadLine();
                if (SelectedName.Length >= 10)
                {
                    Console.SetCursorPosition(20, 13);
                    Console.Write("Nazwa gracza zbyt długa!");
                    Console.SetCursorPosition(20, 14);
                    Console.Write("                                       ");
                }
            } while (SelectedName.Length >= 10);
            string output = "Start";
            return output;
        }
    }
}
