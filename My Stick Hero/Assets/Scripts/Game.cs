using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    internal GameObject stick;
    internal Rigidbody2D rbStick;
    internal AudioSource stickAudioS;
    internal GameObject stickHead;
    internal bool isNeedToCreateStick = false;
    internal bool isNeedToRotateStick = false;
    internal float rotationSpeed = -180;

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
            if (rbStick.rotation <= -90)
            {
                rbStick.angularVelocity = 0;
            }

        }
    }


    public void CreateStick()
    {
        isNeedToCreateStick = true;
        stick = GameObject.FindGameObjectWithTag("Platform").transform.Find("Stick").gameObject;
        rbStick = stick.GetComponent<Rigidbody2D>();
        stickAudioS = stick.GetComponent<AudioSource>();
        stickHead = stick.transform.Find("StickHead").gameObject;
        stick.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        stickHead.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        stickAudioS.Play();
    }


    public void StopCreateStick()
    {
        isNeedToCreateStick = false;
        isNeedToRotateStick = true;
        stickAudioS.Stop();
        rbStick.angularVelocity = -100;
        //rbStick.AddTorque(-100);
    }


}
