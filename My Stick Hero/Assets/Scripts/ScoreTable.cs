using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTable : MonoBehaviour {

    [SerializeField]
    private Text score;
    [SerializeField]
    private Text best;


    void OnEnable()
    {
        score.text = ScoreManager.score.ToString();
        best.text = ScoreManager.bestScore.ToString();
    }
}
