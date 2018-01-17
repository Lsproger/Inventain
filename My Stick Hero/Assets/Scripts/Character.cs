using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {


    void OnEnable()
    {
        InputAggregator.OnPlayClickEvent += this.StartMove;
        InputAggregator.OnStopRotateStickEvent += this.StartMove;
        InputAggregator.OnGameOverEvent += this.StopMove;
    }

    void OnDisable()
    {
        InputAggregator.OnPlayClickEvent -= this.StartMove;
        InputAggregator.OnStopRotateStickEvent -= this.StartMove;
        InputAggregator.OnGameOverEvent -= this.StopMove;
    }
	
	void Update () {
        if (GetComponent<Animator>().GetBool("isWalking"))
        {
            Walking();
        }
    }

    internal void Walking()
    {
        Vector3 currCharPos = transform.position;
        transform.position = new Vector3((currCharPos.x + 0.1f), currCharPos.y, currCharPos.z);
    }

    public void StartMove()
    {
        gameObject.GetComponent<Animator>().SetBool("isWalking", true);
    }

    public void StopMove()
    {
        gameObject.GetComponent<Animator>().SetBool("isWalking", false);
    }
}
