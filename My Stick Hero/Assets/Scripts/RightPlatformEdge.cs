using UnityEngine;

public class RightPlatformEdge : MonoBehaviour
{

    internal const float DEFAULT_SCALE = 1;
    internal const float PLATFORM_WIDTH = 5;
    internal const float MIN_PLATFORM_SCALE = 0.2f;
    internal const float MAX_PLATFORM_SCALE = 1.5f;
    [SerializeField]
    private Transform platform;


    void OnBecameInvisible()
    {
        Destroy(transform.parent.gameObject);
    }


    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            Debug.Log("PLATFORM EDGE REACHED");
            obj.GetComponentInParent<Animator>().SetBool("isWalking", false);

            Transform nextPlatform = Instantiate(platform);
            nextPlatform.transform.Find("RedSquare").GetComponent<SpriteRenderer>().enabled = true;
            float nextScale = Random.Range(MIN_PLATFORM_SCALE, MAX_PLATFORM_SCALE);
            float distance = Random.Range(1, 5);
            Debug.Log("Next scale" + nextScale);
            Debug.Log("Distance " + distance);
            nextPlatform.transform.localScale = new Vector3
                (
                nextScale,
                nextPlatform.transform.localScale.y,
                nextPlatform.transform.localScale.z
                );        

            

            float nextPositionX = (nextPlatform.transform.localScale.x * PLATFORM_WIDTH) +
                transform.parent.transform.position.x +
                distance;

            Debug.Log("NeXt width" + nextPlatform.transform.localScale.y);
            Debug.Log("prev pos" + transform.parent.transform.position.x);
            Debug.Log("distance" + distance);

            nextPlatform.transform.position = new Vector3
                (nextPositionX,
                transform.parent.transform.position.y,
                transform.position.z
                );

            nextPlatform.Find("Stick").localScale = new Vector3(DEFAULT_SCALE / nextScale, DEFAULT_SCALE, 1f);
            nextPlatform.Find("RedSquare").localScale = new Vector3(DEFAULT_SCALE / nextScale, DEFAULT_SCALE, 1f);

            if (GameStateManager.instance.State == GameStateManager.GameState.Game)
            {
                InputAggregator.Game_OnPlatformEdgeReachedEvent();
            }
        }
    }
}
