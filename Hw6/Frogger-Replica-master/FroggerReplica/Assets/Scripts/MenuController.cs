using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject panel;
    public Slider slider;
    public void UserSelectPlay()
    {
        ResetValues();
        CarSpawner.spawnDelay = slider.value;
        SceneManager.LoadScene(1);
    }

    public void UserSelectReplay()
    {
        ResetValues();
        SceneManager.LoadScene(1);
    }
    public void UserSelectMenu()
    {
        Time.timeScale = 1;
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
