using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    internal static int score = -1;
    internal static int bestScore = 0;
    internal string best = "bestScore";
    internal Text scoreTextView;
    internal string textTemplate;

    void Start()
    {
        scoreTextView = transform.GetComponent<Text>();
        textTemplate = scoreTextView.text;
        bestScore = PlayerPrefs.GetInt(best);
    }

    void OnEnable()
    {
        EventAggregator.OnIncreaseScoreEvent += IncreaseScore;
    }

    void OnDisable()
    {
        EventAggregator.OnIncreaseScoreEvent -= IncreaseScore;
    }


    internal void IncreaseScore()
    {
        score += 1;
        scoreTextView.text = string.Format(textTemplate, score.ToString());
        if (score > PlayerPrefs.GetInt(best))
        {
            PlayerPrefs.SetInt(best, score);
            bestScore = PlayerPrefs.GetInt(best);
        }
    }

    internal static void ResetScore()
    {
        score = -1;
    }

}