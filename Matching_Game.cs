using System;
using System.Threading;


namespace MatchingGame
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = 1, j = 1, ni, nj, score, isc, jsc;
            int m, n, x = 1;//point generation ,// we use X key on keyboared to leave the game
            bool rec = false;//repeated RND control
            char[] p = new char[30];
            bool rb = false, lb = false;//move R.L border
            int mvlim = 20; //mvlim is a variable showing movement limits
            bool winct = false; //winct is a bool value to check if a user is winner or not
            string[,] g = new string[32, 5];
            int temp, ngc, temps = 0;//ngc: number generation control
            Random generator = new Random();
            
            for (m = 0; m <= 4; m++)
            {

                for (n = 0; n <= 31; n++)
                {
                    if (m != 0 || m != 4)
                    {
                        if (n == 0 || n == 31)
                        {
                            Console.SetCursorPosition(n, m);
                            g[n, m] = "|";
                            Console.Write(g[n, m]);
                        }
                        else
                        {
                            Console.SetCursorPosition(n, m);
                            g[n, m] = " ";
                            Console.Write(g[n, m]);
                        }


                    }
                    if (m == 0)
                    {
                        Console.SetCursorPosition(n, m);
                        g[n, m] = "-";// to print - in the top of the game table
                        Console.Write(g[n, m]);
                    }
                    if (m == 4)
                    {
                        Console.SetCursorPosition(n, m);
                        g[n, m] = "-";// to print - in the bottom of the game table
                        Console.Write(g[n, m]);
                    }
                }

            }
            
            rec = false;// repeated random control
            ngc = 0;
            while (rec == false)
            {
                ni = generator.Next(1, 31);
                nj = generator.Next(1, 4);
                temp = generator.Next(1, 4);
                if (g[ni, nj] == " " && g[ni + 1, nj] != Convert.ToString(temp) && Convert.ToString(temp) != g[ni - 1, nj])
                {
                    g[ni, nj] = Convert.ToString(temp);
                    ngc++;// when a number generate correctly ngc increase by one

                }



                if (ngc == 30)
                    rec = true;
            }
            rec = false;
            Console.Clear();
            for (m = 0; m <= 4; m++)
            {

                for (n = 0; n <= 31; n++)
                {
                    if (m != 0 || m != 4)
                    {
                        if (n == 0 || n == 31)
                        {
                            Console.SetCursorPosition(n, m);
                            g[n, m] = "|";
                            Console.Write(g[n, m]);
                        }
                        else
                        {
                            Console.SetCursorPosition(n, m);
                            Console.Write(g[n, m]);
                        }


                    }
                    if (m == 0)
                    {
                        if (n == 0 || n == 31)
                        {
                            Console.SetCursorPosition(n, m);
                            g[n, m] = "+";
                            Console.Write(g[n, m]);
                        }
                        else
                        {
                            Console.SetCursorPosition(n, m);
                            g[n, m] = "-";
                            Console.Write(g[n, m]);
                        }
                    }
                    if (m == 4)
                    {
                        if (n == 0 || n == 31)
                        {
                            Console.SetCursorPosition(n, m);
                            g[n, m] = "+";
                            Console.Write(g[n, m]);
                        }
                        else
                        {
                            Console.SetCursorPosition(n, m);
                            g[n, m] = "-";
                            Console.Write(g[n, m]);
                        }
                    }
                }

            }



            Console.SetCursorPosition(1, 1);
            score = 0;
            while (x == 1)
            {

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow: j -= 1; break;
                    case ConsoleKey.DownArrow: j += 1; break;
                    case ConsoleKey.LeftArrow: i -= 1; break;
                    case ConsoleKey.RightArrow: i += 1; break;
                    case ConsoleKey.S:

                        if (g[i, j + 1] == " " && (g[i + 1, j] == " "|| g[i + 1, j] == "|") && (g[i - 1, j] == " "|| g[i - 1, j] == "|"))
                        {
                            // to control this condition : the left and right side of the number should be empty
                        
                            g[i, j + 1] = g[i, j];
                            g[i, j] = " ";

                            mvlim--; // movement limit shoud be decreased after any movement
                        }

                        break;
                    case ConsoleKey.D:
                        rb = false;
                        temp = i + 1;
                        if ((g[i + 1, j] == " " && (g[i - 1, j] == " " )|| g[i - 1, j] =="|"))
                        {
                            // to control this condition : the left and right side of the number should be empty
                        
                            while (rb == false)
                            {

                                if (g[temp, j] == " ")
                                {
                                    g[temp, j] = g[temp - 1, j];
                                    g[temp - 1, j] = " ";
                                }
                                else
                                    rb = true;
                                temp++; // doing this while loop till get the right number or boarder and during that temp=temp+1

                            }
                            mvlim--; // movement limit shoud be decreased after any movement
                        }


                        break;
                    case ConsoleKey.A:
                        lb = false;
                        temp = i - 1;
                        if ((g[i + 1, j] == " " || g[i + 1, j] =="|") && (g[i - 1, j] == " "))
                        {
                            // to control this condition : the left and right side of the number should be empty

                            while (lb == false)
                            {

                                if (g[temp, j] == " ")
                                {
                                    g[temp, j] = g[temp + 1, j];
                                    g[temp + 1, j] = " ";
                                }
                                else
                                    lb = true;

                                temp--;// doing this while loop till get the left number or boarder and during that temp=temp-1
                            }
                            mvlim--; // movement limit shoud be decreased after any movement
                        }

                        break;
                    case ConsoleKey.W:
                        if (g[i, j - 1] == " " && (g[i + 1, j] == " " || g[i + 1, j] =="|") && (g[i - 1, j] == " " || g[i - 1, j] =="|" ))
                        {
                            // to control this condition : the left and right side of the number should be empty
                        
                            g[i, j - 1] = g[i, j];
                            g[i, j] = " ";

                            mvlim--;// movement limit shoud be decreased after any movement
                        }

                        break;
                    case ConsoleKey.X: x = 0; break;

                }
                if (i == 31)
                    i = 30;
                if (i == 0)
                    i = 1;
                if (j == 0)
                    j = 1;
                if (j == 4)
                    j = 3;


                for (jsc = 1; jsc <= 3; jsc++)// for loop to check all j and i locations to find same numbers
                {
                    for (isc = 1; isc <= 30; isc++)
                    {
                        if (g[isc, jsc] == g[isc + 1, jsc] && g[isc, jsc] != " ")
                            //if two numbers are same
                        {
                            score = score + 10;//first stage of the game
                            if (score < 110)
                                mvlim = 20;
                            else if (score >= 110 && score < 210)//second stage of the game
                                mvlim = 10;
                            else if (score >= 210 && score < 300)//third stage of the game
                                mvlim = 5;
                            else
                                mvlim = 0;
                            if (score == 300)// at the end of third stage winct will be true
                                winct = true;
                            Console.Beep();
                            g[isc, jsc] = " ";
                            g[isc + 1, jsc] = " ";
                            ngc = 0;
                            rec = false;
                            while (rec == false)
                            {
                                ni = generator.Next(1, 31);
                                nj = generator.Next(1, 4);
                                temp = generator.Next(1, 4);
                                if (g[ni, nj] == " " && ni != isc && nj != jsc && g[ni + 1, nj] != Convert.ToString(temp) && Convert.ToString(temp) != g[ni - 1, nj])
                                {
                                    g[ni, nj] = Convert.ToString(temp);
                                    ngc++;

                                }

                                if (ngc == 2)
                                    rec = true;
                            }


                        }
                    }
                }
                Console.Clear();
                for (m = 0; m <= 4; m++)
                {

                    for (n = 0; n <= 31; n++)
                    {
                        if (m != 0 | m != 4)
                        {
                            if (n == 0 | n == 31)
                            {
                                Console.SetCursorPosition(n, m);
                                g[n, m] = "|";
                                Console.Write(g[n, m]);
                            }
                            else
                            {
                                Console.SetCursorPosition(n, m);
                                Console.Write(g[n, m]);
                            }


                        }
                        if (m == 0)
                        {
                            if (n == 0 | n == 31)
                            {
                                Console.SetCursorPosition(n, m);
                                g[n, m] = "+";
                                Console.Write(g[n, m]);
                            }
                            else
                            {
                                Console.SetCursorPosition(n, m);
                                g[n, m] = "-";
                                Console.Write(g[n, m]);
                            }
                        }
                        if (m == 4)
                        {
                            if (n == 0 | n == 31)
                            {
                                Console.SetCursorPosition(n, m);
                                g[n, m] = "+";
                                Console.Write(g[n, m]);
                            }
                            else
                            {
                                Console.SetCursorPosition(n, m);
                                g[n, m] = "-";
                                Console.Write(g[n, m]);
                            }
                        }
                    }

                }
                Console.SetCursorPosition(12, 6);

                if (score != temps)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                if (score <= 100)// the steps of 3 stages of the game
                    Console.WriteLine("Stage 1");
                else if (score > 100 && score <= 200)
                    Console.WriteLine("Stage 2");
                else if (score > 200 && score <= 300)
                    Console.WriteLine("Stage 3");

                Console.SetCursorPosition(8, 8);
                Console.WriteLine("Your score is:" + score);
                Console.SetCursorPosition(3, 10);
                Console.WriteLine("Press 'x' to exit the game");
                Console.SetCursorPosition(10, 12);
                Console.WriteLine(mvlim + "Move left!");

                Console.SetCursorPosition(i, j);
                temps = score;

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                if (winct == true)
                    x = 0;
                if (mvlim == 0)
                    x = 0;

            }



            if (winct == true)
            {
                Console.Clear();
                Console.Write("ooooo  oooo                         oooo     oooo o88               oo  \n");
                Console.Write("  888  88 ooooooo  oooo  oooo        88   88  88  oooo  oo oooooo  8888 \n");
                Console.Write("    888 888     888 888   888         88 888 88    888   888   888 8888 \n");
                Console.Write("    888 888     888 888   888          888 888     888   888   888  88  \n");
                Console.Write("   o888o  88ooo88    888o88 8o          8   8     o888o o888o o888o oo  \n");
                Console.Beep(659, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(523, 125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(375); Console.Beep(392, 125); Thread.Sleep(375); Console.Beep(523, 125); Thread.Sleep(250); Console.Beep(392, 125); Thread.Sleep(250); Console.Beep(330, 125); Thread.Sleep(250); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(466, 125); Thread.Sleep(42); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(392, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(880, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(587, 125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(523, 125); Thread.Sleep(250); Console.Beep(392, 125); Thread.Sleep(250); Console.Beep(330, 125); Thread.Sleep(250); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(494, 125); Thread.Sleep(125); Console.Beep(466, 125); Thread.Sleep(42); Console.Beep(440, 125); Thread.Sleep(125); Console.Beep(392, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(880, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(784, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(587, 125); Console.Beep(494, 125); Thread.Sleep(375); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(698, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(698, 125); Thread.Sleep(625); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(622, 125); Thread.Sleep(250); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(523, 125); Thread.Sleep(1125); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(698, 125); Thread.Sleep(125); Console.Beep(698, 125); Console.Beep(698, 125); Thread.Sleep(625); Console.Beep(784, 125); Console.Beep(740, 125); Console.Beep(698, 125); Thread.Sleep(42); Console.Beep(622, 125); Thread.Sleep(125); Console.Beep(659, 125); Thread.Sleep(167); Console.Beep(415, 125); Console.Beep(440, 125); Console.Beep(523, 125); Thread.Sleep(125); Console.Beep(440, 125); Console.Beep(523, 125); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(622, 125); Thread.Sleep(250); Console.Beep(587, 125); Thread.Sleep(250); Console.Beep(523, 125);


            }
            if (mvlim == 0 && winct == false)
            {
                Console.Clear();
                Console.Write("ooooo         ooooooo    oooooooo8 ooooooooooo  oo  \n");
                Console.Write(" 888        o888   888o 888        88  888  88 8888 \n");
                Console.Write(" 888        888     888  888oooooo     888     8888 \n");
                Console.Write(" 888      o 888o   o888         888    888      88  \n");
                Console.Write("o888ooooo88   88ooo88   o88oooo888    o888o     oo  \n");

            }
            Console.ReadKey();


        }
    }

}
