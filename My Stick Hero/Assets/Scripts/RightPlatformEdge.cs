using UnityEngine;

public class RightPlatformEdge : MonoBehaviour
{

    internal const float DEFAULT_RED_SQUARE_SCALE = 0.08f * 5;
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
            Transform next = Instantiate(platform);
            float nextScale = Random.Range(1, 7);
            next.transform.localScale = new Vector3
                (
                nextScale,
                next.transform.localScale.y,
                next.transform.localScale.z
                );

            Debug.Log("Next scale" + nextScale);

            float distance = Random.Range(1, 5);

            float nextXValuePosition = next.transform.localScale.x +
                transform.parent.transform.position.x +
                distance;
            Debug.Log("NeXt width" + next.transform.localScale.y);
            Debug.Log("prev pos" + transform.parent.transform.position.x);
            Debug.Log("distance" + distance);
            next.transform.position = new Vector3
                (nextXValuePosition,
                transform.parent.transform.position.y,
                transform.position.z
                );
            next.Find("Square").localScale = new Vector3(DEFAULT_RED_SQUARE_SCALE / nextScale, 0.08f, 1f);

            if (GameState.state == GameState.States.Game)
            {
                InputAggregator.Game_OnPlatformEdgeReachedEvent();
            }
        }
    }
}
