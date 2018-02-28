using System;

namespace BattleShips
{
    internal class Destroyer : Ship
    {
        public Destroyer()
        {
            Size = 4;
            Orientation = (Orientation)new Random().Next(0, ShipHelper.GetEnumLength());
            Health = Size;
        }

        
    }
}