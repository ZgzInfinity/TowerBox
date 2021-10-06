using UnityEngine;

public class BoxSpawner : MonoBehaviour
{

    public GameObject[] boxesPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        spawnBox();
    }

    public void spawnBox()
    {
        Instantiate(boxesPrefabs[Random.Range(0, boxesPrefabs.Length)], transform.position, Quaternion.identity);
    }
}
