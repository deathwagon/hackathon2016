using System.Collections.Generic;
using System;

namespace death_wagon_trail 
{
    public class Game
    {
        public enum Condition
        {
            None,
            Hungry,
            Thirsty,
            Poisoned,
            Typhoid,
            Cholera,
            Dysentery,
            Diphtheria,
            Measles,
            Zika,
            Bird_Flu,
            Nile_Virus
        };

        public enum Action
        {
            None,
            Hunt,
            Fish,
            Farm,
            Purify,
            Heal,
            Rest,
            Sleep
        };

        public enum Health
        {
            Good,
            Deteriorating,
            Poor,
            Bad,
            Threatening,
            Dead
        };

        private int Days { get; set; }
        private int FoodSupply { get; set; }
        private int MedicalSupply { get; set; }
        private int WaterSupply { get; set; }
        private int CurrentDay { get; set; }
        private int DayLength { get; set; }

        private Dictionary<string, Player> players;

        public Game(int days, int dayLength) 
        {
            Days = days;
            DayLength = dayLength;
            CurrentDay = 1;
            FoodSupply = 5;
            WaterSupply = 5;
            MedicalSupply = 3;

            players = new Dictionary<string, Player>();
        }

        public void UseWaterSupply()
        {

        }

        public void UseFoodSupply()
        {

        }

        public void UseMedicalSupply() 
        {

        }

        public void GetAllPlayers() 
        {

        }

        public Player RandomPlayer() 
        {
            Random r = new Random();
            var rt = r.Next(0,99);

            var index = (int)(((double)rt / 99) * (double)players.Count);

            var current_index = 0;
            string found = string.Empty;

            foreach( string playerName in players.Keys)
            {
                if (current_index == index) 
                {
                    found = playerName;
                    break;
                }

                current_index++;
            }

            return players[found];
        }

        public int RandomCondition()
        {
            Random r = new Random();
            return r.Next(0,12);
        }

        public int RandomAction() 
        {
            Random r = new Random();
            return r.Next(0, 7);
        }

        public void AddPlayer(string name)
        {
            players.Add(name, new Player(name, (int)Condition.None, (int)Health.Good));
        }

        public void Start() 
        {
            System.Console.WriteLine("You and your family members: {0} are about to embark on a journey across the death wagon trail.", 
             String.Join(",", players.Keys));
        }

        public void LiveADay() 
        {
            System.Console.WriteLine("Day: {0}", CurrentDay);

            Player player = RandomPlayer();
            
            var action = RandomAction();
            var condition = RandomCondition();

            System.Console.WriteLine("Player: {0}, Condition: {1}, Health: {2}", player.Name, (Condition)player.Condition, (Health)player.Health);

            CurrentDay += 1;
        }

        public bool CheckLiveAnotherDay() 
        {
            bool liveAnotherDay = false;

            foreach(Player p in players.Values)
            {
                if (p.Health != (int)Health.Dead)
                {
                    liveAnotherDay = true;
                    break;
                }
            }

            if (CurrentDay == Days)
                liveAnotherDay = false;

            return liveAnotherDay;
        }

        public void WaitUntilMorning()
        {
            System.Console.WriteLine("You and your family hold off until morning.");
            System.Threading.Thread.Sleep(DayLength);
        }
    }
}