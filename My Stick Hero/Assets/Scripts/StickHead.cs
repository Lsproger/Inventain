using UnityEngine;

public class StickHead : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Bonus")
        {
            EventAggregator.OnIncreaseScoreEventHandler();
        }
        else if (obj.tag == "Platform")
        {
            obj.gameObject.transform.Find("RightPlatformEdge").
                GetComponent<BoxCollider2D>().enabled = true;
            obj.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
