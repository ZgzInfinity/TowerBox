
/*
 * ------------------------------------------
 * -- Project: Tower Box --------------------
 * -- Author: Rubén Rodríguez Estebban ------
 * -- Date: 8/10/2021 -----------------------
 * ------------------------------------------
 */

using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Script that controls the change of a scene
 */

public class GameSceneManager : MonoBehaviour
{
    // Static instance
    public static GameSceneManager Instance;

    // Constructor
    private void Awake()
    {
        Instance = this;
    }

    // Change the scene to a new one
    public void ChangeScene(string sceneToLoad)
    {
        // Change the scene
        SceneManager.LoadScene(sceneToLoad);
    }

    // Get the name of the current scene
    public string GetSceneName()
    {
        // Get the name
        return SceneManager.GetActiveScene().name;
    }
}
