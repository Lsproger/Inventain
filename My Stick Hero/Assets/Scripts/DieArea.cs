using UnityEngine;

public class DieArea : MonoBehaviour
{
    #region Unity lificycle
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.tag == "Player")
        {
            GameStateManager.Instance.State = GameStateManager.GameState.GameOverMenu;
            EventAggregator.Game_OnGameOver();
        }
    }


    void Update()
    {
        transform.position = new Vector3(
            GameObject.FindGameObjectWithTag("Player").transform.position.x,
            transform.position.y, transform.position.z);
    }
    #endregion
}
