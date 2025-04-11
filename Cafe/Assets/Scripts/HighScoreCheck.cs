using TMPro;
using UnityEngine;

public class HighScoreCheck : MonoBehaviour
{
    private int HighScoreNum;
    public TMPro.TMP_Text Days;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HighScoreNum = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        Days.text = "High Score: " + HighScoreNum + " days";
    }
}
