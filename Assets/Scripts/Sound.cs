
/*
 * ------------------------------------------
 * -- Project: Tower Box --------------------
 * -- Author: Rubén Rodríguez Estebban ------
 * -- Date: 8/10/2021 -----------------------
 * ------------------------------------------
 */

using UnityEngine;

/**
 * Script that controls the representation of the audio like a scriptable object
 */

// Definition of the scriptable object with its parameters
[CreateAssetMenu(menuName = "TowerBox/Sound", fileName = "Sound.asset")]
public class Sound : ScriptableObject
{
    // Make distinction between soundtracks and FX
    [System.Serializable]
    public enum SoundType
    {
        MUSIC,
        FX
    }

    // Type of sound (music or fx)
    public SoundType soundType;

    // Audio clip to reproduce
    public AudioClip clip;

    // Volume of the sound
    [Range(0f, 1f)]
    public float volume;

    // Controls if the sound must be played in loop or not
    public bool loop;
}
