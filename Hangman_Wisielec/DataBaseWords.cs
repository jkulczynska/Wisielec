using System;

class DataBaseWords
{
    private static readonly string[] Words = { "programowanie", "komputer", "wisielec", "csharp", "konsola" };

    public static string GetRandomWord()
    {
        Random rand = new Random();
        return Words[rand.Next(Words.Length)];
    }
}