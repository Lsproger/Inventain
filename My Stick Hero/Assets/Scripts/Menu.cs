using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    internal bool isSoundOn = true;
    internal bool isPlayButtonClicked = false;
    internal Image soundImage;


    [SerializeField]
    private Sprite sndOnImg;
    [SerializeField]
    private Sprite sndOffImg;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private GameObject character;


    void Start()
    {
        transform.Find("Play").GetComponent<Button>().onClick.
            AddListener(delegate () { PlayButton_OnCLick(); });
        transform.Find("Sound").GetComponent<Button>().onClick.
            AddListener(delegate () { SoundButton_OnClick(); });
        soundImage = transform.Find("Sound").GetComponent<Image>();
        soundImage.sprite = sndOnImg;
    }


    void FixedUpdate()
    {

        if (character.GetComponent<Animator>().GetBool("isWalking"))
        {
            Debug.Log("WALKING");
            Vector3 currCharPos = character.transform.position;
            character.transform.position = new Vector3((currCharPos.x + 0.1f) * Time.deltaTime, currCharPos.y, currCharPos.z);
            Camera.main.transform.Translate(new Vector3(0.1f, 0, 0) * Time.deltaTime);
        }

    }

    private void PlayButton_OnCLick()
    {
        canvas.transform.Find("Menu").gameObject.SetActive(false);
        canvas.transform.Find("Game").gameObject.SetActive(true);
        character.GetComponent<Animator>().SetBool("isWalking", true);
        Debug.Log(character.GetComponent<Animator>().GetBool("isWalking"));
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
