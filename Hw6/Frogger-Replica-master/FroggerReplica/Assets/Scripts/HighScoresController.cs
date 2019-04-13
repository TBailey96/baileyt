using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HighScoresController : MonoBehaviour
{
    public Text HighScores;
    public GameObject panel;
    public InputField input;
    private int[] scores = new int[10];
    private int i = 0;
    private int x = 0;
    private string[] lines;
    private string[] allLines;

    private void Start()
    {
        panel.SetActive(false);

        lines = File.ReadAllLines(@"E:\Stuff\Class\CS\Game_Programming\Projects\Frogger-Replica-master\FroggerReplica\Assets\File\HighScores.txt");
        foreach (string line in lines)
        {
            scores[i] = Convert.ToInt32(line.Split(' ').Last());
            if (Score.CurrentScore > scores[i])
            {
                panel.SetActive(true);
                x = i;
                break;
            }
            else
                HighScores.text += "\n" + line;
            i++;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            HighScores.text = "";
            panel.SetActive(false);
            LineUpdate(x+1 + ". " + input.text.ToUpper() + " " + Score.CurrentScore, x);
            foreach(string line in allLines)
            {
                HighScores.text += "\n" + line;
            }
        }
    }
    private void LineUpdate(string newText, int line)
    {
        allLines = File.ReadAllLines(@"E:\Stuff\Class\CS\Game_Programming\Projects\Frogger-Replica-master\FroggerReplica\Assets\File\HighScores.txt");
        allLines[line] = newText;
        File.WriteAllLines(@"E:\Stuff\Class\CS\Game_Programming\Projects\Frogger-Replica-master\FroggerReplica\Assets\File\HighScores.txt", allLines);
    }
}