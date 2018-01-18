using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickHead : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Bonus")
        {
            InputAggregator.OnIncreaseScoreEventHandler();
        }
        else if (obj.tag == "Platform")
        {

        }
    }
}
