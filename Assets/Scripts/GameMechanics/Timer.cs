using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [Space, SerializeField] TMP_Text timerText;

    float currentTime = 0;
    bool gameHasEnded;

    void Update()
    {
        if (gameHasEnded)
            return;

        UpdateTime();
    }
    void UpdateTime()
    {
        currentTime += Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        timerText.text = "Time: " + time.ToString(@"mm\:ss");
    }
}