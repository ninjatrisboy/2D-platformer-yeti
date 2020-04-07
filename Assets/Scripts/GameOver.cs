using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string levelSelect;
    public string mainMenu;

    private LevelManager theLevelManager;

    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Restart()
    {
        PlayerPrefs.SetInt("CoinCount", 0);
        PlayerPrefs.SetInt("PlayerLives",theLevelManager.startingLives);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LevelSelect()
    {
        PlayerPrefs.SetInt("CoinCount", 0);
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.startingLives);

        SceneManager.LoadScene(levelSelect);
    }
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

}
