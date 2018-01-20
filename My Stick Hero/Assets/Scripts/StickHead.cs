using UnityEngine;

public class StickHead : MonoBehaviour
{
    #region Unity lifecycle
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Bonus")
        {
            EventAggregator.Score_OnIncrease();
        }
        else if (obj.tag == "Platform")
        {
            obj.gameObject.transform.Find("RightPlatformEdge").
                GetComponent<BoxCollider2D>().enabled = true;
            obj.gameObject.GetComponent<AudioSource>().Play();
        }
    }
    #endregion
}
