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
    }

    public bool IsTimeUp()
    {
        return timer <= 0;
    }
}
