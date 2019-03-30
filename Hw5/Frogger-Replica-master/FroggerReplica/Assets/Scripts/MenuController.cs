using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject panel;
    public void UserSelectEasy()
    {
        ResetValues();
        CarSpawner.spawnDelay = .3f;
        SceneManager.LoadScene(1);
    }
    public void UserSelectMedium()
    {
        ResetValues();
        CarSpawner.spawnDelay = .2f;
        SceneManager.LoadScene(1);
    }
    public void UserSelectHard()
    {
        ResetValues();
        CarSpawner.spawnDelay = .1f;
        SceneManager.LoadScene(1);
    }
    public void UserSelectReplay()
    {
        ResetValues();
        SceneManager.LoadScene(1);
    }
    public void UserSelectMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void UserSelectInstructions()
    {
        panel.SetActive(true);
    }
    public void UserSelectOK()
    {
        panel.SetActive(false);
    }
    private void ResetValues()
    {
        HealthController.health = 3;
        Timer.secondsCount = 0;
        Timer.minuteCount = 0;
        Timer.hourCount = 0;
        Score.CurrentScore = 0;
    }
}
