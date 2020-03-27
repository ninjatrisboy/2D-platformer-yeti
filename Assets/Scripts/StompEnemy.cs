using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompEnemy : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;

    private LevelManager theLevelManager;

    public float bounceForce;

    public GameObject deathSplosion;

    public int coinKillcount;

    // Start is called before the first frame update
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        playerRigidbody = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // Destroy(other.gameObject);

            theLevelManager.AddCoins(coinKillcount);

            other.gameObject.SetActive(false);

            Instantiate(deathSplosion, other.transform.position, other.transform.rotation);

            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, bounceForce, 0f);

        }
    }  
}
