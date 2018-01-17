using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    internal bool isSoundOn = true;
    internal Image soundImage;
    internal bool isNeedToHideUI = false;


    [SerializeField]
    private Sprite sndOnImg;
    [SerializeField]
    private Sprite sndOffImg;
    [SerializeField]
    private Canvas canvas;


    void Start()
    {
        transform.Find("Play").GetComponent<Button>().onClick.
            AddListener(delegate () { PlayButton_OnCLick(); });
        transform.Find("Sound").GetComponent<Button>().onClick.
            AddListener(delegate () { SoundButton_OnClick(); });
        soundImage = transform.Find("Sound").GetComponent<Image>();
        soundImage.sprite = sndOnImg;
    }


    private void PlayButton_OnCLick()
    {
        InputAggregator.OnPlayCliсkEventHandler();
        GameStateManager.instance.State = GameStateManager.GameState.Game;
    }


    private void SoundButton_OnClick()
    {
        if (isSoundOn)
        {
            AudioListener.volume = 0;
            soundImage.sprite = sndOffImg;
            isSoundOn = !isSoundOn;
        }
        else
        {
            AudioListener.volume = 1;
            soundImage.sprite = sndOnImg;
            isSoundOn = !isSoundOn;
        }
    }
}
