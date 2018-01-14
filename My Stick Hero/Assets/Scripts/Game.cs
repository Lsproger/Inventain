using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    internal GameObject stick;
    internal bool isNeedToCreateStick = false;
    internal bool isNeedToRotateStick = false;
    internal float stickRotation = 0;
    internal float rotationSpeed = 5;
	
    
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && GameState.state == GameState.States.Game)
        {
            InputAggregator.Game_OnCreateStickEvent();
            Debug.Log("STARTCREATINGSTICK");
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && GameState.state == GameState.States.Game)
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
        }

        if (isNeedToRotateStick)
        {
            if (stickRotation > -90)
            {
                stickRotation -= rotationSpeed;
                stick.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, stickRotation));
            }
            else
            {
                stickRotation = 0;
                isNeedToRotateStick = false;
                InputAggregator.Game_OnStopRotateStickEvent();
            }
        }
	}


    public void CreateStick()
    {
        Debug.Log("I'M CREATING;");
        isNeedToCreateStick = true;
        stick = GameObject.FindGameObjectWithTag("Platform").transform.Find("Stick").gameObject;
        Debug.Log("STICKMMMMMM" + stick.name);
        //Color stickColor = stick.GetComponent<Renderer>().material.color;
        //stickColor.a = 1;
        stick.GetComponent<Renderer>().material.color = new Color(1,1,1,1);
    }


    public void StopCreateStick()
    {
        isNeedToCreateStick = false;
        isNeedToRotateStick = true;
    }

    
}
