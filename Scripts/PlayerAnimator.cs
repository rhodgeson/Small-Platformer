using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] walk;
    public Sprite[] idle;
    public Sprite[] death;

    bool facingLeft = false;
    bool stopped = true;
    Rigidbody2D rgbd;
    void Start()
    {
        StartCoroutine(Idle());
        rgbd = GetComponent<Rigidbody2D>();
    }

    // void FixedUpdate()
    // {
    //     if (rgbd.velocity.x >= 0 || !facingLeft)
    //     {
    //         spriteRenderer.flipX = false;
    //     }
    //     else
    //     {
    //         spriteRenderer.flipX = true;
    //     }
    // }
    void Update()
    {
        //left walk animation
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            stopped = false;
            facingLeft = true;
            StopAllCoroutines();
            StartCoroutine(Walk());
        }

        //right walk animation
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            stopped = false;
            facingLeft = false;
            StopAllCoroutines();
            StartCoroutine(Walk());
        }
        //if no movement keys are being pressed and idle animation hasnt already started
        if (!Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow) && !stopped)
        {
            stopped = true;
            StopAllCoroutines();
            StartCoroutine(Idle());
        }

    }
    public IEnumerator Idle()
    {
        int i;
        i = 0;
        while (i < idle.Length)
        {
            if (facingLeft)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            spriteRenderer.sprite = idle[i];
            i++;
            yield return new WaitForSeconds(0.07f);
            yield return 0;

        }
        StartCoroutine(Idle());
    }
    public IEnumerator Walk()
    {
        int i;
        i = 0;
        while (i < walk.Length)
        {
            if (facingLeft)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            spriteRenderer.sprite = walk[i];
            i++;
            yield return new WaitForSeconds(0.07f);
            yield return 0;
        }
        StartCoroutine(Walk());
    }

    public void playerDeath()
    {
        if (facingLeft)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        spriteRenderer.sprite = death[0];
    }
}

