
/*
 * ------------------------------------------
 * -- Project: Tower Box --------------------
 * -- Author: Rubén Rodríguez Estebban ------
 * -- Date: 8/10/2021 -----------------------
 * ------------------------------------------
 */

using UnityEngine;

/**
 * Script that controls the spawn of the boxes
 */

public class BoxSpawner : MonoBehaviour
{

    // Array of the boxes to be spawned
    public GameObject[] boxesPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn the first box
        spawnBox();
    }

    // Spawn a box
    public void spawnBox()
    {
        // Create a random box in order to be spawned
        Instantiate(boxesPrefabs[Random.Range(0, boxesPrefabs.Length)], transform.position, Quaternion.identity);
    }
}
