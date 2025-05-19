using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using TMPro;

public class CheckConnectYG : MonoBehaviour
{
    public GameObject AuthScreen;

    void Update()
    {
        if(YandexGame.SDKEnabled == true && YandexGame.auth == false) {
           AuthScreen.SetActive(true);
        }
    }

    public void Auth() {
        YandexGame.AuthDialog();
        AuthScreen.SetActive(false);
    }
}
