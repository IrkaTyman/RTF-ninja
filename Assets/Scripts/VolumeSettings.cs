using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public GameObject volumeButton;
    public Sprite volumeOffBack;
    public Sprite volumeOnBack;

    public void Start() {
        Image image = volumeButton.GetComponent<Image>();

        if(AudioListener.volume == 0) {
            image.sprite = volumeOffBack;
        }
    }

    public void Change() {
        Image image = volumeButton.GetComponent<Image>();

        if(AudioListener.volume == 0) {
            AudioListener.volume = 1;
            image.sprite = volumeOnBack;
        } else {
            AudioListener.volume = 0;
            image.sprite = volumeOffBack;
        }
    }
}
