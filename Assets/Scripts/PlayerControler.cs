using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D myRigidbody;

    public float jumpSpeed;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    private Animator myAnim;

    public Vector3 respawnPosition;

    public LevelManager theLevelManager;

    public GameObject stompBox;

    public float knockbackForce;
    public float knockBackLength;
    private float knockBackCounter;

    public float invincibilityLength;
    private float invincibilityCounter;

    // Start is called before the first frame update
    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        respawnPosition = transform.position;

        theLevelManager = FindObjectOfType<LevelManager>();
    }   

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (knockBackCounter <= 0)
        {

            if (Input.GetAxisRaw("Horizontal") > 0f)
            {
                myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0f)
            {
                myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);

            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);

            }


        }

        if(knockBackCounter > 0)
        {
            knockBackCounter -= Time.deltaTime;

            if (transform.localScale.x > 0)
            {
                myRigidbody.velocity = new Vector3(-knockbackForce, knockbackForce, 0f);
            } else {
                myRigidbody.velocity = new Vector3(knockbackForce, knockbackForce, 0f);
            }

        }
        if(invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

        }
        if(invincibilityCounter <= 0)
        {
            theLevelManager.invincible = false;
        }

        myAnim.SetFloat("Speed", Mathf.Abs(myRigidbody.velocity.x));
        myAnim.SetBool("Grounded", isGrounded);

        if (myRigidbody.velocity.y < 0)
        {
            stompBox.SetActive(true);
        }else {

            stompBox.SetActive(false);
        }

    }

    public void knockback()
    {
        knockBackCounter = knockBackLength;
        invincibilityCounter = invincibilityLength;
        theLevelManager.invincible = true;

    }


    void OnTriggerEnter2D(Collider2D other)
    {


        if(other.tag == "KillPlane")
        {
            //gameObject.SetActive(false);

            //transform.position = respawnPosition;
            print("Respawn called from player controller");

            theLevelManager.Respawn();
        }

        if(other.tag == "Checkpoint")
        {
            respawnPosition = other.transform.position;
        }
    }

      void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;

        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
       if(other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}

