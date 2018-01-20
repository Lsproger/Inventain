using UnityEngine;

public class Character : MonoBehaviour
{

    internal AudioSource stepsSource;
    internal static Animator charAnim;
    internal static int paramNumber;
    internal string paramName = "isWalking";


    void Awake()
    {
        stepsSource = GetComponent<AudioSource>();
        charAnim = GetComponent<Animator>();

        foreach (var par in charAnim.parameters)
        {
            if (par.name == paramName)
            {
                paramNumber = par.nameHash;
                break;
            }
        }
        
    }


    void OnEnable()
    {
        EventAggregator.OnPlayClickEvent += this.StartMove;
        EventAggregator.OnStopRotateStickEvent += this.StartMove;

        EventAggregator.OnGameOverEvent += this.StopMove;
        EventAggregator.OnPlatformEdgeReachedEvent += this.StopMove;
    }


    void OnDisable()
    {
        EventAggregator.OnPlayClickEvent -= this.StartMove;
        EventAggregator.OnStopRotateStickEvent -= this.StartMove;

        EventAggregator.OnGameOverEvent -= this.StopMove;
        EventAggregator.OnPlatformEdgeReachedEvent -= this.StopMove;
    }


    void Update () {
        if (charAnim.GetBool(paramNumber))
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


    internal static void SetCharacterAnim(bool isWalking)
    {
        charAnim.SetBool(paramNumber, isWalking);
    }
}
