using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    internal GameObject stick;
    internal bool isNeedToCreateStick = false;
	
    
	void Update () {
        if (isNeedToCreateStick)
        {
            stick.transform.localScale = new Vector3
                (
                stick.transform.localScale.x,
                stick.transform.localScale.y + 0.1f,
                stick.transform.localScale.z
                );


        }
	}


    public void CreateStick()
    {
        isNeedToCreateStick = true;
        stick = GameObject.FindGameObjectWithTag("Platform").transform.
               Find("Stick").gameObject;
        Color stickColor = stick.GetComponent<Renderer>().material.color;
        stickColor.a = 1;
        stick.GetComponent<Renderer>().material.color = stickColor;
    }


    public void StopCreateStick()
    {
        isNeedToCreateStick = false;
        stick = null;
    }

    
}
