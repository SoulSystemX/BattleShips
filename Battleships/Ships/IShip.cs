namespace BattleShips
{
    internal interface IShip
    {
        Orientation Orientation { get; }
        int Health { get; set; }
        int Size { get; }

        void ReceiveDamage();
    }
}