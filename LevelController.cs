using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;
    int sceneIndex;
    int levelCompletae;
       
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelCompletae = PlayerPrefs.GetInt("LevelComplete");
    }
    public void isEndGame()
    {
        if (sceneIndex == 3)
        {
            Invoke("LoadMainMenu", 1f);
        }
        else
        {
            if (levelCompletae < sceneIndex)
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            Invoke("NextLevel", 1f);
        }
    }
   
    void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
