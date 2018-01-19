using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour {

    internal GameObject stick;
    internal AudioSource stickAudioS;
    internal bool isNeedToCreateStick = false;
    internal bool isNeedToRotateStick = false;
    internal float stickRotation = 0;
    internal float rotationSpeed = 5;


    void OnEnabled()
    {
        //InputAggregator.OnStickReachedPlatformEvent += 
    }

    void OnDisabled()
    {

    }




    public void CreateStick()
    {
        Debug.Log("I'M CREATING;");
        isNeedToCreateStick = true;
        stick = GameObject.FindGameObjectWithTag("Platform").transform.
               Find("Stick").gameObject;
        stickAudioS = stick.GetComponent<AudioSource>();
        stick.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }


    public void StopCreateStick()
    {
        isNeedToCreateStick = false;
        isNeedToRotateStick = true;
    }

    

}
