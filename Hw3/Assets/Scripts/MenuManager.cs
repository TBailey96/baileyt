using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MenuManager : MonoBehaviour {

    public static bool easy = false;
    public static bool medium = false;
    public static bool hard = false;

    public void UserSelctEasy()
    {
        easy = true;
        medium = false;
        hard = false;
        SceneManager.LoadScene(1);
    }

    public void UserSelctMedium()
    {
        easy = false;
        medium = true;
        hard = false;
        SceneManager.LoadScene(1);
    }

    public void UserSelctHard()
    {
        easy = false;
        medium = false;
        hard = true;
        SceneManager.LoadScene(1);
    }
}
