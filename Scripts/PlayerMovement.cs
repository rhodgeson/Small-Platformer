using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // GameObject player;

    //Movement
    public float speed;
    public float jump;
    float moveVelocity;

    //Grounded Vars
    bool grounded = true;
    bool canDoubleJump = false;

    //Animation
    PlayerAnimator anim;

    //Audio
    public AudioSource jumpSound;
    public AudioSource deathSound;

    void Start()
    {
        anim = gameObject.GetComponent<PlayerAnimator>();
    }
    void Update()
    {
        //Jumping
        // if (stay)
        // {
        //     grounded = true;
        //     stay = false;
        // }
        // else { grounded = false; }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                jumpSound.Play(0);
            }
            else if (canDoubleJump)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                jumpSound.Play(0);
                canDoubleJump = false;
            }
        }

        moveVelocity = 0;

        //Left Right Movement
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity = speed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        if (gameObject.transform.position.y < -1.8)
        {
            SceneManager.LoadScene("Game");
        }
    }
    //Check if Grounded
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
            canDoubleJump = false;
        }

        if (col.gameObject.tag == "Finish")
        {
            //go to next scene
            SceneManager.LoadScene("Win");
        }

        if (col.gameObject.tag == "Trap")
        {
            //go to next scene
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            anim.playerDeath();
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 2);
            deathSound.Play(0);
            //SceneManager.LoadScene("SampleScene 1");
        }

    }
    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = false;
            canDoubleJump = true;
        }
    }
    // private bool leftPressed, rightPressed, jumpPressed;

    // float moveH, moveV;

    // float speed = 5;

    // Vector2 movement;
    // private Rigidbody2D rgbd;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     rgbd = GetComponent<Rigidbody2D>();
    // }

    // void FixedUpdate()
    // {
    //     moveH = Input.GetAxis("Horizontal");
    //     moveV = Input.GetAxis("Vertical");
    //     movement = new Vector2(moveH, moveV);

    //     rgbd.AddForce(movement * speed);
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     // if (Input.GetKeyDown(KeyCode.D))
    //     // {
    //     //     rightPressed = true;
    //     // }
    //     // else if (Input.GetKeyDown(KeyCode.W))
    //     // {
    //     //     leftPressed = true;
    //     // }

    //     // if (Input.GetKeyDown(KeyCode.W))
    //     // {
    //     //     jumpPressed = true;
    //     // }
    // }
}
