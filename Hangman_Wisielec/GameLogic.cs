using System;
using System.Collections.Generic;

class GameLogic
{
    private string wordToGuess;
    private char[] guessedWord;
    private int lives;
    private List<char> guessedLetters;
    
    public GameLogic()
    {
        wordToGuess = DataBaseWords.GetRandomWord();
        guessedWord = new string('_', wordToGuess.Length).ToCharArray();
        lives = 6;
        guessedLetters = new List<char>();
    }

    public void Start()
    {
        while (lives > 0 && new string(guessedWord) != wordToGuess)
        {
            Console.Clear();
            DisplayGameState();

            Console.Write("Podaj literę: ");
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (!char.IsLetter(input))
            {
                Console.WriteLine("Wpisz tylko jedną literę!");
                continue;
            }

            input = char.ToLower(input);

            if (guessedLetters.Contains(input))
            {
                Console.WriteLine("Już podano tę literę!");
                continue;
            }

            guessedLetters.Add(input);

            if (wordToGuess.Contains(input))
            {
                for (int i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] == input)
                    {
                        guessedWord[i] = input;
                    }
                }
            }
            else
            {
                lives--;
                Console.WriteLine("Zła litera! Straciłeś życie.");
            }
        }

        Console.Clear();
        DisplayGameState();
        Console.WriteLine(lives > 0 ? "Gratulacje! Wygrałeś!" : $"Przegrałeś! Hasło to: {wordToGuess}");
    }

    private void DisplayGameState()
    {
        Console.WriteLine("Wisielec - Zgadnij słowo!");
        Console.WriteLine($"Słowo: {new string(guessedWord)}");
        Console.WriteLine($"Pozostałe życia: {lives}");
        Console.WriteLine($"Użyte litery: {string.Join(", ", guessedLetters)}");
    }
}
