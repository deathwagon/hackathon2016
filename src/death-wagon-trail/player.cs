namespace death_wagon_trail 
{    
    public class Player
    {
        public string Name { get; set; }
        public int Condition { get; set; }
        public int Health { get; set; }
        public int GameAction { get; set; }
        public int DaysAlive { get; set; }
        
        public Player(string name, int condition, int health, int action=0) 
        {
            Name = name;
            Condition = condition;
            Health = health;
            GameAction = action;
            DaysAlive = 1;
        }
    }
}