using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace death_wagon_trail
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var gameDays = 5;
            var dayLength = 3000;
            var app = new Game(gameDays, dayLength);

            app.AddPlayer("Mike");
            app.AddPlayer("Tim");
            app.AddPlayer("Stuart");
            app.AddPlayer("Alek");
            app.AddPlayer("Nichole");

            app.Start();

            while(app.CheckLiveAnotherDay())
            {
                app.LiveADay();
                app.WaitUntilMorning();
            }
        }
    }
}
