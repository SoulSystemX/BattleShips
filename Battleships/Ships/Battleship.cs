using System;

namespace BattleShips
{
    internal class Battleship : Ship
    {
        public Battleship()
        {
            Size = 5;
            Orientation = (Orientation)new Random().Next(0, ShipHelper.GetEnumLength());
            Health = Size;
        }

    }
}