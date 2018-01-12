using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Animator>().GetBool("isWalking"))
        {
            Debug.Log("WALKING");
            Vector3 currCharPos = transform.position;
            transform.position = new Vector3((currCharPos.x + 0.1f), currCharPos.y, currCharPos.z);
        }
    }

    public void StartMove()
    {
        gameObject.GetComponent<Animator>().SetBool("isWalking", true);
    }
}
