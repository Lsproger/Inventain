using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    #region Fields
    internal const float NEW_PLATFORM_POSITION_X = 2.65f;
    internal const float NEW_PLATFORM_POSITION_Y = -10.5f;

    internal const float NEW_CHARACTER_POSITION_X = 0f;
    internal const float NEW_CHARACTER_POSITION_Y = -4.5f;

    internal const float CAMERA_LAYER = -10;


    [SerializeField]
    private Transform platform;
    #endregion


    #region Unity lifecycle
    void Start () {
        transform.Find("RestartButton").GetComponent<Button>().onClick.
            AddListener(delegate () 
            {
                RestartButton_OnCLick();
            });
    }
    #endregion


    #region Private methods
    private void DestroyPlatforms()
    {
        foreach (var pl in GameObject.FindGameObjectsWithTag("Platform"))
        {
            Destroy(pl);
        }
    }


    private void SetInitialSceneState()
    {
        Camera.main.transform.position = new Vector3(0, 0, CAMERA_LAYER);
        LoopBackground.SetInitialPosition();
        Transform newPlatform = Instantiate(platform,
            new Vector3(NEW_PLATFORM_POSITION_X, NEW_PLATFORM_POSITION_Y, 0),
            Quaternion.Euler(0, 0, 0));

        newPlatform.transform.Find("RedSquare").GetComponent<SpriteRenderer>().enabled = false;
        newPlatform.transform.Find("RightPlatformEdge").GetComponent<BoxCollider2D>().enabled = true;

        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(
            NEW_CHARACTER_POSITION_X,
            NEW_CHARACTER_POSITION_Y, 0);

        GameStateManager.Instance.State = GameStateManager.GameState.Game;
        Character.SetCharacterAnim(true);
    }
    #endregion


    #region Event handlers
    private void RestartButton_OnCLick()
    {
        ScoreManager.ResetScore();
        DestroyPlatforms();
        SetInitialSceneState();
    }
    #endregion
}
