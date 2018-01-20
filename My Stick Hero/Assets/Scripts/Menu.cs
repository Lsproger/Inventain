using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    internal bool isSoundOn;
    internal Image soundImage;
    internal bool isNeedToHideUI;

    internal bool IsSoundOn
    {
        get
        {
            return isSoundOn;
        }
        set
        {
            isSoundOn = value;
        }
    }

    internal bool IsNeedToHideUI
    {
        get
        {
            return isNeedToHideUI;
        }
        set
        {
            isNeedToHideUI = value;
        }
    } 


    [SerializeField]
    private Sprite sndOnImg;
    [SerializeField]
    private Sprite sndOffImg;
    [SerializeField]
    private Canvas canvas;


    void Start()
    {
        IsSoundOn = true;
        IsNeedToHideUI = false;

        transform.Find("Play").GetComponent<Button>().onClick.
            AddListener(delegate () { PlayButton_OnCLick(); });
        transform.Find("Sound").GetComponent<Button>().onClick.
            AddListener(delegate () { SoundButton_OnClick(); });

        soundImage = transform.Find("Sound").GetComponent<Image>();
        soundImage.sprite = sndOnImg;
    }


    private void PlayButton_OnCLick()
    {
        EventAggregator.Game_OnPlayCliсk();
        GameStateManager.instance.State = GameStateManager.GameState.Game;
    }


    private void SoundButton_OnClick()
    {
        if (IsSoundOn)
        {
            AudioListener.volume = 0;
            soundImage.sprite = sndOffImg;
            IsSoundOn = !IsSoundOn;
        }
        else
        {
            AudioListener.volume = 1;
            soundImage.sprite = sndOnImg;
            IsSoundOn = !IsSoundOn;
        }
    }
}
