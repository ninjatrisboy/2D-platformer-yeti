using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PauseScreen : MonoBehaviour
{
    public string levelSelect;
    public string mainMenu;

    private LevelManager theLevelManager;
    private PlayerController thePlayer;

    public GameObject thePauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Pause"))
        {
         if(Time.timeScale == 0f)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
      
    }

    public void PauseGame()
    {
        Time.timeScale = 0;

        thePauseScreen.SetActive(true);
        thePlayer.canMove = false;
        theLevelManager.levelMusic.Pause();
    }
    public void ResumeGame()
    {
        thePauseScreen.SetActive(false);
        Time.timeScale = 1;
        thePlayer.canMove = true;

        theLevelManager.levelMusic.Play();

    }
    public void LevelSelect()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("CoinCount", theLevelManager.coinCount);
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.startingLives);

        SceneManager.LoadScene(levelSelect);

    }
    public void QuitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenu);
    } 
}
