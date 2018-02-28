using System;

namespace BattleShips
{
    internal class GameManager
    {
        static void Main(string[] args)
        {
            Board board = new Board(sizeX: 10, sizeY: 10, battleships: 1, destroyers: 2);
            InputManager inputManager = new InputManager();

            while (true)
            {
                Console.Clear();
                board.DrawBoard();

                string input;

                while (true)
                {
                    input = Console.ReadLine();

                    if (inputManager.InputValidator(input))
                    {
                        Coordinate result = inputManager.InputConvertor(input);

                        if (board.cells[result.X, result.Y].Symbol != 'X' && board.cells[result.X, result.Y].Symbol != 'O')
                        {
                            board.FireAtCell(result);
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            board.DrawBoard();
                            Console.WriteLine("Cell already hit, Try another");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        board.DrawBoard();
                        Console.WriteLine("Input Invalid, try again Letter First then Number");
                    }

                }

                if(board.WinAmount == 0)
                {
                    Console.Clear();
                    Console.WriteLine("YOU WIN! Press any key to quit");
                    Console.ReadLine();
                    break;
                }

            }

        }
    }
}