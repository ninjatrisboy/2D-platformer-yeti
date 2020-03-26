using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenWiggleController : MonoBehaviour
{

    public Transform LeftPoint;
    public Transform RightPoint;

    public float moveSpeed;

    private Rigidbody2D myRigidbody;

    public bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
       if(movingRight && transform.position.x > RightPoint.position.x)
        {
            movingRight = false;
        }
        if (!movingRight && transform.position.x < LeftPoint.position.x)
        {
            movingRight = true;
        }

        if(movingRight)
        {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
        } else {

            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
        }

    }
}
