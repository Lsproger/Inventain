using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour {

    internal GameObject stick;
    internal bool isNeedToCreateStick = false;
    internal bool isNeedToRotateStick = false;
    internal float stickRotation = 0;
    internal float rotationSpeed = 5;


    public void CreateStick()
    {
        Debug.Log("I'M CREATING;");
        isNeedToCreateStick = true;
        stick = GameObject.FindGameObjectWithTag("Platform").transform.
               Find("Stick").gameObject;
        stick.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }


    public void StopCreateStick()
    {
        isNeedToCreateStick = false;
        isNeedToRotateStick = true;
    }

    

}
