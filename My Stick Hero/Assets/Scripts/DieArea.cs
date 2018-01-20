using UnityEngine;

public class DieArea : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.tag == "Player")
        {
            GameStateManager.instance.State = GameStateManager.GameState.GameOverMenu;
            EventAggregator.Game_OnGameOver();
        }
    }


    void Update()
    {
        transform.position = new Vector3(
            GameObject.FindGameObjectWithTag("Player").transform.position.x,
            transform.position.y, transform.position.z);
    }
}
