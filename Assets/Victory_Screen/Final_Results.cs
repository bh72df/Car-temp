using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Final_Results : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI Final_Time;
    [SerializeField]
    public TextMeshProUGUI Final_Score;

    private void Start()
    {
        GameManager.Final_Result();
        GameManager.Final_Time();

        Final_Score.text = GameManager.Final_Result();
        Final_Time.text = GameManager.Final_Time();
    }

}
