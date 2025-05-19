using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioControl : MonoBehaviour
{
    public static AudioControl instance = null;
    public AudioSource source;

    void Update() {
        Scene activeScene = SceneManager.GetActiveScene();

        if (activeScene.name == "Game") {
            Destroy(gameObject);
            instance = null;
        }
    }

    void Awake() {
        if(instance == null) {
            instance = this;
        } else if (instance != this ) {
            Destroy(gameObject);
        }  

        DontDestroyOnLoad(gameObject);
    }
}
