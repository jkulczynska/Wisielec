using System;
using System.Collections.Generic;
using System.Threading;

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
        // rules
        Console.WriteLine("Autorzy: Julia Kulczyńska, Kinga Świniarska, Katsiaryna Blahenkova");
        Console.WriteLine("Zasady: Zgaduj litery lub całe słowo. 6 błędów = przegrana.");
        Console.WriteLine("Poprawna litera? Odsłaniamy ją. Błąd? Tracisz życie.");
        Console.WriteLine("Powodzenia!");
        Thread.Sleep(4500); 

        while (lives > 0 && new string(guessedWord) != wordToGuess)
        {
            Console.Clear();

          
            string recentWord = new string(guessedWord); 
            Console.WriteLine("Wisielec - program zaliczeniowy");
            Console.WriteLine("");
            Console.WriteLine($"Słowo: {recentWord}");
            Console.WriteLine($"Życia: {lives}");
            Console.WriteLine($"Podane litery: {string.Join(", ", guessedLetters)}");

            Console.WriteLine();
            Console.Write(">> Twoja litera / słowo: "); 

            string input = Console.ReadLine();

            
            if (input == "")
            {
                Console.WriteLine("Nie wpisano nic! Spróbuj ponownie.");
                Console.ReadKey();
                continue;
            }

            
            if (input.Length > 1)
            {
                if (input == wordToGuess)
                {
                    guessedWord = wordToGuess.ToCharArray();
                    break; // win!:)
                }
                else
                {
                    lives--;
                    Console.WriteLine("Złe słowo! Straciłeś życie.");
                    Console.ReadKey();
                    continue;
                }
            }

            
            char letter = input[0]; 
            
            
            
            if (!char.IsLetter(letter))
            {
                Console.WriteLine("To nie jest litera! Spróbuj ponownie.");
                Console.ReadKey();
                continue;
            }

          
            bool alreadyGuessed = false;
            foreach (char letterInList in guessedLetters)
            {
                if (letterInList == letter)
                {
                    alreadyGuessed = true;
                    break;
                }
            }
            if (alreadyGuessed)
            {
                Console.WriteLine("Już podano tę literę!");
                Console.ReadKey();
                continue;
            }

            guessedLetters.Add(letter);

           
            bool found = false;
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == letter)
                {
                    guessedWord[i] = letter;
                    found = true;
                }
            }

            
            if (!found)
            {
                lives--;
                Console.WriteLine("Zła litera! Straciłeś życie.");
                Console.ReadKey();
            }
        }

        // the end
        Console.Clear();
        Console.WriteLine("Koniec gry!");
        Console.WriteLine($"Słowo: {wordToGuess}");
        if (lives > 0)
            Console.WriteLine("Gratulacje! Wygrałeś!");
        else
            Console.WriteLine("Przegrałeś! Spróbuj ponownie.");
    }
}
