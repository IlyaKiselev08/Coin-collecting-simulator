using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float _timer;
    public TextMeshProUGUI timerText;
    private bool _isTimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isTimer == true)
        {
            _timer += Time.deltaTime;
            timerText.text = "Время: " + GetCurrentTime();
        }
    }
    public void StartTimer()
    {
        _isTimer = true;
        _timer = 0;
    }
    public void StopTimer()
    {
        _isTimer = false;
    }
    public string GetCurrentTime()
    {
        int minutes = Mathf.RoundToInt(_timer) / 60;
        int seconds = Mathf.RoundToInt(_timer) % 60;
        return $"{minutes:D2}:{seconds:D2}";
    }
 }
