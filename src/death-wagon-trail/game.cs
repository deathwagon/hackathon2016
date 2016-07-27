using System.Collections.Generic;
using System;
using System.Text;

using death_wagon_trail.EnumsAndConstants;

namespace death_wagon_trail 
{
    public class Game
    {
        private int Days { get; set; }
        private int FoodSupply { get; set; }
        private int MedicalSupply { get; set; }
        private int WaterSupply { get; set; }
        private int CurrentDay { get; set; }
        private int DayLength { get; set; }
        private DateTime CurrentDateTime { get; set; }

        private Dictionary<string, Player> players;

        public Game(int days, int dayLength) 
        {
            Days = days;
            DayLength = dayLength;
            CurrentDateTime = DateTime.Now;
            CurrentDay = 1;
            FoodSupply = 5;
            WaterSupply = 5;
            MedicalSupply = 3;

            players = new Dictionary<string, Player>();
        }

        public void UseWaterSupply(Player p)
        {
            if (WaterSupply > 0) 
            {
                p.Condition = (int)Condition.None;
                WaterSupply--;
            }
        }

        public void UseFoodSupply(Player p)
        {
            if (FoodSupply > 0)
            {
                p.Condition = (int)Condition.None;
                FoodSupply --;
            }
        }

        public void UseMedicalSupply(Player p) 
        {
            if (MedicalSupply > 0) 
            {
                p.Condition = (int)Condition.None;
            
                MedicalSupply--;
            }
        }

        public Dictionary<string, Player> GetAllPlayers() 
        {
            return players;
        }

        public Player RandomPlayer() 
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
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
            Random r = new Random(Guid.NewGuid().GetHashCode());
            return r.Next(0,Enum.GetNames(typeof(Condition)).Length);
        }

        public int RandomGameAction() 
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            return r.Next(0, Enum.GetNames(typeof(GameAction)).Length);
        }

        public int RandomTravel()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            return r.Next(0, Enum.GetNames(typeof(Travel)).Length);
        }

        public int RandomWeather()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            return r.Next(0, Enum.GetNames(typeof(Weather)).Length);
        }

        public int RandomWind()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            return r.Next(0, Enum.GetNames(typeof(Wind)).Length);
        }   

        public int RandomSurrounding()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            return r.Next(0, Enum.GetNames(typeof(Surroundings)).Length);
        }

        public int RandomTemperature()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            return r.Next(0, Enum.GetNames(typeof(Temperature)).Length);
        }

        public int RandomBadThings()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            return r.Next(0, Enum.GetNames(typeof(BadThings)).Length);
        }

        public void AddPlayer(string name)
        {
            players.Add(name, new Player(name, (int)Condition.None, (int)Health.Good));
        }

        public string Start() 
        {
            CurrentDateTime = DateTime.Now;

            return String.Format("You and your family members: {0} are about to embark on a journey across the death wagon trail.", 
             String.Join(", ", players.Keys));
        }

        public float LengthOfTimeInSeconds()
        {
            int secondsInDay = 86400;

            var f = ((DayLength / 1000) / secondsInDay);

            var h = f * 60;

            return h;
        }

        public int GetTotalTraverslIll()
        {
            int counter = 0;
            foreach(Player p in players.Values)
            {
                if ( (Condition)p.Condition != Condition.None )
                counter ++;
            }

            return counter;
        }

        public void ResetPlayerActions()
        {
            foreach(Player p in players.Values)
            {
                p.GameAction = (int)GameAction.None;
            }
        }

        public string LiveADay() 
        {
            ResetPlayerActions();

            var elapsedDateTime = DateTime.Now;
            var elapsedTicks = DateTime.Now.Ticks - CurrentDateTime.Ticks;

            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);

            Player player = RandomPlayer();

            var gameAction = RandomGameAction();
            var condition = RandomCondition();

            CurrentDay += 1;

            Random r = new Random();
            int aday = r.Next(0,100);

            // chance of sickness
            var baseConditionChance = 30;
            var conditionChance = baseConditionChance + (CurrentDay * 2) + (GetTotalTraverslIll() * 3);

            StringBuilder sb = new StringBuilder();

            if (aday >= baseConditionChance) 
            {
                sb.AppendFormat(Constants.GameAction[gameAction], player.Name);
                player.GameAction = (int)gameAction;

                switch((GameAction)player.GameAction)
                {
                    case GameAction.Hunt:
                    case GameAction.Fish:
                    case GameAction.Farm:
                        FoodSupply ++;
                        break;
                    case GameAction.Purify:
                        WaterSupply ++;
                        break;
                    case GameAction.Heal:
                    case GameAction.Rest:
                    case GameAction.Sleep:
                        if (MedicalSupply > 0 ) 
                        {
                            player.Health = (int)Health.Good;
                            player.Condition = (int)Condition.None;

                            MedicalSupply --;
                        }

                        break;
                    case GameAction.Herbs:
                        MedicalSupply ++;
                        break;
                    default:
                        break;                        
                }
            }
            else
            {               
                sb.AppendFormat(Constants.Condition[condition], player.Name);
                if ((Condition)condition != Condition.None) {
                    player.Condition = (int)condition;             
                    player.Health ++;
                }   
            }

            sb.AppendLine();
            return sb.ToString();            
        }

        public string ReportProvisions()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendFormat("Provisions - Food Rations: [{0}], Water: [{1}], Medical Supplies: [{2}]",
                FoodSupply, WaterSupply, MedicalSupply);

            return sb.ToString();
        }

        public string ReportConditions() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();

            foreach(Player p in players.Values)
            {
                sb.Append(ReportCondition(p));
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public string PaintTheScene()
        {
            var travel = RandomTravel();
            var weather = RandomWeather();
            var surrounding = RandomSurrounding();
            var temperature = RandomTemperature();

            StringBuilder sb = new StringBuilder();
            
            sb.AppendFormat("Day: {0}", CurrentDay);
            sb.AppendLine();
            sb.Append(Constants.Travel[travel]);
            sb.AppendLine();
            sb.Append(Constants.Weather[weather]);
            sb.AppendLine();
            sb.Append(Constants.Surroundings[surrounding]);
            sb.AppendLine();
            sb.Append(Constants.Temperature[temperature]);
            sb.AppendLine();

            return sb.ToString();
        }

        public int UpgradePlayerCondition(Player player) 
        {
            return player.Health;
        }

        public int DowngradePlayerCondition(Player player)
        {
            return player.Health;
        }

        public bool IsPlayerDead(Player player)
        {
            if ( (Health)player.Health == Health.Dead )
                return true;

            return false;
        }

        public bool CheckLiveAnotherDay() 
        {
            bool liveAnotherDay = false;

            foreach(Player p in players.Values)
            {
                if (!IsPlayerDead(p))
                {
                    liveAnotherDay = true;
                    break;
                }
            }

            return liveAnotherDay;
        }

        public bool CheckIsTripComplete() 
        {
            if (CurrentDay == Days)
                return true;

            return false;
        }

        public String WaitUntilMorning()
        {
            var badThings = RandomBadThings();
            var sb = new StringBuilder();
            switch((BadThings)badThings)
            {
                case BadThings.Robbed:
                    if (FoodSupply > 0) 
                    {
                        FoodSupply --;
                        sb.Append("Your food supply decreases by 1. ");
                    }
                    break;
                case BadThings.Attacked:
                    if (WaterSupply > 0)
                    {
                        WaterSupply --;
                        sb.Append("Your water supply decreases by 1. ");
                    }
                    break;
                case BadThings.Lost:
                    if (MedicalSupply > 0)
                    {
                        MedicalSupply --;
                        sb.Append("Your medical supplies have been decreased by 1.");
                    }
                    break;                
            }

            return String.Format("{0} {1}",Constants.BadThings[badThings], sb);
        }

        public String ReportCondition(Player player)
        {
            return String.Format("{0,-20} Condition: {1,-15} Health: {2,-15}", player.Name, (Condition)player.Condition, (Health)player.Health);
        }
    }
}