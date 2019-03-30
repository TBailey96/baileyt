using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    public Image health1;
    public Image health2;
    public Image health3;

    void Start()
    {
        health1.enabled = true;
        health2.enabled = true;
        health3.enabled = true;
    }

    void Update()
    {
        if(HealthController.health == 3)
        {
            health1.enabled = true;
            health2.enabled = true;
            health3.enabled = true;
        }
        else if (HealthController.health == 2)
        {
            health1.enabled = true;
            health2.enabled = true;
            health3.enabled = false;
        }
        else if (HealthController.health == 1)
        {
            health1.enabled = true;
            health2.enabled = false;
            health3.enabled = false;
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
