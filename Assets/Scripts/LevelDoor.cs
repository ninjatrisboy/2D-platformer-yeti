using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{
    public string levelToLoad;
    private bool isColliding;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   void OnTriggerStay2D(Collider2D other)
   {
      if(other.tag == "Player")
      {            
        if(Input.GetButtonDown("Submit")&& isColliding == true)
        {
            print("load next level");
            SceneManager.LoadScene(levelToLoad);
        }
      }
   }

    void OnTriggerEnter2D(Collider2D other)
    {
        isColliding = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isColliding = false;
    }
}
