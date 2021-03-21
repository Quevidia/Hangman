using System;
using System.Collections.Generic;
using static ListOfWords;

class Program // Create the class for our app!
{
    static void Main() // Create the entry-point method, which is the exact block of code that will be ran.
    {
        Console.Clear(); // Clear the console.
        while (true) // Create a while true loop that will continue going continuously, until a break statement has been speciifed.
        {
            // Okay, let's start up by setting up the word.
            Random Random = new Random(); ListOfWords AllWords = new ListOfWords(); // Make an instance of the Random class so we can create random numbers, then make an instance of the ListOfWords array.
            string ExactWord = AllWords.Words[Random.Next(AllWords.Words.Length)].ToUpper(); // Create a string that will be the ExactWord. This will be a random word chosen from the ListOfWords array.
            char[][] WordToGuess = new char[ExactWord.Length][]; // Create a jagged array which will contain the letters of ExactWord. This will be useful for when the user actually plays hangman.
            List<char> GuessedLetters = new List<char> { ' ', '-' }; // Create a new list which will hold all guessed letters. This will also hold blacklisted letters by default, which will not change into "-" if found in WordToGuess.
            int Chances = 7; int Attempts = 0; // Create an integer that will be used as the amount of chances, then create another integer that will account the number of attempts.
            bool GameEnded = false; // Create a boolean that will be used to determine whether the game has ended or not.
            for (int i = 0; i < ExactWord.Length; i++) // Create a for loop that will loop as many times as the length of ExactWord.
            {
                char Value = '-'; // Define the Value string, which will be placed into WordToGuess[i][0].
                if (GuessedLetters.Contains(ExactWord[i])) Value = ExactWord[i]; // Check if GuessedLetters contains ExactWord[i]. If it does, set Value to be the same as ExactWord[i].
                WordToGuess[i] = new char[] { Value, ExactWord[i] }; // Append an array onto WordToGuess, containing Value as the first instance of the array, then ExactWord[i] converted into a string.
            }

            // Now, we can start the session of hangman!
            Console.WriteLine("Hello and welcome to hangman! You will be given a random possibly-every-day word and you will have to guess the letters for it! You will have 7 chances, and for each letter you get incorrect, you will lose a chance!"); // Announce to the player that they are playing hangmna.
            Console.WriteLine("Okay, let's start!"); // Announce that the game is about to start.
            Console.WriteLine($"Chances left: {Chances}"); // Write the amount of chances left.
            foreach (char[] Char in WordToGuess) Console.Write(Char[0]); // Go through each array in the WordToGuess jagged array, then write Char[0]'s string value onto the console.
            while (!GameEnded) // Make a while loop that will continue until GameEnded is True.
            {
                char KeyPressed = char.ToUpper(Console.ReadKey(true).KeyChar); bool KeyInWord = false; // Get the next key pressed converted to a string and then made upper-case, then create a new boolean used to determine whether the key is actually in the word or not.
                Attempts++; // Increment Attempts.
                if (!GuessedLetters.Contains(KeyPressed)) // Check if GuessedLetters does not contain KeyPressed.
                {
                    foreach (char[] Char in WordToGuess) // Go through all arrays in the WordToGuess jagged array.
                    {
                        if (Char[1] == KeyPressed) // Check if Char[1] is the same as the user input and the list does not already contain the user input.
                        {
                            Char[0] = Char[1]; // Change Char[0] to have the same value as Char[1]
                            KeyInWord = true; // Set KeyInWord to true.
                        }
                    }
                    Console.SetCursorPosition(0, 4); Console.Write("\r"); foreach (char[] Char2 in WordToGuess) Console.Write(Char2[0]); Console.Write($"\n{new string(' ', 100)}\r"); // Wipe out the current line, then go through each array in the WordToGuess jagged array and then write Char[0]'s string value onto the console.
                    GuessedLetters.Add(KeyPressed); // Add the KeyPressed value onto the GuessedLetters list.
                }
                if (!KeyInWord) // Check if KeyInWord is false.
                {
                    Chances--; // Decrement Chances.
                    Console.SetCursorPosition(0, 3); Console.WriteLine($"Chances left: {Chances}"); // Set the cursor position to the 3rd line, then overwrite the chances left statement.
                    foreach (char[] Char in WordToGuess) Console.Write(Char[0]); // Go through each array in the WordToGuess jagged array, then write Char[0]'s string value onto the console.
                }
                GameEnded = true; // Set GameEnded to true. This will be set to false in the next line if the criterias that will be mentioned do not meet.
                foreach (char[] Value in WordToGuess) if (Value[0] != Value[1]) GameEnded = false; // Go through all string arrays in WordToGuess, and check if the array's first value is not the same as the array's second value. If this is the case, set GameEnded to false.
                if (Chances != 0 && !KeyInWord) // Check if the user still has at least one chance and KeyInWord is false.
                {
                    Console.WriteLine("\nWhoops! Seems like the key you have inputted has been mentioned already, or it is not in the word!");
                }
                else if (Chances == 0) // Check if Chances is 0.
                {
                    Console.WriteLine("\nOh dear, you ran out of chances. Make sure that you are keeping track of the word. Better luck next time!");
                    break; // End the loop.
                }
                else if (GameEnded == true) // Check if the game has ended.
                {
                    Console.WriteLine($"\nCongratulations, you completed the game!\nThe amount of attempts made were {Attempts} attempts.");
                }
            }
            Console.WriteLine("Would you like to play again? (Y/N)"); // Ask the user if he would like to try again.
            string PlayAgain = "NOT CHECKED"; // Create a string value that will depict whether to play again or not.
            while (true)
            {
                ConsoleKeyInfo KeyBeingRead = Console.ReadKey(true); // Create a new variable that will depict the key being read.
                if (KeyBeingRead.Key == ConsoleKey.Y) { Console.Clear(); PlayAgain = "true"; } else if (KeyBeingRead.Key == ConsoleKey.N) PlayAgain = "false"; // Check if the user pressed Y or N. Y - clear the console and set PlayAgain to "true", N - set PlayAgain to "false".
                if (PlayAgain != "NOT CHECKED") break; // If PlayAgain is not "NOT CHECKED", end the loop.
            }
            if (PlayAgain != "true") break; // End the loop, which will end this process.
        }
    }
}
