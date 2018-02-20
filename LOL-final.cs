using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOL
{
    class Program
    {
        public static class points
        {
            public static int points1;
            public static int points2;
            public static int points3;
            public static int win;
            public static int rounds;
            public static int p1;
            public static int p2;
            public static int p3;
            public static int ip;
        }
        static void art()
        {
            for (int i = 0; i < points.ip; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write( "0");
            }
            Console.Write("\n");
            for (int j = 0; j < points.ip; j++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("|");
            }
            Console.Write("\n");
            for (int k = 0; k < points.ip; k++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("|");
            }
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------MENU---------------------");
            Console.WriteLine("Type Rules if you want to see how to play! Type Play to jump in the game!");
            string rules = Console.ReadLine();
            if (rules == "Rules")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(("-------------------Rules-------------------"));
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("There are 12 matches");
                Console.WriteLine("Each player can remove 3 matches at once");
                Console.WriteLine("The player to remove the last match loses!");
            }
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Single player mode or Multiplayer?");
            string players;
            string mode = Console.ReadLine();
            if (mode == "Multiplayer")
            {
                Console.WriteLine("How many players? 2-3");
                players = Console.ReadLine();
                Console.WriteLine("How many rounds?");
                points.rounds = Convert.ToInt32(Console.ReadLine());
                points.win = points.rounds;
                while (points.rounds > 0)
                {
                    if (players == "2")
                    {
                        twoplayermode();
                        scoresystem();
                        points.rounds--;


                    }
                    else if (players == "3")
                    {
                        threeplayermode();
                        points.rounds--;
                        threeplayermodescore();

                    }
                }
            }
            else if (mode == "Single player")
            {
                Console.WriteLine("How many rounds?");
                points.rounds = Convert.ToInt32(Console.ReadLine());
                points.win = points.rounds;
                while (points.rounds > 0)
                {
                    Random r = new Random();
                    int rng = r.Next(1, 2);
                    if (rng == 1)
                    {
                        oneplayermodehard();
                        scoresystem();
                        points.rounds--;
                    }
                    else if (rng == 2)
                    {

                        oneplayermodehard();
                        scoresystem();
                        points.rounds--;
                    }
                }
            }
            Console.ReadKey();
        }
        static string Turns()
        {
            Random r = new Random();
            int flip = r.Next(0, 2);
            string turn = "a";

            Console.WriteLine("Please select heads (1) or tails (2)");
            int userc = Convert.ToInt32(Console.ReadLine());
            if (flip == userc)
            {
                turn = "Player 1";
            }
            else if (flip != userc)
            {
                turn = "Player 2";
            }
            return turn;
        }
        static void scoresystem()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Player 1: " + points.points1 + " Player 2: " + points.points2);
            Console.WriteLine("-------------------------------------------------");
            if (points.points1 > points.points2)
            {
                Console.WriteLine("Player 1 wins the game");
            }
            if (points.points2 > points.points1)
            {
                Console.WriteLine("Player 2 wins the game ");
            }
            if (points.points1 == points.points2)
            {
                Console.WriteLine("Draw!");
            }
        }
        static void toomanymatches()
        {
            while (points.p1 > 3 || points.p2 > 3 || points.p3 > 3)
            {
                if (points.p1 > 3)
                {
                    Console.WriteLine("Please try again. (You can't remove more than 3 matches at once)");
                    points.p1 = Convert.ToInt32(Console.ReadLine());
                }
                if (points.p2 > 3)
                {
                    Console.WriteLine("Please try again. (You can't remove more than 3 matches at once)");
                    points.p2 = Convert.ToInt32(Console.ReadLine());
                }
                if (points.p3 > 3)
                {
                    Console.WriteLine("Please try again. (You can't remove more than 3 matches at once)");
                    points.p3 = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        static void twoplayermode()
        {
            bool lost = true;
            bool first = false;
            points.ip = 12;
            string turn = Turns();
            Console.WriteLine(turn + " goes first.");
            if (turn == "Player 1")
            {
                first = false;
            }
            else if (turn == "Player 2")
            {
                first = true;
            }

            while (points.ip >= 0)
            {
                if (points.ip == 0)
                {
                    break;
                }
                art();
                if (first == false)
                {
                    Console.WriteLine("How many matches would you like to remove player 1?");
                    points.p1 = Convert.ToInt32(Console.ReadLine());
                    toomanymatches();
                    points.ip = points.ip - points.p1;
                    Console.WriteLine(points.ip + " matches are remaining");
                    lost = true;

                    if (points.ip == 0)
                    {
                        break;
                    }
                    art();
                    Console.WriteLine("How many matches would you like to remove player 2?");
                    points.p2 = Convert.ToInt32(Console.ReadLine());
                    toomanymatches();
                    points.ip = points.ip - points.p2;
                    Console.WriteLine(points.ip + " matches are remaining");
                    lost = false;
                }
                else if (first == true)
                {
                    Console.WriteLine("How many matches would you like to remove player 2?");
                    points.p2 = Convert.ToInt32(Console.ReadLine());
                    toomanymatches();
                    points.ip = points.ip - points.p2;
                    Console.WriteLine(points.ip + " matches are remaining");
                    lost = false;

                    if (points.ip == 0)
                    {
                        break;
                    }
                    art();
                    Console.WriteLine("How many matches would you like to remove player 1?");
                    points.p1 = Convert.ToInt32(Console.ReadLine());
                    toomanymatches();
                    points.ip = points.ip - points.p1;
                    Console.WriteLine(points.ip + " matches are remaining");
                    lost = true;
                }


            }
            if (lost == false)
            {
                Console.WriteLine("Player 1 Wins!");
                points.points1 = points.points1 + 1;
            }
            else if (lost == true)
            {
                Console.WriteLine("Player 2 Wins!");
                points.points2 = points.points2 + 1;
            }

        }
        static void threeplayermode()
        {
            bool lost = true;
            bool third = false;
            bool second = false;
            points.ip = 12;
            Console.WriteLine("Player 1 goes first, Player 2 second, Player 3 third.");

            while (points.ip >= 0)
            {
                if (points.ip == 0)
                {
                    break;
                }
                third = false;
                toomanymatches();
                art();
                Console.WriteLine("How many matches would you like to remove player 1?");
                points.p1 = Convert.ToInt32(Console.ReadLine());
                toomanymatches();
                points.ip = points.ip - points.p1;
                Console.WriteLine(points.ip + " matches are remaining");
                lost = true;
                third = false;
                second = false;

                if (points.ip == 0)
                {
                    break;
                }
                art();
                Console.WriteLine("How many matches would you like to remove player 2?");
                points.p2 = Convert.ToInt32(Console.ReadLine());
                toomanymatches();
                points.ip = points.ip - points.p2;
                Console.WriteLine(points.ip + " matches are remaining");
                lost = false;
                second = true;

                if (points.ip == 0)
                {
                    break;
                }
                art();
                Console.WriteLine("How many matches would you like to remove player 3?");
                points.p3 = Convert.ToInt32(Console.ReadLine());
                toomanymatches();
                points.ip = points.ip - points.p3;
                Console.WriteLine(points.ip + " matches are remaining");
                third = true;

            }
            if (lost == false)
            {
                Console.WriteLine("Player 1 Wins!");
                points.points1++;
            }
            if (lost == true || second == true)
            {
                Console.WriteLine("Player 2 Wins!");
                points.points2++;
            }
            if (third == false)
            {
                Console.WriteLine("Player 3 Wins!");
                points.points3++;
            }

        }
        static void threeplayermodescore()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Player 1: " + points.points1 + " Player 2: " + points.points2 + " Player 3: " + points.points3);
            Console.WriteLine("-------------------------------------------------");
            if (points.rounds == 0)
            {
                if (points.points1 >= points.points2 || points.points1 >= points.points3)
                {
                    Console.WriteLine("Player 1 is victorious");
                }
                if (points.points2 >= points.points1 || points.points2 >= points.points3)
                {
                    Console.WriteLine("Player 2 is victorious");
                }
                if (points.points3 >= points.points1 || points.points3 >= points.points2)
                {
                    Console.WriteLine("Player 3 is victorious");
                }
            }
        }
        static void oneplayermodehard()
        {
            bool lost = true;
            bool first = false;
            points.ip = 12;
            string turn = Turns();
            Console.WriteLine(turn + " goes first.");
            if (turn == "Player 1")
            {
                first = false;
            }
            else if (turn == "Player 2")
            {
                first = true;
            }
            while (points.ip >= 0)
            {
                if (points.ip == 0)
                {
                    break;
                }

                if (first == false)
                {
                    art();
                    Console.WriteLine("How many matches would you like to remove player 1?");
                    points.p1 = Convert.ToInt32(Console.ReadLine());
                    toomanymatches();
                    points.ip = points.ip - points.p1;
                    Console.WriteLine(points.ip + " matches are remaining");
                    lost = true;
                    art();
                    if (points.ip == 0)
                    {
                        break;
                    }

                    switch (points.ip)
                    {
                        // if he starts with 1
                        case 11:
                            Console.WriteLine("I will remove 2 matches");
                            points.ip = points.ip - 2;
                            lost = false;
                            break;
                        case 8:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        case 7:
                            Console.WriteLine("I will remove 2 matches");
                            points.ip = points.ip - 2;
                            lost = false;
                            break;
                        case 6:
                            Console.WriteLine("I will remove 1 matches");
                            points.ip = points.ip - 1;
                            lost = false;
                            break;
                        // if he starts with 2
                        case 10:
                            Console.WriteLine("I will remove 1 match");
                            points.ip = points.ip - 1;
                            lost = false;
                            break;

                        // if he starts with 3
                        case 9:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        // pattern repeats
                        case 5:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        case 4:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        case 3:
                            Console.WriteLine("I will remove 2 matches");
                            points.ip = points.ip - 2;
                            lost = false;
                            break;

                        case 1:
                            Console.WriteLine("I will remove 1 match");
                            points.ip = points.ip - 1;
                            lost = false;
                            break;
                    }
                    Console.WriteLine(points.ip + " matches are remaining");
                }
                else if (first == true)
                {
                    art();
                    switch (points.ip)
                    {

                        //guarantee a win
                        case 12:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        case 8:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        case 7:
                            Console.WriteLine("I will remove 2 matches");
                            points.ip = points.ip - 2;
                            lost = false;
                            break;
                        case 6:
                            Console.WriteLine("I will remove 1 match");
                            points.ip = points.ip - 1;
                            lost = false;
                            break;
                        case 4:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        case 3:
                            Console.WriteLine("I will remove 2 matches");
                            points.ip = points.ip - 2;
                            lost = false;
                            break;
                        case 2:
                            Console.WriteLine("I will remove 1 match");
                            points.ip = points.ip - 1;
                            lost = false;
                            break;
                    }
                    Console.WriteLine(points.ip + " matches are remaining");
                    art();
                    if (points.ip == 0)
                    {
                        break;
                    }

                    Console.WriteLine("How many matches would you like to remove player 1?");
                    points.p1 = Convert.ToInt32(Console.ReadLine());
                    toomanymatches();
                    points.ip = points.ip - points.p1;
                    Console.WriteLine(points.ip + " matches are remaining");
                    lost = true;
                    art();
                }


            }
            if (lost == false)
            {
                Console.WriteLine("Player 1 Wins!");
                points.points1++;
            }
            else if (lost == true)
            {
                Console.WriteLine("Player 2 Wins!");
                points.points2++;
            }


        }
        static void oneplayermodeeasy()
        {
            bool lost = true;
            bool first = false;
            points.ip = 12;
            string turn = Turns();
            Console.WriteLine(turn + " goes first.");
            if (turn == "Player 1")
            {
                first = false;
            }
            else if (turn == "Player 2")
            {
                first = true;
            }
            while (points.ip >= 0)
            {
                if (points.ip == 0)
                {
                    break;
                }

                if (first == false)
                {
                    art();
                    Console.WriteLine("How many matches would you like to remove player 1?");
                    points.p1 = Convert.ToInt32(Console.ReadLine());
                    toomanymatches();
                    points.ip = points.ip - points.p1;
                    Console.WriteLine(points.ip + " matches are remaining");
                    lost = true;
                    art();
                    if (points.ip == 0)
                    {
                        break;
                    }

                    switch (points.ip)
                    {
                        // if he starts with 1
                        case 11:
                            Console.WriteLine("I will remove 1 match");
                            points.ip = points.ip - 1;
                            lost = false;
                            break;
                        case 8:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        case 7:
                            Console.WriteLine("I will remove 2 matches");
                            points.ip = points.ip - 2;
                            lost = false;
                            break;
                        case 6:
                            Console.WriteLine("I will remove 1 matches");
                            points.ip = points.ip - 1;
                            lost = false;
                            break;
                        // if he starts with 2
                        case 10:
                            Console.WriteLine("I will remove 1 match");
                            points.ip = points.ip - 1;
                            lost = false;
                            break;

                        // if he starts with 3
                        case 9:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        // pattern repeats
                        case 5:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        case 4:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        case 3:
                            Console.WriteLine("I will remove 2 matches");
                            points.ip = points.ip - 2;
                            lost = false;
                            break;

                        case 1:
                            Console.WriteLine("I will remove 1 match");
                            points.ip = points.ip - 1;
                            lost = false;
                            break;
                    }
                    Console.WriteLine(points.ip + " matches are remaining");
                    art();
                }
                else if (first == true)
                {
                    switch (points.ip)
                    {
                        case 9:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        case 10:
                            Console.WriteLine("I will remove 2 matches");
                            points.ip = points.ip - 2;
                            lost = false;
                            break;
                        case 12:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        case 11:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        case 5:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        case 8:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        case 7:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        case 6:
                            Console.WriteLine("I will remove 2 match");
                            points.ip = points.ip - 2;
                            lost = false;
                            break;
                        case 4:
                            Console.WriteLine("I will remove 3 matches");
                            points.ip = points.ip - 3;
                            lost = false;
                            break;
                        case 3:
                            Console.WriteLine("I will remove 2 matches");
                            points.ip = points.ip - 2;
                            lost = false;
                            break;
                        case 2:
                            Console.WriteLine("I will remove 1 match");
                            points.ip = points.ip - 1;
                            lost = false;
                            break;
                        case 1:
                            Console.WriteLine("I will remove 1 match");
                            points.ip = points.ip - 1;
                            lost = false;
                            break;
                    }
                    Console.WriteLine(points.ip + " matches are remaining");
                    art();

                    if (points.ip == 0)
                    {
                        break;
                    }

                    Console.WriteLine("How many matches would you like to remove player 1?");
                    points.p1 = Convert.ToInt32(Console.ReadLine());
                    toomanymatches();
                    points.ip = points.ip - points.p1;
                    Console.WriteLine(points.ip + " matches are remaining");
                    art();
                    lost = true;
                }


            }
            if (lost == false)
            {
                Console.WriteLine("Player 1 Wins!");
                points.points1++;
            }
            else if (lost == true)
            {
                Console.WriteLine("Player 2 Wins!");
                points.points2++;
            }


        }
    }
}


