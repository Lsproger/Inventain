using UnityEngine;

public class Game : MonoBehaviour
{

    internal GameObject stick;
    internal GameObject stickHead;
    internal bool isNeedToCreateStick;
    internal bool isNeedToRotateStick;
    internal float rotationSpeed = 3;
    internal static int stickCounter = 1;

    internal bool IsNeedToCreateStick
    {
        get
        {
            return isNeedToCreateStick;
        }
        set
        {
            isNeedToCreateStick = value;
        }
    }

    internal bool IsNeedToRotateStick
    {
        get
        {
            return isNeedToRotateStick;
        }
        set
        {
            isNeedToRotateStick = value;
        }
    }

    internal const float DEAFAULT_STICK_HEAD_SCALE = 0.2f;


    void OnEnable()
    {
        EventAggregator.OnCreateStickEvent += this.CreateStick;
        EventAggregator.OnStopCreateStickEvent += this.StopCreateStick;
    }


    void OnDisable()
    {
        EventAggregator.OnCreateStickEvent -= this.CreateStick;
        EventAggregator.OnStopCreateStickEvent -= this.StopCreateStick;
    }


    void Start()
    {
        IsNeedToCreateStick = false;
        IsNeedToRotateStick = false;
    }


    void Update()
    {
        InputCheck();

        if (IsNeedToCreateStick)
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

        if (IsNeedToRotateStick)
        {
            if (stick.GetComponent<Rigidbody2D>().rotation > -90)
            {
                stick.transform.Rotate(new Vector3(0, 0, -rotationSpeed));
            }
            else
            {
                IsNeedToRotateStick = false;
                EventAggregator.OnStopRotateStickEventHandler();
            }
        }
    }


    internal void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (stickCounter > 0)
            {
                EventAggregator.OnCreateStickEventHandler();
                --stickCounter;
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            EventAggregator.OnStopCreateStickEventHandler();
        }
    }


    public void CreateStick()
    {
            IsNeedToCreateStick = true;
            stick = GameObject.FindGameObjectWithTag("Platform").
                transform.Find("Stick").gameObject;
            stickHead = stick.transform.Find("StickHead").gameObject;
            stick.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            stickHead.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }


    public void StopCreateStick()
    {
        IsNeedToCreateStick = false;
        IsNeedToRotateStick = true;
    }


}