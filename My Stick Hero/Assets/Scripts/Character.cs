﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    internal AudioSource stepsSource;

    void Start()
    {
        stepsSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        InputAggregator.OnPlayClickEvent += this.StartMove;
        InputAggregator.OnStopRotateStickEvent += this.StartMove;
        InputAggregator.OnGameOverEvent += this.StopMove;
        InputAggregator.OnPlatformEdgeReachedEvent += this.StopMove;
    }

    void OnDisable()
    {
        InputAggregator.OnPlayClickEvent -= this.StartMove;
        InputAggregator.OnStopRotateStickEvent -= this.StartMove;
        InputAggregator.OnGameOverEvent -= this.StopMove;
        InputAggregator.OnPlatformEdgeReachedEvent -= this.StopMove;
    }
	
	void Update () {
        if (GetComponent<Animator>().GetBool("isWalking"))
        {
            Walking();
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    internal void Walking()
    {
        Vector3 currCharPos = transform.position;
        transform.position = new Vector3((currCharPos.x + 0.1f), currCharPos.y, currCharPos.z);
    }

    public void StartMove()
    {
        gameObject.GetComponent<Animator>().SetBool("isWalking", true);
        stepsSource.Play();
    }

    public void StopMove()
    {
        gameObject.GetComponent<Animator>().SetBool("isWalking", false);
        stepsSource.Stop();
    }
}
