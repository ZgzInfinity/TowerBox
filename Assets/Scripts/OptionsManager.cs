
/*
 * ------------------------------------------
 * -- Project: Tower Box --------------------
 * -- Author: Rubén Rodríguez Estebban ------
 * -- Date: 8/10/2021 -----------------------
 * ------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Scrip that controls the behaviour of the game in the options menu
 */

public class OptionsManager : MonoBehaviour
{

    // Reference to the sound when a button is pressed
    public Sound buttonSound;

    // Set the score to zero
    public void ResetTopScore()
    {
        // Stores the score with value zero
        PlayerPrefs.SetInt("TopScore", 0);

        // Play the sound of pressing a button
        AudioManager.Instance.PlaySound(buttonSound);
    }
}
