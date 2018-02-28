using System;

namespace BattleShips
{
    public class Cell
    {
        public char? Symbol { set; get; }

        public void Draw()
        {
            if(Symbol != null)
                Console.Write(Symbol);
            else
                Console.Write('+');
        }

    }
}
