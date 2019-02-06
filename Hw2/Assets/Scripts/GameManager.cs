using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using System.IO;

public class GameManager : MonoBehaviour {

    public Question[] questions;
    private static List<Question> unansweredQuestions;
    private Question currentQuestion;
    [SerializeField]
    private Text questionText;
    [SerializeField]
    private Text AText;
    [SerializeField]
    private Text BText;
    [SerializeField]
    private Text CText;
    [SerializeField]
    private Text DText;
    [SerializeField]
    private Text TimeText;
    [SerializeField]
    private Text CorrectText;
    [SerializeField]
    private Text RemainingText;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Text A;
    [SerializeField]
    private Text B ;
    [SerializeField]
    private Text C;
    [SerializeField]
    private Text D;
    [SerializeField]
    private Text ScoreText;
    private float waitTime = 15f;
    private float timeBetweenQuestions = 1.5f;
    private bool answered;
    private static int numCorrect;
    private static int i = 0;

    private void Start()
    {
        if (unansweredQuestions == null)
            LoadQuestions();
        else if (unansweredQuestions.Count == 0)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(2);
            SetScore();
        }

        SetCurrentQuestion();
    }

    private void LoadQuestions()
    {
        using (StreamReader r = new StreamReader("E:\\Stuff\\Class\\CS\\Game_Programming\\Projects\\Hw2\\Assets\\Data\\Spanish.csv"))
        {
            Debug.Log("Opened File");

            Debug.Log("Setting questions");
            while (!r.EndOfStream)
            {
                var line = r.ReadLine();
                var values = line.Split(',');

                questions[i].question = values[0];
                questions[i].AText = values[1];
                questions[i].BText = values[2];
                questions[i].CText = values[3];
                questions[i].DText = values[4];
                questions[i].isA = bool.Parse(values[5]);
                questions[i].isB = bool.Parse(values[6]);
                questions[i].isC = bool.Parse(values[7]);
                questions[i].isD = bool.Parse(values[8]);
                i++;
            }
            Debug.Log("Done reading");

            //set questions
            unansweredQuestions = questions.ToList<Question>();
        }
    }

    private void SetCurrentQuestion()
    {
        Debug.Log("Getting random");
        //Get random question
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        Debug.Log("Setting display");
        //Set question and answers
        questionText.text = currentQuestion.question;
        AText.text = currentQuestion.AText;
        BText.text = currentQuestion.BText;
        CText.text = currentQuestion.CText;
        DText.text = currentQuestion.DText;

        //Set text to show number of remaining questions
        RemainingText.text = (unansweredQuestions.Count - 1).ToString();

        //Set correct
        CorrectText.text = numCorrect.ToString();

        //Set background answers
        checkAnswers();

        //Reset bool
        answered = false;

        //Timer
        Update();

        //If no answer
        StartCoroutine(TransistionToNextQuestion());
    }

    private void checkAnswers()
    {
        if (currentQuestion.isA)
            A.text = "CORRECT";
        else
            A.text = "INCORRECT";
        if (currentQuestion.isB)
            B.text = "CORRECT";
        else
            B.text = "INCORRECT";
        if (currentQuestion.isC)
            C.text = "CORRECT";
        else
            C.text = "INCORRECT";
        if (currentQuestion.isD)
            D.text = "CORRECT";
        else
            D.text = "INCORRECT";
    }

    IEnumerator TransistionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);

        if (answered)
            yield return new WaitForSeconds(timeBetweenQuestions);
        else
            yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        waitTime -= Time.deltaTime;
        //If button clicked right as timing out
        if (waitTime < 0)
        {
            waitTime = 0;
        }
        TimeText.text = (waitTime).ToString("0");
    }

    public void UserPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void UserQuit()
    {
        Application.Quit();
    }

    public void UserBack()
    {
        //Reset correct when leave
        numCorrect = 0;
        SceneManager.LoadScene(0);
    }

    public void UserSelectA()
    {
        answered = true;
        animator.SetTrigger("ClickedA");
        if (currentQuestion.isA)
            numCorrect++;
        StartCoroutine(TransistionToNextQuestion());
    }
    public void UserSelectB()
    {
        answered = true;
        animator.SetTrigger("ClickedB");
        if (currentQuestion.isB)
            numCorrect++;
        StartCoroutine(TransistionToNextQuestion());
    }
    public void UserSelectC()
    {
        answered = true;
        animator.SetTrigger("ClickedC");
        if (currentQuestion.isC)
            numCorrect++;
        StartCoroutine(TransistionToNextQuestion());
    }
    public void UserSelectD()
    {
        answered = true;
        animator.SetTrigger("ClickedD");
        if (currentQuestion.isD)
            numCorrect++;
        StartCoroutine(TransistionToNextQuestion());
    }

    public void SetScore()
    {
        ScoreText.text = numCorrect + " / " + i;
    }
}
