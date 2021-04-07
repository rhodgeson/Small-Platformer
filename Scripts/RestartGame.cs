using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public AudioSource nextScene;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextScene.Play(0);
            SceneManager.LoadScene("Intro");
        }
    }


}
