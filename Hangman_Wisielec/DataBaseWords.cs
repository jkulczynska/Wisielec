﻿using System;

class DataBaseWords // creating list with words
{
    private static List<string> Words = new List<string> { "python", "procesor", "router", "algorytm", "programowanie", "komputer", "kod", "konsola", "klawiatura", "monitor" };
    
    
    

    public static string GetRandomWord()
    {
        Random rand = new Random();
        return Words[rand.Next(Words.Count)];
    }
}