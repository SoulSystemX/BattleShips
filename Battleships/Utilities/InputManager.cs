namespace BattleShips
{
    public class InputManager
    {
        public bool InputValidator(string command)
        {
            command = command.ToUpper();

            if(command.Length < 3 && command.Length > 1)
            {
                char x = command[0];
                char y = command[1];
                int indexX = char.ToUpper(x) - 64;
                int indexY = y - '0';

                if (indexX > 10 || indexX < 0)
                    return false;
                if (indexY > 10 || indexY < 0)
                    return false;
                
                return true;
            }

            return false;
        }

        public Coordinate InputConvertor(string command)
        {
            char x = command[0];
            char y = command[1];
            int indexX = (char.ToUpper(x) - 64) - 1;
            int indexY = y - '0';

            return new Coordinate(indexX, indexY);
        }
    }
}
