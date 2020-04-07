using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSaw : MonoBehaviour
{
    public bool sawActive;

    public float timeBetweenDrops;
    private float dropCount;

    public Transform dropSawSpawnPoint;
    public GameObject dropSaw;

    public Transform leftPoint;
    public Transform rightPoint;

    // Start is called before the first frame update
    void Start()
    {
        dropCount = timeBetweenDrops;
    }

    // Update is called once per frame
    void Update()
    {
        if (sawActive)
        {
            dropSaw.SetActive(true);
            if (dropCount > 0)
            {

                dropCount -= Time.deltaTime;
            }
            else
            {
                dropSawSpawnPoint.position = new Vector3(Random.Range(leftPoint.position.x, rightPoint.position.x), dropSawSpawnPoint.position.y, dropSawSpawnPoint.position.z);
                Instantiate(dropSaw, dropSawSpawnPoint.position, dropSawSpawnPoint.rotation);
                dropCount = timeBetweenDrops;
            }
        }    
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            sawActive = true;

        }
    }
}
