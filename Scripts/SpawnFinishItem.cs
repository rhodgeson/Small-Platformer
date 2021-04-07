using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFinishItem : MonoBehaviour
{
    public GameObject trophy;
    private bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Fruit").Length == 0 && !spawned)
        {
            Debug.Log("Spawned!");
            GameObject newTrophy = Instantiate(trophy);
            newTrophy.transform.position = new Vector3((float)-2.5, (float)-0.558, 0);
            spawned = true;
        }
    }
}
