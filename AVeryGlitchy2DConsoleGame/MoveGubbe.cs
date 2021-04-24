using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AVeryGlitchy2DConsoleGame
{
    class MoveGubbe
    {
        List<int> moves = new List<int>();
        List<int> jumps = new List<int>();
        int move = 0;
        int jump = 31;

        private void Display(int move, int jump)
        {

            List<string> gubbe = new List<string>();
            gubbe.Add("(*_*)");
            gubbe.Add("  |  ");
            gubbe.Add("--|--");
            gubbe.Add(@" / \  ");

            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < gubbe.Count; i++)
            {
                Console.SetCursorPosition(move, i + jump);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(gubbe[i]);
            }

            moves.Add(move);
            jumps.Add(jump);

            if (jump < jumps[jumps.Count - 2])
            {
                Console.SetCursorPosition(move, jumps[jumps.Count - 2] + 3);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("     ");
            }

            if (jump > jumps[jumps.Count - 2])
            {
                Console.SetCursorPosition(move, jumps[jumps.Count - 2]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("     ");
            }

            if (move > moves[moves.Count - 2])
            {
                for (int i = 0; i < gubbe.Count; i++)
                {
                    Console.SetCursorPosition(move - 1, i + jumps[jumps.Count - 2]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
            }
            if (move < moves[moves.Count - 2])
            {
                for (int i = 0; i < gubbe.Count; i++)
                {
                    Console.SetCursorPosition(move + 5, i + jumps[jumps.Count - 2]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
            }
        }

        public void Run()
        {
            moves.Add(0);
            jumps.Add(31);
            ConsoleKey keyPressed;



            NewEnemy();

            do
            {
                Display(move, jump);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.RightArrow)
                {
                    move++;
                    if (move > Console.BufferWidth - 5)
                    {
                        move = Console.BufferWidth - 5;
                    }
                }

                if (keyPressed == ConsoleKey.LeftArrow)
                {
                    move--;
                    if (move < 0)
                    {
                        move = 0;
                    }
                }

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    jump--;

                    if (jump < 30)
                    {
                        jump = 30;
                    }
                    if (jump < 0)
                    {
                        jump = 0;
                    }

                    if (jump < jumps[jumps.Count - 2])
                    {
                        Display(move, jump);
                        JumpDelay();
                    }
                }

                if (keyPressed == ConsoleKey.DownArrow)
                {
                    jump++;
                    if (jump > 31)
                    {
                        jump = 31;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);
        }

        public async Task JumpDelay()
        {
            await Task.Delay(600);
            jump = 31;
            Display(move, jump);
        }

        public async Task Enemy()
        {
            int score = 0;

            for (int i = 100; i > 0; i--)
            {
                Console.SetCursorPosition(i, 34);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" ");

                if (i == move & jump == 31)
                {

                    Console.SetCursorPosition(20, 20);
                    Console.WriteLine("Träffad");
                    GameOver g = new GameOver();
                    g.Print();

                    Console.ReadLine();
                }
                if (i < move)
                {
                    score++;
                    Console.SetCursorPosition(0, 0);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine("Poäng: " + score);
                }

                await Task.Delay(20);

                Console.SetCursorPosition(i, 34);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public async Task NewEnemy()
        {
            while (true)
            {
                await Task.Delay(7000);
                Enemy();
            }
        }
    }
}
