using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string firstLevel;
    public string LevelSelect;

    public string[] levelNames;

    public int startingLives;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewGame()
    {
        SceneManager.LoadScene(firstLevel);

        for (int i = 0; i < levelNames.Length; i++) 
        {
            PlayerPrefs.SetInt(levelNames[i], 0);
        }
        PlayerPrefs.SetInt("CoinCount", 0);
        PlayerPrefs.SetInt("PlayerLives", startingLives);
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene(LevelSelect);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
