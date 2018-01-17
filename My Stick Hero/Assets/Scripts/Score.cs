using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    internal float score = -1;
    Text scoreTextView;
    internal string textTemplate;

    void Start()
    {
        scoreTextView = transform.GetComponent<Text>();
        textTemplate = scoreTextView.text;
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
    }
}
