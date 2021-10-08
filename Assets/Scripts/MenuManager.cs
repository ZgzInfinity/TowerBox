
/*
 * ------------------------------------------
 * -- Project: Tower Box --------------------
 * -- Author: Rubén Rodríguez Estebban ------
 * -- Date: 8/10/2021 -----------------------
 * ------------------------------------------
 */

using UnityEngine;
using TMPro;
using System.Collections;

/**
 * Script that controls the transition between the scenes
 */

public class MenuManager : MonoBehaviour
{
    // Reference to the text score indicator
    public TMP_Text scoreText;

    // Reference to the music of the scene
    public Sound menuSound;

    // Array of references to button pressed sounds
    public Sound[] buttonSounds;

    // Index of the sound to be played
    private int indexSound;

    // Start is called before the first frame update
    void Start()
    {
        // Check if the current scene is the main menu
        if (GameSceneManager.Instance.GetSceneName() == "Menu")
        {
            // Sets the top score of the game
            scoreText.text = PlayerPrefs.GetInt("TopScore").ToString();
        }
        // Check if the scene is not the main level
        if (GameSceneManager.Instance.GetSceneName() != "Level")
        {
            // Play the music of the menu
            AudioManager.Instance.PlaySound(menuSound);
        }
    }

    // Changes of scene when a button is pressed
    public void ChangeSceneAfterButtonSound(string sceneToLoad)
    {
        // Check if the scene is not the level
        if (GameSceneManager.Instance.GetSceneName() != "Level")
        {
            // Play normal sound
            indexSound = 0;
        }
        else
        {
            // Play restart sound
            indexSound = 1;
        }

        // Reproduce the sound and change the scene after it has finished
        AudioManager.Instance.PlaySound(buttonSounds[indexSound]);
        StartCoroutine(ChangeSceneAfterButtonSoundCoRoutine(indexSound, sceneToLoad));
    }

    // Change the scene
    private IEnumerator ChangeSceneAfterButtonSoundCoRoutine(int indexSound, string sceneToLoad)
    {
        // Wait until the sound has finished and change the scene
        yield return new WaitForSeconds(buttonSounds[indexSound].clip.length);
        GameSceneManager.Instance.ChangeScene(sceneToLoad);
    }
}
