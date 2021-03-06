using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] idle;
    public Sprite[] vanish;
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(Idle());
    }

    void Update()
    {

    }

    IEnumerator Idle()
    {
        int i;
        i = 0;
        while (i < idle.Length)
        {
            spriteRenderer.sprite = idle[i];
            i++;
            yield return new WaitForSeconds(0.03f);
            yield return 0;

        }
        StartCoroutine(Idle());
    }

    IEnumerator Vanish()
    {
        int i;
        i = 0;
        while (i < vanish.Length)
        {
            spriteRenderer.sprite = vanish[i];
            i++;
            yield return new WaitForSeconds(0.07f);
            yield return 0;

        }
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            audioSource.Play(0);
            StopAllCoroutines();
            StartCoroutine(Vanish());
        }
    }
}
