using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pausePanel;
    private bool paused = false;
    void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (paused == false)
            {
                PauseGame();
                pausePanel.SetActive(true);
            }
            else
            {
                ContinueGame();
                pausePanel.SetActive(false);
            }
        }
    }
    private void PauseGame()
    {
        paused = true;
        Time.timeScale = 0;
    }
    private void ContinueGame()
    {
        paused = false;
        Time.timeScale = 1;
    }
}
