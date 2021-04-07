using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvAnimator : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] idle;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Idle());
    }

    // Update is called once per frame
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
            yield return new WaitForSeconds(0.07f);
            yield return 0;

        }
        StartCoroutine(Idle());
    }
}

