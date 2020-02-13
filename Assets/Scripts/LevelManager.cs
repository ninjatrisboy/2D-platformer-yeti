using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public float waitToRespawn;
    public PlayerControler thePlayer;

    public GameObject deathSplosion;

    public int coinCount;

    public Text coinText;


    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerControler>();

        coinText.text = "Coins: " + coinCount;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Respawn()
    {
        StartCoroutine("RespawnCo");

    }

    public IEnumerator RespawnCo()
    {
        thePlayer.gameObject.SetActive(false);

        Instantiate(deathSplosion, thePlayer.transform.position, thePlayer.transform.rotation);

        yield return new WaitForSeconds(waitToRespawn);

        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);
    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;

        coinText.text = "Coins: " + coinCount;

    }
}
 