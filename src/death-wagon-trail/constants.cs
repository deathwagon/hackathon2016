using System;

namespace death_wagon_trail.EnumsAndConstants
{
    public enum BadThings
    {
        None,
        Robbed,
        None2,
        Attacked,
        None3,
        Lost,
        None4
    };

    public enum Hunt
    {
        None,
        Bear,
        Deer,
        Rabbit,
        Squirrel
    };

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
        Flu, 
        Virus
    }; 

    public enum GameAction
    {
        None, 
        Hunt, 
        Fish, 
        Farm, 
        Purify, 
        Heal, 
        Rest, 
        Sleep,
        Herbs
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

    public enum Weather
    {
        Sunny,
        Foggy,
        Cloudy,
        Overcast,
        Raining,
        Sunny2,
        Foggy2,
        Cloudy2,
        Overcast2,
        Raining2
    };

    public enum Wind
    {
        None,
        Breezy,
        Low,
        High
    }

    public enum Travel
    {
        Good,
        Blazing,
        Muddy,
        Hazard
    };

    public enum Surroundings
    {
        Plains,
        Mountains,
        Forests,
        Hills
    };

    public enum Temperature
    {
        Cold,
        Mild,
        Hot
    };

    public class Constants
    {
        public static readonly String[] BadThings = {
            "You and your companions hold off until morning.",
            "You have been ROBBED overnight! You lost some of your food rations.",
            "You and your companions make it through the night without a problem.",
            "You have been ATTACKED overnight! Bandits destroy your water supplies.",
            "You and your companions sleep peacefully through the night.",
            "You and your companions left medical supplies back at last camp.",
            "A fire burns all night long warming the tired and cold bones of your party. Everyone rests."
        };

        public static readonly String[] GameAction = {
            "{0} decided to do nothing today. ",
            "{0} is hunting. ",
            "{0} is fishing. ",
            "{0} is out gathering food. ",
            "{0} is boiling water. ",
            "{0} is healing. ",
            "{0} is resting. ",
            "{0} is sleeping. ",
            "{0} is gathering herbs. "    
        };

        public static readonly String[] Condition = {
            "{0} has no issues today.",
            "{0} is thirsty and needs some water.",
            "{0} is hungry and needs some food.",
            "{0} is poisoned.",
            "{0} has typhoid.",
            "{0} has cholera.",
            "{0} has dysentery.",
            "{0} has diphtheria.",
            "{0} has measles.",
            "{0} has the bird flu.",
            "{0} has the nile virus."
        };

        public static readonly String[] Hunt = {
            "{0} was unable to find anything suitable to hunt.",
            "{0} shot down a large black bear using a rifle. Your food rations have increased greatly.",
            "{0} shot down a decent buck. Your food rations have increased.",
            "{0} was able to trap a rabbit. Your food rations have increased a little.",
            "{0} was able to trap a squirrel. Your food rations have increased slightly."
        };

        public static readonly String[] Weather = {
            "It is a bright and beautiful day. The sky is bright blue.",
            "A low hanging fog has settled in over night. Visibility is low and danger is high. You can not travel as far today.",
            "The sky is scattered with big puffy white clouds. The sun is moving in and out of cloud cover today.",
            "Low dark ominous clouds hang over your travels today.",
            "An all day rain has settled in on your travels making your movement slower today.",
            "Not a single cloud in the sky today. The sun shines brightly against the deep blue backdrop. Warm rays shine down on your group making for a much better day.",
            "A thick fog has settled over your travels. Visibility is limited to a few feet.",
            "Large clouds cover most of the sky today. You glimpse brief moments of the sun as it passes through the cloud cover.",
            "Dark clouds loom overhead today. The feeling of dread settles in over your party.",
            "The rain is coming down in sheets and it doesn't appear that its going to let up any time soon."
        };

        public static readonly String[] Wind = {
            "There is no wind today.",
            "A slight breeze blowing in.",
            "Its windy today. You watch as a tumbleweed makes its way across your path.",
            "Strong winds are making travels difficult today. Blowing dusk pelt your face making it difficult to breath."
        };

        public static readonly String[] Travel = {
            "The road ahead is good. It has been well worn and the path is easily followed.",
            "You no longer see a road infront of you. It looks like its time to make your own way.",
            "The road ahead is covered in a thick mud from the recent rains making travel much more difficult.",
            "You are unable to continue on the existing road. Your path ahead is blocked. You must go around and reconnect with the road."
        };

        public static readonly String[] Surroundings = {
            "You and your party are travelling through tall grass. The land is fairly flat. This should make travel conditions fairly straight forward.",
            "Large mountains loom all around you. Your journey is slow as you make your way around boulder after boulder. The region is very mountainous.",
            "Tall pines and trees surround your party on all sides. It is green and lush.",
            "Rolling hills as far as the eye can see."
        };

        public static readonly String[] Temperature = {
            "It is colder than normal today.",
            "The temperature is perfect for travelling.",
            "The heat today is making your journey difficult. Your party uses up more water rations today."
        };
    }
}

