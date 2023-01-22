using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GuessGame
{
    class GameLaunch2
    {
        //private int score;
        private static int numberToGuess;
        private static bool start = false, gameOn=true;
        private static string playerDiffChoice = " ";
        public static void Launch()
        {
           //bool gameOn = true;
            string playY_N;
            bool correctStart = false;

            ///////////////////////////////////////////////////////////////////////// GAME IN SESSION /////////////////////////////////////////////////////////////////////////
            while (gameOn)
            {
                //Player first decides if they want to play or not
                do
                {
                    Console.WriteLine("Would you like to play the guessing game?\nEnter 'YES' or 'NO'");
                    playY_N = Console.ReadLine().ToUpper().Trim();

                    if (playY_N == "YES")
                    {
                        Console.WriteLine("Launching game...\n");
                        correctStart = true;
                    }

                    else if (playY_N == "NO")
                    {
                        Console.WriteLine("Exiting game...");
                        gameOn = false;
                        break;

                    }
                } while (correctStart == false);

                //////////// After player chooses "yes", let them choose their difficulty ////////////
                if (correctStart == true)
                {
                    //Time to choose difficulty for game
                    DifficultySettings();
                }

                //The guessing begins
                if (start == true)
                {
                    GuessingTime();
                }
            } ///////////////////////////////////////////////////////////////////////// GAME IN SESSION /////////////////////////////////////////////////////////////////////////


        }

        //PLAYER DIFFICULTY
        private static void DifficultySettings()
        {
            Random guessNumber = new Random();
            bool valid_difficulty = false;

            do
            {
                Console.WriteLine("Choose your difficulty, then press ENTER key.\nType E for Easy, M for Medium, H for Hard or X for EXTREME");
                playerDiffChoice = Console.ReadLine().ToUpper().Trim();

                if (playerDiffChoice == "E" || playerDiffChoice == "M" || playerDiffChoice == "H" || playerDiffChoice == "X")
                {
                    Console.WriteLine($"You chose {playerDiffChoice}");
                    valid_difficulty = true;
                }

                if (valid_difficulty == true)
                    break;

            } while (playerDiffChoice != "E" || playerDiffChoice != "M" || playerDiffChoice != "H" || playerDiffChoice != "X");

            //Easy : Numbers 0 - 10
            if (playerDiffChoice == "E")
            {
                numberToGuess = guessNumber.Next(0, 11);
            }

            //Medium : Numbers 0 - 25
            else if (playerDiffChoice == "M")
            {
                numberToGuess = guessNumber.Next(0, 26);
            }

            //Hard : Numbers 0 - 50
            else if (playerDiffChoice == "H")
            {
                numberToGuess = guessNumber.Next(0, 51);
            }

            //Extreme : Numbers 0 - 100
            else if (playerDiffChoice == "X")
            {
                numberToGuess = guessNumber.Next(0, 101);
            }
            //ALLOW GUESSING GAME TO START
            start = true;
        }

        private static void GuessingTime()
        {

            if (start == true)
            {
                int playerGuess = -1;
                char quitGame = 'N';
                int guessCount = 0;

                switch (playerDiffChoice)
                {
                    case "E":
                        Console.WriteLine("I'm thinking of a number between 0 and 10\nCan you guess it?");
                        break;

                    case "M":
                        Console.WriteLine("I'm thinking of a number between 0 and 25\nCan you guess it?");
                        break;

                    case "H":
                        Console.WriteLine("I'm thinking of a number between 0 and 50\nCan you guess it?");
                        break;

                    case "X":
                        Console.WriteLine("I'm thinking of a number between 0 and 100\nCan you guess it?");
                        break;
                }

                do
                {
                    bool isINT = false;
                    isINT = int.TryParse(Console.ReadLine(), out playerGuess);

                    if (!isINT)
                    {
                        Console.WriteLine("Integers only please!");
                    }

                    else if (playerGuess == numberToGuess)
                    {
                        guessCount++;
                        Console.WriteLine($"Congrats! You correctly guessed {numberToGuess}!\nAttempts: {guessCount}");
                        gameOn = false;
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Not the number! What's your next guess?");
                        guessCount++;
                        
                    }
                } while (playerGuess != numberToGuess || quitGame != 'Y');
  
            }
        }
    }
}

   

