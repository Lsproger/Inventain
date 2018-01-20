using UnityEngine;

public class RightPlatformEdge : MonoBehaviour
{
    internal const float DEFAULT_SCALE = 1;
    internal const float PLATFORM_WIDTH = 5;
    internal const float MIN_PLATFORM_SCALE = 0.2f;
    internal const float MAX_PLATFORM_SCALE = 1f;


    [SerializeField]
    private Transform platform;


    void OnBecameInvisible()
    {
        Destroy(transform.parent.gameObject);
        Game.stickCounter = 1;
    }


    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            if (GameStateManager.instance.State == GameStateManager.GameState.Game)
            {
                EventAggregator.Character_OnPlatformEdgeReached();
                EventAggregator.Score_OnIncrease();
            }

            CreateNextPlatform();
        }
    }


    internal void CreateNextPlatform()
    {
        Transform nextPlatform = Instantiate(platform);
        SetPlatformComponents(nextPlatform);

        float nextScale = Random.Range(MIN_PLATFORM_SCALE, MAX_PLATFORM_SCALE);
        float distance = Random.Range(1, 5);
        float nextPositionX = (nextPlatform.transform.localScale.x * PLATFORM_WIDTH) +
            transform.parent.transform.position.x + distance;

        SetPlatformPositionAndTransform(nextPlatform, nextScale, nextPositionX);
    }


    internal void SetPlatformComponents(Transform platform)
    {
        platform.transform.Find("RedSquare").
            GetComponent<SpriteRenderer>().enabled = true;
        platform.transform.Find("RightPlatformEdge").
            GetComponent<BoxCollider2D>().enabled = false;
    }


    internal void SetPlatformPositionAndTransform(Transform platform, float scale, float coordX)
    {
        platform.transform.localScale = new Vector3
            (
            scale,
            platform.transform.localScale.y,
            platform.transform.localScale.z
            );

        platform.transform.position = new Vector3
            (
            coordX,
            transform.parent.transform.position.y,
            transform.position.z
            );

        platform.Find("Stick").localScale = 
            new Vector3(DEFAULT_SCALE / scale, DEFAULT_SCALE, 1f);

        platform.Find("RedSquare").localScale = 
            new Vector3(DEFAULT_SCALE / scale, DEFAULT_SCALE, 1f);
    }
}
