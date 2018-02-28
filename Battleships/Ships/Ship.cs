namespace BattleShips
{
    internal class Ship : IShip
    {
        public Orientation Orientation { get; set; }
        public int Size { get; set; }
        public char Symbol { get; set; }
        public int Health { get; set; }

        public virtual void ReceiveDamage()
        {
            Health--;
        }
    }
}
