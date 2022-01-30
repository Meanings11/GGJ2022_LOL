using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Sprite unmuteSprite;
    public Sprite muteSprite;
    public AudioSource bgm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Onclick()
    {
        if (this.GetComponent<Image>().sprite == unmuteSprite)
        {
            bgm.mute=!bgm.mute;
            this.GetComponent<Image>().sprite = muteSprite;
        }
        else
        {
            bgm.mute=!bgm.mute;
            this.GetComponent<Image>().sprite = unmuteSprite;
        }
    }
}
