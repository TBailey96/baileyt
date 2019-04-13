using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour
{
    public Text txtTime;
    // Start is called before the first frame update
    void Update()
    {
        txtTime.text = "Time: " + Timer.time;
    }
}
