using System;

namespace BattleShips
{
    internal class ShipHelper
    {
        public static int GetEnumLength()
        {
            return Enum.GetNames(typeof(Orientation)).Length;
        }
    }
}
