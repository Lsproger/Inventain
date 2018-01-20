using UnityEngine;

public class Game : MonoBehaviour
{
    #region Fields
    internal const float DEAFAULT_STICK_HEAD_SCALE = 0.2f;


    internal static int stickCounter = 1;


    internal GameObject stick;
    internal GameObject stickHead;
    internal bool isNeedToCreateStick;
    internal bool isNeedToRotateStick;
    internal float rotationSpeed = 3;
    #endregion


    #region Properties
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
    #endregion


    #region Unity lifecycle
    void OnEnable()
    {
        EventAggregator.OnCreateEvent += this.CreateStick;
        EventAggregator.OnStopCreateEvent += this.StopCreateStick;
    }


    void OnDisable()
    {
        EventAggregator.OnCreateEvent -= this.CreateStick;
        EventAggregator.OnStopCreateEvent -= this.StopCreateStick;
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
                EventAggregator.Stick_OnStopRotate();
            }
        }
    }
    #endregion


    #region Public methods
    internal void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (stickCounter > 0)
            {
                EventAggregator.Stick_OnCreate();
                --stickCounter;
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            EventAggregator.Stick_OnStopCreate();
        }
    }


    internal void CreateStick()
    {
            IsNeedToCreateStick = true;
            stick = GameObject.FindGameObjectWithTag("Platform").
                transform.Find("Stick").gameObject;
            stickHead = stick.transform.Find("StickHead").gameObject;
            stick.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            stickHead.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            stick.GetComponent<AudioSource>().Play();
    }


    internal void StopCreateStick()
    {
        IsNeedToCreateStick = false;
        IsNeedToRotateStick = true;
        stick.GetComponent<AudioSource>().Stop();
    }
    #endregion
}