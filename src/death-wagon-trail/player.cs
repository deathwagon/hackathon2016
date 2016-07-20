namespace death_wagon_trail 
{
    public class Player
    {
        public string Name { get; set; }
        public int Condition { get; set; }
        public int Health { get; set; }
        
        public Player(string name, int condition, int health) 
        {
            Name = name;
            Condition = condition;
            Health = health;
        }
    }
}