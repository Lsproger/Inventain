﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    internal GameObject stick;
    internal GameObject stickHead;
    internal bool isNeedToCreateStick = false;
    internal bool isNeedToRotateStick = false;
    internal float rotationSpeed = 3;

    internal const float DEAFAULT_STICK_HEAD_SCALE = 0.2f;


    void OnEnable()
    {
        InputAggregator.OnCreateStickEvent += this.CreateStick;
        InputAggregator.OnStopCreateStickEvent += this.StopCreateStick;
    }


    void OnDisable()
    {
        InputAggregator.OnCreateStickEvent -= this.CreateStick;
        InputAggregator.OnStopCreateStickEvent -= this.StopCreateStick;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameStateManager.instance.State == GameStateManager.GameState.Game)
        {
            InputAggregator.Game_OnCreateStickEvent();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && GameStateManager.instance.State == GameStateManager.GameState.Game)
        {
            InputAggregator.Game_OnStopCreateStickEvent();
            Debug.Log("STOP CREATING STICK");
        }

        if (isNeedToCreateStick)
        {
            stick.transform.localScale = new Vector3
                (
                stick.transform.localScale.x,
                stick.transform.localScale.y + 1f,
                stick.transform.localScale.z
                );
            stickHead.transform.localScale = new Vector3
                (
                stickHead.transform.localScale.x,
                DEAFAULT_STICK_HEAD_SCALE / stick.transform.localScale.y,
                stickHead.transform.localScale.z
                );
        }

        if (isNeedToRotateStick)
        {
            if (stick.transform.rotation.eulerAngles.z - 360 > -90 ||
                stick.transform.rotation.eulerAngles.z == 0)
            {
                stick.transform.Rotate(new Vector3(0, 0, -rotationSpeed));
            }
            else
            {
                isNeedToRotateStick = false;
                InputAggregator.Game_OnStopRotateStickEvent();
            }
        }
    }


    public void CreateStick()
    {
        isNeedToCreateStick = true;
        stick = GameObject.FindGameObjectWithTag("Platform").transform.Find("Stick").gameObject;
        stickHead = stick.transform.Find("StickHead").gameObject;
        stick.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        stickHead.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }


    public void StopCreateStick()
    {
        isNeedToCreateStick = false;
        isNeedToRotateStick = true;
    }


}