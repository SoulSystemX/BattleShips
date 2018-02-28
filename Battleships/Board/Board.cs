using System;

namespace BattleShips
{
    internal class Board
    {
        public Cell[,] cells;
        private int sizeX;
        private int sizeY;
        public int WinAmount { get; private set; }

        public Board(int sizeX, int sizeY, int battleships, int destroyers)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            cells = new Cell[sizeX, sizeY];

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    cells[x, y] = new Cell();
                }
            }
            PlaceShip(battleships, Ships.Battleship);
            PlaceShip(destroyers, Ships.Destroyer);
        }

        private void PlaceShip(int numOfShips, Ships shipType)
        {
            for (int i = 0; i < numOfShips; i++)
            {
                IShip ship = null;

                switch (shipType)
                {
                    case Ships.Battleship:
                        ship = new Battleship();
                        break;

                    case Ships.Destroyer:
                        ship = new Destroyer();
                        break;

                    default:
                        break;
                }

                while (true)
                {
                    if (ship != null)
                        if (PlaceShipOnBoard(ship))
                        {
                            WinAmount += ship.Health;
                            break;
                        }
                }
            }
        }

        private bool PlaceShipOnBoard(IShip ship)
        {
            int x = 0;
            int y = 0;
            bool success = true;

            if (ship.Orientation == Orientation.Horizontal)
                CheckHorizontalOrientation(ship, ref x, ref y, ref success);
            else if (ship.Orientation == Orientation.Vertical)
                CheckVerticalOrientation(ship, ref x, ref y, ref success);
            
            if (!success)
                return false;
            else
                return true;
        }

        private void CheckVerticalOrientation(IShip ship, ref int x, ref int y, ref bool success)
        {
            y = GenerateCoordinate(ship.Size);
            x = GenerateCoordinate();

            for (int i = 0; i < ship.Size; i++)
            {
                if (cells[x, y + i].Symbol != null)
                {
                    success = false;
                    break;
                }
            }

            if (success)
            {
                for (int i = 0; i < ship.Size; i++)
                {
                    cells[x, y + i].Symbol = '+';
                }
            }

        }

        private void CheckHorizontalOrientation(IShip ship, ref int x, ref int y, ref bool success)
        {
                x = GenerateCoordinate(ship.Size);
                y = GenerateCoordinate();

                for (int i = 0; i < ship.Size; i++)
                {
                    if (cells[x + i, y].Symbol != null)
                    {
                        success = false;
                        break;
                    }
                }

                if (success)
                {
                    for (int i = 0; i < ship.Size; i++)
                    {
                        cells[x + i, y].Symbol = '+';
                    }
                }
        }

        private int GenerateCoordinate(int size)
        {
            Random rand = new Random();
            return rand.Next(0, 10 - size);
        }

        private int GenerateCoordinate()
        {
            Random rand = new Random();
            return rand.Next(0, 10);
        }

        public void DrawBoard()
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    if (x == 0)
                    {
                        Console.Write((y));
                    }

                    Console.Write(' ');
                    cells[x, y].Draw();
                }

                Console.WriteLine();
            }

            char letters = 'A';

            Console.Write("  ");
            for (int y = 0; y < sizeY; y++)
            {
                Console.Write(letters++);
                Console.Write(' ');
            }

            Console.WriteLine();
        }

        public void FireAtCell(Coordinate coordinate)
        {
            if (cells[coordinate.X, coordinate.Y].Symbol != null)
            {
                cells[coordinate.X, coordinate.Y].Symbol = 'X';
                WinAmount--;
            }
            else
                cells[coordinate.X, coordinate.Y].Symbol = 'O';
            
        }
    }
}