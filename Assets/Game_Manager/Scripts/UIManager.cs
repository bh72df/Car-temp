using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timeValue;
    [SerializeField]
    TextMeshProUGUI scoreValue;
    [SerializeField]
    TextMeshProUGUI LapNumber;
    [SerializeField]

    public Menu_Controller Menu_Controller_Script;

    void Start()
    {
        UpdateTimeUI(0);
        UpdateScoreUI(0);
        UpdateLapNumUI(0, 1);
    }

    public void UpdateTimeUI(float time)
    {
        int seconds = (int)time;
        timeValue.text = System.TimeSpan.FromSeconds(seconds).ToString("hh':'mm':'ss");
    }

    public void UpdateScoreUI(int value)
    {
        // "D5" - minimum of 5 digits, preceding shorter numbers with 0s
        scoreValue.text = value.ToString("D5");
    }

    public void UpdateLapNumUI(int lap, int TotalLap)
    {
        string Count = lap.ToString();
        LapNumber.text = Count + "/" + TotalLap;

        Debug.Log(lap);

        if (lap == TotalLap)
        {
            //GameManager.Final_Results();
            Menu_Controller_Script.Victory_Scene_Load();
        }

    }
}
