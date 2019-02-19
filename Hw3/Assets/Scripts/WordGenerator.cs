using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class WordGenerator {
    private static string[] wordList = File.ReadAllLines(@"E:\Stuff\Class\CS\Game_Programming\Projects\Hw3\Assets\File\words.txt", Encoding.UTF8);

    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];

        if (MenuManager.easy)
        {
            while (randomWord.Length > 4)
            {
                randomIndex = Random.Range(0, wordList.Length);
                randomWord = wordList[randomIndex];
            }          
        }
        else if (MenuManager.medium)
        {
            while (randomWord.Length < 4 || randomWord.Length > 6)
            {
                randomIndex = Random.Range(0, wordList.Length);
                randomWord = wordList[randomIndex];
            }
        }
        else if (MenuManager.hard)
        {
            while (randomWord.Length < 6)
            {
                randomIndex = Random.Range(0, wordList.Length);
                randomWord = wordList[randomIndex];
            }
        }

        return randomWord;
    }
}
