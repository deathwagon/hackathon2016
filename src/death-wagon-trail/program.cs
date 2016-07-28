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
            var gameDays = 30;
            var dayLength = 2000;
            var app = new Game(gameDays, dayLength);

            app.AddPlayer("Micco");
            app.AddPlayer("Tim");
            app.AddPlayer("Stuart");
            app.AddPlayer("Alek");
            app.AddPlayer("Nichole");
            app.AddPlayer("Dan");
            app.AddPlayer("Dom");
            app.AddPlayer("Ryan");
            app.AddPlayer("Shane");
            app.AddPlayer("Raj");

            System.Console.WriteLine(app.Start());

            while(app.CheckLiveAnotherDay() && !app.CheckIsTripComplete())
            {
                System.Console.WriteLine("================================================================================");

                System.Console.WriteLine(app.PaintTheScene());

                System.Console.WriteLine(app.LiveADay());

                System.Console.WriteLine(app.WaitUntilMorning());
                
                System.Console.ForegroundColor = ConsoleColor.Green; 
                System.Console.WriteLine(app.ReportProvisions());
                System.Console.ResetColor();

                System.Console.WriteLine(app.ReportConditions());

                System.Threading.Thread.Sleep(dayLength);
            }
        }
    }
}
