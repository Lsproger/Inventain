using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    void OnTriggerEnter2d(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            coll.GetComponentInParent<Animator>().SetBool("isWalking", false);
            coll.gameObject.SetActive(false);
        }
        
    }
}
