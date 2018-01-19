using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieArea : MonoBehaviour {

    internal float bestScore;


    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.tag == "Player")
        {
            Debug.Log("Death");
            GameStateManager.instance.State = GameStateManager.GameState.GameOverMenu;
            InputAggregator.OnGameOverEventHandler();
        }
    }

    void Update()
    {
        transform.position = new Vector3(
            GameObject.FindGameObjectWithTag("Player").transform.position.x,
            transform.position.y, transform.position.z);
    }

    internal void SaveScoreIfBest()
    {

    }
}
