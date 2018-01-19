using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    internal static int score = -1;
    internal static int bestScore = 0;
    Text scoreTextView;
    internal string textTemplate;

    void Start()
    {
        scoreTextView = transform.GetComponent<Text>();
        textTemplate = scoreTextView.text;
        bestScore = PlayerPrefs.GetInt("bestScore");
    }

    void OnEnable()
    {
        InputAggregator.OnIncreaseScoreEvent += IncreaseScore;
    }

    void OnDisable()
    {
        InputAggregator.OnIncreaseScoreEvent -= IncreaseScore;
    }


    internal void IncreaseScore()
    {
        score += 1;
        scoreTextView.text = string.Format(textTemplate, score.ToString());
        if (score > PlayerPrefs.GetInt("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore", score);
            bestScore = PlayerPrefs.GetInt("bestScore");
        }

        Debug.Log("Score:" + score + "\nBest:" + bestScore);
    }

    internal static void ResetScore()
    {
        score = -1;
    }

}