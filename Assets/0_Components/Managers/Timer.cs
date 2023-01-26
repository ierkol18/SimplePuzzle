using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer = 60f;
    public TMP_Text timerText;

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = ((int)timer).ToString("F2");

        // Update the timer
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
           // EndGame();
        }
    }

    public bool IsTimeUp()
    {
        return timer <= 0;
    }
}
