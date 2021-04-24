using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVeryGlitchy2DConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(180, 50);

            Console.SetBufferSize(180, 50);

            for (int j = 35; j < Console.BufferHeight; j++)
            {
                for (int i = 0; i < Console.BufferWidth - 1; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.BackgroundColor = ConsoleColor.Green;
                    if (j > 35)
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.Write(" ");
                }
            }
            Console.ResetColor();


            MoveGubbe gm = new MoveGubbe();
            gm.Run();


            Console.ReadLine();
        }

    }
}
