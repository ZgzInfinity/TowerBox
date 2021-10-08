
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
 * Script that controls the reproduction of the music in the main level
 */

public class GamePlayAudioPlayer : MonoBehaviour
{
    // Array with the musics to be played
    public Sound[] gamePlayMusicSound;

    // Start is called before the first frame update
    void Start()
    {
        // Play a random music during the level
        AudioManager.Instance.PlaySound(gamePlayMusicSound[Random.Range(0, gamePlayMusicSound.Length)]);
    }
}
