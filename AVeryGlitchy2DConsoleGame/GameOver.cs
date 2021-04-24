using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVeryGlitchy2DConsoleGame
{
    class GameOver
    {


        public void Print()
        {

            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            var p = new StringBuilder();
            p.Append("   _________                      ____                 " + "\n");
            p.Append(@"  / ____/   |  ____ ___  ___     / __ \_   _____  _____" + "\n");
            p.Append(@" / / __/ /| | / __ `__ \/ _ \   / / / / | / / _ \/ ___/" + "\n");
            p.Append(@"/ /_/ / ___ |/ / / / / /  __/  / /_/ /| |/ /  __/ /    " + "\n");
            p.Append(@"\____/_/  |_/_/ /_/ /_/\___/   \____/ |___/\___/_/     " + "\n");


            Console.SetCursorPosition(40, 10);

            Console.WriteLine(p);




        }
    }
}
