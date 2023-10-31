using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreSystem : MonoBehaviour
{
    List<PlayerScore> highScoreList = new List<PlayerScore>();

    [SerializeField]
    List<TextMeshProUGUI> highScoresTMP = new List<TextMeshProUGUI>();
    [SerializeField]
    List<TextMeshProUGUI> highTimeTMP = new List<TextMeshProUGUI>();

    public bool CheckHighScore(int score, string time)
    {
        bool newHighScore;
        LoadHighScores();
        newHighScore = AddHighScore(score, time);
        SortHighScores();
        SaveHighScores();
        return newHighScore;
        //PlayerPrefs.DeleteAll();
    }

    private void LoadHighScores()
    {
        highScoreList.Clear();

        for (int i = 0; i < 5; i++)
        {
            highScoreList.Add(new PlayerScore(PlayerPrefs.GetInt("HighScore" + i, 0),
                PlayerPrefs.GetString("HighTime" + i, "")));
        }
    }

    void SortHighScores()
    {
        highScoreList.Sort((x, y) => y.Score.CompareTo(x.Score));
    }

    void SaveHighScores()
    {
        int count = highScoreList.Count;
        if (count > 5)
        {
            count = 5;
        }

        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                if (highScoreList[i].Score != 0)
                {
                    PlayerPrefs.SetInt("HighScore" + i, highScoreList[i].Score);
                    PlayerPrefs.SetString("HighTime" + i, highScoreList[i].Time);
                }
            }
        }
    }

    bool AddHighScore(int newScore, string newTime)
    {
        if (highScoreList.Count >= 5 && newScore <= highScoreList[4].Score)
        {
            return false;
        }

        highScoreList.Add(new PlayerScore(newScore, newTime));
        return true;
    }

    public void UpdateHighScoreUI()
    {
        LoadHighScores();
        for (int i = 0; i < 5; i++)
        {
            if (highScoreList[i] == null || highScoreList[i].Score == 0)
            {
                highScoresTMP[i].text = "";
                highTimeTMP[i].text = "";
            }
            else
            {
                highScoresTMP[i].text = highScoreList[i].Score.ToString();
                highTimeTMP[i].text = highScoreList[i].Time;
            }
        }
    }

    private class PlayerScore
    {
        public int Score { get; set; }
        public string Time { get; set; }

        public PlayerScore(int score, string time)
        {
            Score = score;
            Time = time;
        }
    }
}
