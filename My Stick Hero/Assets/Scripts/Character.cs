using UnityEngine;

public class Character : MonoBehaviour
{
    #region Fields
    internal static Animator characterAnim;
    internal static int paramNumber;


    internal AudioSource stepsSource;
    internal string paramName = "isWalking";
    #endregion


    #region Unity lifecycle
    void OnEnable()
    {
        EventAggregator.OnPlayClickEvent += this.StartMove;
        EventAggregator.OnStopRotateEvent += this.StartMove;

        EventAggregator.OnGameOverEvent += this.StopMove;
        EventAggregator.OnPlatformEdgeReachedEvent += this.StopMove;
    }


    void OnDisable()
    {
        EventAggregator.OnPlayClickEvent -= this.StartMove;
        EventAggregator.OnStopRotateEvent -= this.StartMove;

        EventAggregator.OnGameOverEvent -= this.StopMove;
        EventAggregator.OnPlatformEdgeReachedEvent -= this.StopMove;
    }


    void Awake()
    {
        stepsSource = GetComponent<AudioSource>();
        characterAnim = GetComponent<Animator>();

        foreach (var par in characterAnim.parameters)
        {
            if (par.name == paramName)
            {
                paramNumber = par.nameHash;
                break;
            }
        }
        
    }


    void Update () {
        if (characterAnim.GetBool(paramNumber))
        {
            Walking();
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    #endregion


    #region Public methods
    internal static void SetCharacterAnim(bool isWalking)
    {
        characterAnim.SetBool(paramNumber, isWalking);
    }


    internal void Walking()
    {
        Vector3 currCharPos = transform.position;
        transform.position = new Vector3((currCharPos.x + 0.1f), currCharPos.y, currCharPos.z);
    }


    internal void StartMove()
    {
        SetCharacterAnim(true);
        stepsSource.Play();
    }


    internal void StopMove()
    {
        SetCharacterAnim(false);
        stepsSource.Stop();
    }
    #endregion
}
