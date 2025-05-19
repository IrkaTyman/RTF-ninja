using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using YG;

public class Manager : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += GetLoadSave;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoadSave;
    public int _score;
    public TMP_Text _scoreText;
    private int count = 3;
    private int level = 1;
    public GameObject[] hearts;
    public GameObject loseScreen;
    public GameObject levelScreen;
    public GameObject winScreen;
    public int[] levelsScore;
    public GameObject[] levelsPointSpawner;
    public GameObject[] levelsBombSpawner;

    void Start() {
        if(YandexGame.SDKEnabled == true) {
            GetLoadSave();
        }
    }

    void Update()
    {
        _scoreText.text = _score.ToString() + "/" + levelsScore[level];    
    }

     public int Damage() {
        count -= 1;
        ShowHearts();
        

        if(count == 0) {
            loseScreen.SetActive(true);
            Time.timeScale = 0;
            UserSave();
            GetLoadSave();
        }
        
        return count;
    }

    public void ShowHearts() {
        for(var i = 0; i < hearts.Length; i++) {
            if(i >= count) {
                hearts[i].SetActive(false);
            } else {
                hearts[i].SetActive(true);
            }
        }
    }

    public async void LevelUpdate() {
        if(hearts.Length == 0) {
            return;
        }
        if(_score >= levelsScore[level]) {
            if(level == 4) {
                winScreen.SetActive(true);
                Time.timeScale = 0;
            } else {
                _score = 0;
                levelsPointSpawner[level-1].SetActive(false);
                levelsBombSpawner[level-1].SetActive(false);
                level += 1;
                
                levelsPointSpawner[level-1].SetActive(true);
                levelsBombSpawner[level-1].SetActive(true);
                levelScreen.SetActive(true);
                Time.timeScale = 0;

                await Task.Delay(10000);
            }
        }
    }

    public void GetLoadSave() {
        Debug.Log(YandexGame.savesData.bestScore);
        Debug.Log(YandexGame.savesData.bestLevel);
    }

    public void UserSave() {
        if(level > YandexGame.savesData.bestLevel) {
            YandexGame.savesData.bestScore = _score;
            YandexGame.savesData.bestLevel = level;
        } else if (level == YandexGame.savesData.bestLevel && _score >  YandexGame.savesData.bestScore) {
             YandexGame.savesData.bestScore = _score;
        }
        
        YandexGame.SaveProgress();
    }
}
