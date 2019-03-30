using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int CurrentScore;

	public Text scoreText;
    public Text highText;

	void Start ()
	{
		scoreText.text = "Score: " + CurrentScore.ToString();
        highText.text = "High Score: " + HighScore.highScore;
	}
}
